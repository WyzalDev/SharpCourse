// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

namespace Task6
{
    internal class Task6
    {
        private const string IncorrectInput = "Incorrect input try again. Negatives incorrect too";

        private const string Splitter = ", ";

        public static void Main(string[] args)
        {
            var perfectNumbers = GetPerfectNumbers(GetCorrectNumberFromConsole("Enter X number:"));

            foreach (var perfectNumber in perfectNumbers)
            {
                Console.Write($"{perfectNumber}");
                
                if (perfectNumber == perfectNumbers[^1])
                    break;
                
                Console.Write(Splitter);
            }
        }

        private static long[] GetPerfectNumbers(long x)
        {
            var result = new List<long>();
            
            for (var i = 6; i <= x; i++)
            {
                if (Sum(GetDivisors(i)) == i)
                    result.Add(i);
            }

            return result.ToArray();
        }

        private static long Sum(long[] numbers)
        {
            var result = 0L;
            
            foreach (var number in numbers)
                result += number;

            return result;
        }

        private static long[] GetDivisors(long x)
        {
            if (x == 0)
                return [];
            
            if (x == 1)
                return [1];

            var divisors = new List<long>();

            for (var i = 1; i * i <= x; i++)
            {
                if (x % i == 0)
                {
                    divisors.Add(i);
                    
                    if (i != x * i && x != x * i)
                        divisors.Add(x / i);
                }
            }

            return divisors.ToArray();
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