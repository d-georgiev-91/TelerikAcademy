/**
 * Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
 * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
 * 2 -> 2 times
 * 3 -> 4 times
 * 4 -> 3 times
 */

namespace AllElementsOccuranceInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class AllElementsOccuranceInArray
    {
        static void Main()
        {
            List<int> array = ReadArray();
            Dictionary<int, int> elementsCountOccurance = CountElementsOccurance(array);
            foreach (var key in elementsCountOccurance.Keys)
            {
                Console.WriteLine("{0} -> {1}", key, elementsCountOccurance[key]);
            }
        }

        public static Dictionary<int, int> CountElementsOccurance(List<int> sequence)
        {
            Dictionary<int, int> elementsCountOccurance = new Dictionary<int, int>();

            foreach (var item in sequence)
            {
                if (elementsCountOccurance.ContainsKey(item))
                {
                    elementsCountOccurance[item]++;
                }
                else
                {
                    elementsCountOccurance.Add(item, 1);
                }
            }

            return elementsCountOccurance;
        }

        private static List<int> ReadArray()
        {
            List<int> sequence = new List<int>();
            string line;

            while (true)
            {
                Console.Write("Enter a number: ");
                line = Console.ReadLine();
                if (line == string.Empty)
                {
                    break;
                }

                int number = 0;

                try
                {
                    number = int.Parse(line);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a valid number!");
                    continue;
                }

                sequence.Add(number);
            }

            return sequence;
        }
    }
}