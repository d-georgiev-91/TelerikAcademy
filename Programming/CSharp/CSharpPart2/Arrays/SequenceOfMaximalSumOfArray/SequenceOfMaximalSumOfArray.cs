using System;

namespace SequenceOfMaximalSumOfArray
{
    class SequenceOfMaximalSumOfArray
    {
        static void Main()
        {
            /* Uslovie
             * 8. Write a program that finds the sequence of maximal sum in given array. 
             * Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
	         * Can you do it with only one loop (with single scan through the elements of the array)?
             */
            Console.Write("Input array length: ");
            int arrayLenth = int.Parse(Console.ReadLine());
            int[] array = { 2, 1, -6, -1, 2, -1, 6, 4, -8, 18 };
            int maxSoFar = array[0];
            int maxEndingHere = array[0];
            int maximalSequenceSumBeginning = 0;
            int beginningTemp = 0;
            int maximalSequenceSumEnd = 0;
            for (int i = 1; i < array.Length; i++)
            {
                maxEndingHere += array[i];
                if (array[i] > maxEndingHere)
                {
                    maxEndingHere = array[i];
                    beginningTemp = i;
                }
                if (maxEndingHere > maxSoFar)
                {
                    maxSoFar = maxEndingHere;
                    maximalSequenceSumBeginning = beginningTemp;
                    maximalSequenceSumEnd = i;
                }
            }
            for (int i = maximalSequenceSumBeginning; i <= maximalSequenceSumEnd; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
