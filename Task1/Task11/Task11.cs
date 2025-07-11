// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task11
{
    internal class Task11
    {
        private const string IncorrectInput = "Incorrect input try again. Negative numbers incorrect too";
        
        private const string Splitter = ", ";

        public static void Main(string[] args)
        {
            var n = GetCorrectNumberFromConsole("Enter number of rows in array:");
            var m = GetCorrectNumberFromConsole("Enter number of columns in array:");
            var numbers = GenerateRandomArray(n, m);
            Console.WriteLine($"Generated array with {n} rows and {m} columns: ");
            WriteArray(numbers);

            SwapEvenAndOddRows(ref numbers);

            Console.WriteLine($"Array with {n} rows and {m} columns, where odd and even rows swapped:");
            WriteArray(numbers);
        }

        private static void SwapEvenAndOddRows(ref int[][] numbers)
        {
            for (var i = 0; i < numbers.Length / 2; i++)
                (numbers[i * 2], numbers[(i * 2) + 1]) = (numbers[i * 2 + 1], numbers[(i * 2)]);
        }

        private static void WriteArray(int[][] numbers)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                for (var j = 0; j < numbers[0].Length - 1; j++)
                    Console.Write($"{numbers[i][j]}{Splitter}");

                Console.Write($"{numbers[i][^1]}\r\n");
            }
        }

        private static int[][] GenerateRandomArray(int n, int m)
        {
            var result = new int[n][];

            for (var i = 0; i < n; i++)
            {
                result[i] = new int[m];
                
                for (var j = 0; j < m; j++)
                    result[i][j] = Random.Shared.Next(-100, 100);
            }

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