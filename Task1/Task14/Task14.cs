// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task14
{
    internal class Task14
    {
        private const string IncorrectInput = "Incorrect input try again.";

        public static void Main(string[] args)
        {
            var s = GetCorrectStringFromConsole("Enter string:");
            
            Console.WriteLine($"\"A\" symbols count - {CountSymbol(s, 'A')}");
        }

        private static int CountSymbol(string s, char c)
        {
            var count = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                    count++;
            }

            return count;
        }

        private static string GetCorrectStringFromConsole(string hint)
        {
            Console.WriteLine(hint);

            string? input;

            do
            {
                input = Console.ReadLine();

                if (input is not null)
                    return input;

                Console.WriteLine(IncorrectInput);
            } while (true);
        }
    }
}