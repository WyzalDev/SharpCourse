// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Text;

namespace Task3
{
    public static class DefaultInputs
    {
        public const string IncorrectInput = "Incorrect input try again. Negative numbers incorrect too.";
        public const string IncorrectChoiceAddition = "Or choice was incorrect.";
        public const string EnterChoice = "Enter your choice:";
        public const string EnterCity = "Enter City from keyboard.";

        public static string GetCorrectStringFromConsole(string hint)
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

        public static int GetCorrectNumberFromConsole(string hint, int from, int to)
        {
            do
            {
                Console.WriteLine(hint);
                
                if (int.TryParse(Console.ReadLine(), out var number) 
                    && number >= 0 && number >= from && number <= to)
                    return number;

                var s = new StringBuilder(IncorrectInput);
                s.AppendLine(IncorrectChoiceAddition);
                Console.WriteLine(s);
            } while (true);
        }
    }
}