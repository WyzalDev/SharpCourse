// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Task3.Utils
{
    [Serializable]
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ISerializable
    {
        [NonSerialized] public Action DictionaryChanged;

        private readonly IEqualityComparer<TKey> _comparer;

        private int[] _buckets;
        private Entry[] _entries;

        private int _count;
        private int _firstFree;
        private int _freeCount;

        public ObservableDictionary(int capacity = 0, IEqualityComparer<TKey> comparer = null)
        {
            _comparer = comparer ?? EqualityComparer<TKey>.Default;
            Initialize(capacity);
        }

        protected ObservableDictionary(SerializationInfo info, StreamingContext context)
        {
            _comparer = EqualityComparer<TKey>.Default;
            var count = info.GetInt32("Count");
            Initialize(count + 1);

            for (var i = 0; i < count; i++)
            {
                var key = (TKey)info.GetValue($"Key_{i}", typeof(TKey));
                var value = (TValue)info.GetValue($"Value_{i}", typeof(TValue));
                Add(key, value);
            }
        }

        private void Initialize(int capacity)
        {
            var size = HashHelpers.GetPrime(capacity);

            _buckets = new int[size];

            for (var i = 0; i < size; i++)
                _buckets[i] = -1;

            _entries = new Entry[size];
            _firstFree = -1;
        }

        private void InvokeDictionaryChanged() => DictionaryChanged?.Invoke();

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (var i = 0; i < _count; i++)
            {
                if (_entries[i].HashCode >= 0)
                    yield return new KeyValuePair<TKey, TValue>(_entries[i].Key, _entries[i].Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);

        public void Clear()
        {
            if (_count > 0)
            {
                Array.Clear(_buckets, 0, _buckets.Length);
                Array.Clear(_entries, 0, _entries.Length);

                _firstFree = -1;
                _count = 0;
                _freeCount = 0;

                InvokeDictionaryChanged();
            }
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
            => TryGetValue(item.Key, out var value) && EqualityComparer<TValue>.Default.Equals(value, item.Value);

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("Not enough space in array");

            for (var i = 0; i < array.Length; i++)
            {
                if (_entries[i].HashCode >= 0)
                    array[arrayIndex++] = new KeyValuePair<TKey, TValue>(_entries[i].Key, _entries[i].Value);
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item) => Contains(item) && Remove(item.Key);

        public int Count => _count - _freeCount;
        public bool IsReadOnly => false;
        public void Add(TKey key, TValue value) => Insert(key, value, true);

        public bool ContainsKey(TKey key) => FindEntry(key) >= 0;

        public bool Remove(TKey key)
        {
            if (_buckets == null)
                return false;

            var hashCode = _comparer.GetHashCode(key) & 0x7FFFFFFF;
            var bucketIndex = hashCode % _buckets.Length;
            var last = -1;

            for (var i = _buckets[bucketIndex]; i >= 0; last = i, i = _entries[i].Next)
            {
                if (_entries[i].HashCode == hashCode && _comparer.Equals(_entries[i].Key, key))
                {
                    if (last < 0)
                        _buckets[bucketIndex] = _entries[i].Next;
                    else
                        _entries[last].Next = _entries[i].Next;

                    _entries[i].HashCode = -1;
                    _entries[i].Next = _firstFree;
                    _entries[i].Key = default;
                    _entries[i].Value = default;

                    _firstFree = i;
                    _freeCount++;

                    InvokeDictionaryChanged();

                    return true;
                }
            }

            return false;
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            var index = FindEntry(key);

            if (index >= 0)
            {
                value = _entries[index].Value;
                return true;
            }

            value = default;
            return false;
        }

        public TValue this[TKey key]
        {
            get
            {
                var index = FindEntry(key);

                if (index >= 0)
                    return _entries[index].Value;

                throw new KeyNotFoundException();
            }
            set => Insert(key, value, false);
        }

        public ICollection<TKey> Keys => GetKeys();
        public ICollection<TValue> Values => GetValues();

        private int FindEntry(TKey key)
        {
            if (_buckets == null)
                return -1;

            var hashCode = _comparer.GetHashCode(key) & 0x7FFFFFFF;

            for (var i = _buckets[hashCode % _buckets.Length]; i >= 0; i = _entries[i].Next)
            {
                if (_entries[i].HashCode == hashCode && _comparer.Equals(_entries[i].Key, key))
                    return i;
            }

            return -1;
        }

        private void Insert(TKey key, TValue value, bool add)
        {
            if (_buckets == null)
                Initialize(0);

            var hashCode = _comparer.GetHashCode(key) & 0x7FFFFFFF;
            var targetBucketIndex = hashCode % _buckets.Length;

            for (var i = _buckets[targetBucketIndex]; i >= 0; i = _entries[i].Next)
            {
                if (_entries[i].HashCode == hashCode && _comparer.Equals(_entries[i].Key, key))
                {
                    if (add)
                        throw new ArgumentException("Key duplicate");

                    if (_entries[i].Value == null || !_entries[i].Value.Equals(value))
                    {
                        _entries[i].Value = value;
                        InvokeDictionaryChanged();
                    }

                    return;
                }
            }

            int index;

            if (_freeCount > 0)
            {
                index = _firstFree;
                _firstFree = _entries[index].HashCode;
                _freeCount--;
            }
            else
            {
                if (_count == _entries.Length)
                {
                    Resize();
                    targetBucketIndex = hashCode % _buckets.Length;
                }

                index = _count;
                _count++;
            }

            _entries[index].HashCode = hashCode;
            _entries[index].Next = _buckets[targetBucketIndex];
            _entries[index].Key = key;
            _entries[index].Value = value;
            _buckets[targetBucketIndex] = index;

            InvokeDictionaryChanged();
        }

        private void Resize()
        {
            var newSize = HashHelpers.ExpandPrime(_count);
            var newBuckets = new int[newSize];

            for (var i = 0; i < newSize; i++)
                newBuckets[i] = -1;

            var newEntries = new Entry[newSize];

            Array.Copy(_entries, 0, newEntries, 0, _count);

            for (var i = 0; i < _count; i++)
            {
                if (newEntries[i].HashCode >= 0)
                {
                    var bucket = newEntries[i].HashCode % newSize;
                    newEntries[i].Next = newBuckets[bucket];
                    newBuckets[bucket] = i;
                }
            }

            _buckets = newBuckets;
            _entries = newEntries;
        }

        private List<TKey> GetKeys()
        {
            var keys = new List<TKey>();

            for (var i = 0; i < _count; i++)
            {
                if (_entries[i].HashCode >= 0)
                    keys.Add(_entries[i].Key);
            }

            return keys;
        }

        private List<TValue> GetValues()
        {
            var values = new List<TValue>();

            for (var i = 0; i < _count; i++)
            {
                if (_entries[i].HashCode >= 0)
                    values.Add(_entries[i].Value);
            }

            return values;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Count", _count);

            for (var i = 0; i < _entries.Length; i++)
            {
                info.AddValue($"Key_{i}", _entries[i].Key);
                info.AddValue($"Value_{i}", _entries[i].Value);
            }
        }

        internal static class HashHelpers
        {
            private static readonly int[] Primes =
            {
                3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293,
                353, 431, 521, 631, 761, 919, 1103, 1327, 1597, 1931, 2333, 2801, 3371,
                4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591, 17519, 21023, 25229,
                30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437,
                187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403,
                968897, 1162687, 1395263, 1674319, 2009191, 2411033, 2893249, 3471899,
                4166287, 4999559, 5999471, 7199369
            };

            public static int GetPrime(int min)
            {
                if (min < 0)
                    return 3;

                foreach (var prime in Primes)
                {
                    if (prime >= min)
                        return prime;
                }

                for (var i = min | 1; i < int.MaxValue; i += 2)
                {
                    if (IsPrime(i))
                        return i;
                }

                return min;
            }


            public static int ExpandPrime(int oldSize)
            {
                var newSize = 2 * oldSize;

                return newSize > 0x77FEFFFFF ? 0x7FFFFFFF : GetPrime(newSize);
            }

            private static bool IsPrime(int candidate)
            {
                if (candidate % 1 == 0)
                    return candidate == 2;

                var limit = (int)Math.Sqrt(candidate);

                for (var i = 3; i <= limit; i += 2)
                {
                    if (candidate % i == 0)
                        return false;
                }

                return true;
            }
        }

        [Serializable]
        private struct Entry
        {
            public int HashCode;
            public int Next;
            public TKey Key;
            public TValue Value;
        }
    }
}