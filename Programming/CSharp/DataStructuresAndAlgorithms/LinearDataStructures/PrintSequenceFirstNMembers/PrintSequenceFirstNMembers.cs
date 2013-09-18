namespace PrintSequenceFirstNMembers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PrintSequenceFirstNMembers
    {
        public const int sequenceLength = 50;

        static void Main()
        {
            Console.Write("Enter a sequence beginning: ");
            int sequenceBeginning = int.Parse(Console.ReadLine());
            var sequenceMembers = GetSequenceFirstNMembers(sequenceBeginning, sequenceLength);
            var output = string.Join(", ", sequenceMembers);
            Console.WriteLine(output);
        }

        public static List<int> GetSequenceFirstNMembers(int beginning, int length)
        {
            List<int> sequence = new List<int>();
            Queue<int> queue = new Queue<int>();

            // Adding Si to queue
            queue.Enqueue(beginning);

            for (int i = 1; i <= length; i++)
            {
                beginning = queue.Dequeue();

                // Assigning Si to list which is used to hold and later on printing the sequence members
                sequence.Add(beginning);

                // Calculating the S(i+1)
                queue.Enqueue(beginning + 1);
                // Calculating the S(i+2)
                queue.Enqueue(2 * beginning + 1);
                // Calculating the S(i+3)
                queue.Enqueue(beginning + 2);
            }

            return sequence;
        }
    }
}