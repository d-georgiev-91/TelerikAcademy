/**
 *  6. Write a program that removes from given sequence all 
 *  numbers that occur odd number of times. 
 *  Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}
 */
namespace RemoveOddOccuranceOfNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class RemoveOddOccuranceOfNumber
    {
        public static void RemoveOddElements(LinkedList<int> sequence)
        {
            Dictionary<int, int> elementsCountOccurance = CountElementsOccurance(sequence);

            var currentItem = sequence.First;
            while (currentItem != null)
            {
                var nextItem = currentItem.Next;
                
                if (elementsCountOccurance[currentItem.Value] % 2 != 0)
                {
                    sequence.Remove(currentItem);
                }

                currentItem = nextItem;
            }
        }

        private static Dictionary<int, int> CountElementsOccurance(LinkedList<int> sequence)
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

        public static void Main()
        {
            var sequence = ReadSequence();
            RemoveOddElements(sequence);

            var output = string.Join(", ", sequence);
            Console.WriteLine(output);
        }

        private static LinkedList<int> ReadSequence()
        {
            LinkedList<int> sequence = new LinkedList<int>();
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

                sequence.AddLast(number);
            }

            return sequence;
        }
    }
}