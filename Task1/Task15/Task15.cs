// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task15
{
    internal class Task15
    {
        private const string IncorrectInput = "Incorrect input try again.";

        private const string Separators = " ,.!?;:\t\n\r\"\'()[]{}/\\|-_=+*&^%$#@~`<>";
        
        public static void Main(string[] args)
        {
            var s = GetCorrectStringFromConsole("Enter string:");
            
            var count = s.Split(Separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length;
            
            Console.WriteLine($"Word count - {count}");
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