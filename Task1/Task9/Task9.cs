// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task9
{
    internal class Task9
    {
        private const string IncorrectInput = "Incorrect input try again. Negative numbers incorrect too";

        private const string Splitter = ", ";

        public static void Main(string[] args)
        {
            var n = GetCorrectNumberFromConsole("Enter array length:");
            var numbers = GenerateRandomArray(n);
            Console.WriteLine($"Generated array with {n} elements: ");
            WriteArray(numbers);
            
            SwapElements(ref numbers);
            
            Console.WriteLine($"Transformed array with {n} elements, where mirror(e.g. first and last) pairs swaps:");
            WriteArray(numbers);
        }

        private static void SwapElements(ref int[] numbers)
        {
            for (var i = 0; i < numbers.Length / 2; i++)
                (numbers[i], numbers[numbers.Length - 1 - i]) = (numbers[numbers.Length - 1 - i], numbers[i]);
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