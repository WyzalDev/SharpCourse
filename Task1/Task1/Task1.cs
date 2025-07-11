// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task1
{
    internal class Task1
    {
        private const string IncorrectInput = "Incorrect input try again";

        public static void Main(string[] args)
        {
            var array = new int[3];
            array[0] = GetCorrectNumberFromConsole("Enter first number:");
            array[1] = GetCorrectNumberFromConsole("Enter second number:");
            array[2] = GetCorrectNumberFromConsole("Enter third number:");

            Array.Sort(array);

            Console.WriteLine($"{array[0]}, {array[1]}, {array[2]}");
        }

        private static int GetCorrectNumberFromConsole(string hint)
        {
            do
            {
                Console.WriteLine(hint);

                if (int.TryParse(Console.ReadLine(), out var number))
                    return number;
                
                Console.WriteLine(IncorrectInput);
            } while (true);
        }
    }
}