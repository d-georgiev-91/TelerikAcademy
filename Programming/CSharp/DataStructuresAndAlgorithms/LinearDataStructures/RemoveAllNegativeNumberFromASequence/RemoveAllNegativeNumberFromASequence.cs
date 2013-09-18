/**
 * 5. Write a program that removes from given sequence all negative numbers.
 */
namespace RemoveAllNegativeNumberFromASequence
{
    using System;
    using System.Collections.Generic;

    public static class RemoveAllNegativeNumberFromASequence
    {
        public static void Main()
        {
            var sequence = ReadSequence();
            RemoveNegativeElements(sequence);

            var output = string.Join(", ", sequence);
            Console.WriteLine(output);
        }

        public static void RemoveNegativeElements(LinkedList<int> sequence)
        {
            var currentItem = sequence.First;
            while (currentItem != null)
            {
                var nextItem = currentItem.Next;
                if (currentItem.Value < 0)
                {
                    sequence.Remove(currentItem);
                }
                currentItem = nextItem;
            }
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
