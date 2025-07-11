// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task10
{
    internal class Task10
    {
        private const string IncorrectInput = "Incorrect input try again. Negative numbers incorrect too. ";
        
        private const string Splitter = ", ";

        public static void Main(string[] args)
        {
            var length = GetCorrectNumberFromConsole("Enter array length:");
            var n = GetCorrectNumberFromConsole("Enter number N:");
            var m = GetCorrectNumberFromConsole("Enter number M:");
            var numbers = GenerateRandomArray(n);
            Console.WriteLine($"Generated array with {length} elements: ");
            WriteArray(numbers);

            var greaterLessSum = GreaterLessSum(m, n, numbers);
            
            Console.WriteLine($"Sum of elements greater than {m} and less than {n}: {greaterLessSum}");
        }

        private static int GreaterLessSum(int upperBound, int lowerBound, int[] numbers)
        {
            var result = 0;

            foreach (var t in numbers)
            {
                if (t > lowerBound && t < upperBound)
                    result += t;
            }

            return result;
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