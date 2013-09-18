// 3. Write a program that reads a sequence of integers (List<int>) 
// ending with an empty line and sorts them in an increasing order.

namespace SortingListOfIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SortingListOfIntegers
    {
        static void Main()
        {
            List<int> sequence = ReadSequence();
            SortSequence(sequence);
            var output = string.Join(", ", sequence);
            Console.WriteLine(output);
        }

        private static void SortSequence(List<int> sequence)
        {
            if (sequence.Count == 0 || sequence == null)
            {
                throw new InvalidOperationException("Sequence cannot be sorted it's empty or null!");    
            }

            sequence.Sort((x, y) => x.CompareTo(y));
        }

        private static List<int> ReadSequence()
        {
            List<int> sequence = new List<int>();
            string line;

            while (true)
            {
                Console.Write("Enter positive number: ");
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