// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Numerics;

namespace Task3
{
    internal class Task3
    {
        private const string IncorrectInput = "Incorrect input try again. Negative numbers incorrect too";

        public static void Main(string[] args)
        {
            var n = GetCorrectNumberFromConsole("Enter number:");

            if (n <= 20)
                Console.WriteLine(Factorial(n));
            else
                Console.WriteLine(BigFactorial(n));
        }

        private static long Factorial(int n)
        {
            var result = 1L;

            for (var i = 2; i <= n; i++)
                result *= i;

            return result;
        }

        private static BigInteger BigFactorial(int n)
        {
            BigInteger result = 1;

            for (var i = 2; i <= n; i++)
                result *= i;

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