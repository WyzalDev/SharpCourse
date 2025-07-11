// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task5
{
    internal class Task5
    {
        private const string IncorrectInput = "Incorrect input try again. Negatives incorrect too";

        private const string Splitter = ", ";

        public static void Main(string[] args)
        {
            PrintEvenNumbers(GetCorrectNumberFromConsole("Enter X number:"));
        }

        private static void PrintEvenNumbers(int x)
        {
            for (var i = 0; i <= x; i += 2)
            {
                Console.Write(i);
                
                if (i == x || i + 1 == x)
                    break;
                
                Console.Write(Splitter);
            }
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