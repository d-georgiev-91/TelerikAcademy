using System;

namespace MaxElementInPortion
{
    class MaxElementInPortion
    {
        /* 9. Write a method that return the maximal element in a portion of array 
         * of integers starting at given index. Using it write another method that 
         * sorts an array in ascending / descending order. */
        static void Sort(int [] array, int reverse)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Swap(array, i,  MaxInPortion(array, i));
            }
            if (reverse == 1)
            {
                Array.Reverse(array);
            }
        }

        static void Swap(int [] array, int i, int j)
        {
            int swap = array[i];
            array[i] = array[j];
            array[j] = swap;
        }
        static int MaxInPortion(int[] array, int indexStart)
        {
            int max = indexStart;
            for (int i = indexStart + 1; i < array.Length; i++)
            {
                if (array[i] > array[max])
                {
                    max = i;
                }
            }
            return max;
        }
        static void Main()
        {
            Console.Write("Input array size: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Input array element: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("For ascending sort input (1), for descending (2): ");
            int sort = int.Parse(Console.ReadLine());
            Sort(array, sort);
            Console.WriteLine("The sorted array for your option is.. ");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
