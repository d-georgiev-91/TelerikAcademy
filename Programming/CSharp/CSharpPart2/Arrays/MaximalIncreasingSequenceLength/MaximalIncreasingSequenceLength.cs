using System;

namespace MaximalIncreasingSequenceLength
{
    class MaximalIncreasingSequenceLength
    {
        static void Main()
        {
            /*Uslovie
             *5. Write a program that finds the maximal increasing sequence in an array. 
             *Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.
            */
            Console.Write("Input length of the sequence: ");
            int sequenceLength = int.Parse(Console.ReadLine());
            int[] sequence = new int[sequenceLength];
            for (int i = 0; i < sequenceLength; i++)
            {
                Console.Write("Input element in sequence: ");
                sequence[i] = int.Parse(Console.ReadLine());
            }
            int equalSequenceLength = 1;
            int equalSequenceBeginning = 0;
            int maxSequenceLength = 1;
            int maxSequenceBeginning = 0;
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i - 1] >= sequence[i])
                {
                    equalSequenceLength = 1;
                    equalSequenceBeginning = i;
                }
                else
                {
                    equalSequenceLength++;
                    if (equalSequenceLength > maxSequenceLength)
                    {
                        maxSequenceLength = equalSequenceLength;
                        maxSequenceBeginning = equalSequenceBeginning;
                    }
                }
            }
            if (maxSequenceLength == 1)
            {
                Console.WriteLine("There is no maximal sequence of icnreasing elements.");
            }
            else
            {
                Console.Write("The maximal sequence of icnreasing elements is: {");
                for (int i = maxSequenceBeginning; i < maxSequenceBeginning + maxSequenceLength; i++)
                {
                    if (i < maxSequenceLength + maxSequenceBeginning - 1)
                    {
                        Console.Write(sequence[i] + ", ");
                    }
                    else
                    {
                        Console.WriteLine(sequence[i] + "}");
                    }
                }
            }
        }
    }
}