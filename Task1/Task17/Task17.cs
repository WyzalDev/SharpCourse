// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task17
{
    internal class Task17
    {
        private const string IncorrectInput = "Incorrect input try again.";

        public static void Main(string[] args)
        {
            var s = GetCorrectStringFromConsole("Enter string:");
            
            Console.WriteLine("Changed symbols \'C\' on symbol \'E\'");
            Console.WriteLine($"{s.Replace('C', 'E')}");
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