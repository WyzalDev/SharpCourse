// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task7
{
    internal class Task7
    {
        private const string IncorrectInput = "Incorrect input try again. Negative numbers incorrect too";

        private const string Splitter = ", ";

        public static void Main(string[] args)
        {
            var n = GetCorrectNumberFromConsole("Enter array length:");
            var numbers = GenerateRandomArray(n);
            WriteArray(n, numbers);
            
            var sum = EvenAndOddPositionsSum(numbers);
            
            Console.WriteLine($"Even numbers sum: {sum.Item1}\n\r Odd Numbers sum: {sum.Item2}");
        }

        private static (long, long) EvenAndOddPositionsSum(int[] numbers)
        {
            var result = (0L, 0L);

            for (var i = 0; i < numbers.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                    result.Item1 += numbers[i];
                else
                    result.Item2 += numbers[i];
            }

            return result;
        }

        private static void WriteArray(int n, int[] numbers)
        {
            Console.WriteLine($"Generated array with {n} elements: ");

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