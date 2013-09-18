using System;

namespace SequenceWithSum
{
    class SequenceWithSum
    {
        static void Main()
        {
            /* Uslovie
             * 10. Write a program that finds in given array of integers a sequence of given sum S (if present). 
             * Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}	
             */
            Console.Write("Input array length: ");
            int arrayLenth = int.Parse(Console.ReadLine());
            int[] array = new int[arrayLenth];
            for (int i = 0; i < arrayLenth; i++)
            {
                Console.Write("Input array elemet: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Input S: ");
            int s = int.Parse(Console.ReadLine());
            int sum = 0;
            int sequenceBeninning = 0;
            int sequenceEnd = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum = 0;
                for (int j = i; j < array.Length ; j++)
                {
                    sum += array[j];
                    if (s == sum)
                    {
                        sequenceBeninning = i;
                        sequenceEnd = j;
                        j = i = array.Length - 1; //breaking the inner and outer loop
                    }
                    else
                    {
                        sequenceBeninning = -1;
                        sequenceEnd = -1;
                    }
                }
            }
            if (sequenceBeninning != -1 && sequenceEnd != -1 && sequenceBeninning < sequenceEnd)
            {
                Console.Write("The is at least one sequnece with sum {0} with elemnts: ", s);
                for (int i = sequenceBeninning; i <= sequenceEnd; i++)
                {
                    if (i == sequenceEnd)
                    {
                        Console.WriteLine(array[i] + ". ");
                    }
                    else
                    {
                        Console.Write(array[i] + ", ");
                    }
                }
            }
            else
            {
                Console.WriteLine("No such sequence.");
            }
        }
    }
}
