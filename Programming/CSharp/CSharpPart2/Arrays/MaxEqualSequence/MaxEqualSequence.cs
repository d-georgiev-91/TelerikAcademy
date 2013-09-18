using System;

namespace MaxEqualSequence
{
    class MaxEqualSequence
    {
        static void Main()
        {
            /*Uslovie 
             * 4. Write a program that finds the maximal sequence of equal elements in an array.
        	 * Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.
            */
            Console.Write("Input lenght of the sequence: ");
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
                if (sequence[i - 1] != sequence[i])
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
                Console.WriteLine("There is no maximal sequence of equal elements.");
            }
            else
            {
                Console.Write("The maximal sequence of equal elements is: {");
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
