// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task2
{
    internal class Task2
    {
        private const string IncorrectInput = "Incorrect input try again";
        private const string ValidationError = "While reversing number, discovered that in argument was not a number";

        public static void Main(string[] args)
        {
            var numberAsCharArray = GetCorrectNumberFromConsoleAsString("Enter number:").ToCharArray();
            
            if (ReverseNumberAlsoForNegatives(ref numberAsCharArray))
                Console.WriteLine(numberAsCharArray);
            else
                Console.WriteLine(ValidationError);
        }

        private static bool ReverseNumberAlsoForNegatives(ref char[] number)
        {
            if (!int.TryParse(number, out var numberInt))
                return false;

            if (number[0] == '-')
                Array.Reverse(number, 1, number.Length - 1);
            else
                Array.Reverse(number);

            return true;
        }

        private static string GetCorrectNumberFromConsoleAsString(string hint)
        {
            string? input;

            do
            {
                Console.WriteLine(hint);
                input = Console.ReadLine();

                if (input != null && int.TryParse(input, out var number))
                    return input;

                Console.WriteLine(IncorrectInput);
            } while (true);
        }
    }
}