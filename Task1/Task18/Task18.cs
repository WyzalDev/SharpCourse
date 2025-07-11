// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task18
{
    internal class Task18
    {
        private const string IncorrectInput = "Incorrect input try again.";

        private const string Separators = " ,.!?;:\t\n\r\"\'()[]{}/\\|-_=+*&^%$#@~`<>";

        public static void Main(string[] args)
        {
            var s = GetCorrectStringFromConsole("Enter string:");
            var words = s.Split(Separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var wordsStartsWithKCount = CountWordsBeginsWith(words, 'K');

            Console.WriteLine($"Words starts with \'K\' symbol count - {wordsStartsWithKCount}");
        }

        private static int CountWordsBeginsWith(string[] words, char beginWithSymbol)
        {
            var count = 0;

            foreach (var word in words)
            {
                if (word.StartsWith(beginWithSymbol))
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