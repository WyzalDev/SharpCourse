// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task4
{
    internal class Task4
    {
        private const string IncorrectInputNegatives = "Incorrect input try again. Negative numbers incorrect too";
        private const string IncorrectInput = "Incorrect input try again";

        public static void Main(string[] args)
        {
            var x = GetCorrectNumberFromConsole("Enter X number:", true);
            var n = GetCorrectNumberFromConsole("Enter N number:");
            var m = GetCorrectNumberFromConsole("Enter M number:");

            Console.WriteLine(SumWithStep(x, n, m));
        }

        private static long SumWithStep(int x, int n, int m)
        {
            return x * n + (n - 1) * m * n / 2;
        }

        private static int GetCorrectNumberFromConsole(string hint, bool isNegative = false)
        {
            do
            {
                Console.WriteLine(hint);

                if (int.TryParse(Console.ReadLine(), out var number) && (isNegative || number >= 0))
                    return number;

                Console.WriteLine(isNegative ? IncorrectInput : IncorrectInputNegatives);
            } while (true);
        }
    }
}