namespace RisksWinLoses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RisksWinLoses
    {
        static void Main()
        {
            string startCombination = Console.ReadLine();
            string endCombination = Console.ReadLine();
            List<string> forbiddenCombinations = new List<string>();
            int forbiddenCombinationsCount = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < forbiddenCombinationsCount; i++)
            {
                forbiddenCombinations.Add(Console.ReadLine());
            }

            int count = 0;

            for (int i = 0; i < startCombination.Length; i++)
            {
                int startDigit = startCombination[i] - '0';
                int endDigit = endCombination[i] - '0';

                count += Math.Min(Math.Abs(startDigit - endDigit), 10 - Math.Abs(startDigit - endDigit));
            }

            Console.WriteLine(count);
        }
    }
}