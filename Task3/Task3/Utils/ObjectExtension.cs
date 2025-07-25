// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task3.Utils
{
    public static class ObjectExtension
    {
        public static byte[] GetBytes(this object data)
        {
            var formatter = new BinaryFormatter();
            using var stream = new MemoryStream();

            formatter.Serialize(stream, data);

            return stream.ToArray();
        }

        public static object GetData(this byte[] data)
        {
            var formatter = new BinaryFormatter();
            using var stream = new MemoryStream(data);

            return formatter.Deserialize(stream);
        }
    }
}