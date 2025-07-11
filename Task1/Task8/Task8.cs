// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task8
{
    internal class Task8
    {
        private const string IncorrectInput = "Incorrect input try again. Negative numbers incorrect too";

        private const string Splitter = ", ";

        public static void Main(string[] args)
        {
            var n = GetCorrectNumberFromConsole("Enter array length:");
            var numbers = GenerateRandomArray(n);
            Console.WriteLine($"Generated array with {n} elements: ");
            WriteArray(numbers);
            
            SortNegativeElements(ref numbers);
            
            Console.WriteLine($"Sorted array (only negative numbers) with {n} elements: ");
            WriteArray(numbers);
        }

        private static void SortNegativeElements(ref int[] numbers)
        {
            var negativeNumbers = new List<int>();

            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                    negativeNumbers.Add(numbers[i]);
            }

            negativeNumbers.Sort((x, y) => x - y);
            var j = 0;
            
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] >= 0)
                    continue;
                
                numbers[i] = negativeNumbers[j];
                j++;
            }
        }

        private static void WriteArray(int[] numbers)
        {
            for (var i = 0; i < numbers.Length - 1; i++)
                Console.Write($"{numbers[i]}{Splitter}");

            Console.Write($"{numbers[^1]}\r\n");
        }

        private static int[] GenerateRandomArray(int n)
        {
            var result = new int[n];

            for (var i = 0; i < n; i++)
                result[i] = Random.Shared.Next(-100, 100);

            return result;
        }

        private static int GetCorrectNumberFromConsole(string hint)
        {
            do
            {
                Console.WriteLine(hint);

                if (int.TryParse(Console.ReadLine(), out var number) && number >= 0)
                    return number;
                
                Console.WriteLine(IncorrectInput);
            } while (true);
        }
    }
}