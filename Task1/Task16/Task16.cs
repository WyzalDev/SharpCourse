// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task16
{
    internal class Task16
    {
        private const string IncorrectInput = "Incorrect input try again.";

        public static void Main(string[] args)
        {
            var s = GetCorrectStringFromConsole("Enter string:").ToCharArray();
            
            Array.Reverse(s);
            
            Console.WriteLine(s);
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