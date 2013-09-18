/** 
 * 8.* The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
 * Write a program to find the majorant of given array (if exists). Example:
 * {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3
 */

namespace MajorantOfArray
{
    using System;
    using System.Collections.Generic;

    public static class MajorantOfArray
    {
        static void Main()
        {
            List<int> array = ReadArray();
            int? arrayMajorant = GetArrayMajorant(array);
        }

        public static int? GetArrayMajorant(List<int> array)
        {
            int? majorant = null;
            int marojantAppearance = array.Count / 2 + 1;
            var eachElementOccurance = CountElementsOccurance(array);

            foreach (var element in eachElementOccurance.Keys)
            {
                if (eachElementOccurance[element] == marojantAppearance)
                {
                    majorant = element;
                }
            }

            return majorant;
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

        private static Dictionary<int, int> CountElementsOccurance(List<int> sequence)
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
    }
}
