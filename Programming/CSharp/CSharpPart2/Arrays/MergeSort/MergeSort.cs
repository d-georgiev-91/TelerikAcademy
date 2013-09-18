using System;

namespace MergeSort
{
    class MergeSort
    {
        /* Uslovie
             * 12. Write a program that creates an array containing all 
             * letters from the alphabet (A-Z). Read a word from the 
             * console and print the index of each of its letters in the array.
        */
        static void Sort(int[] array, int length)
        {
            int[] workArray = new int[length];
            for (int width = 1; width < length; width = 2 * width)
            {
                for (int i = 0; i < length; i = i + 2 * width)
                {
                    Merge(array, i, Math.Min(i + width, length), Math.Min(i + 2 * width, length), workArray);
                }
                Array.Copy(workArray, array, length);
            }
        }
        static void Merge(int[] array, int iLeft, int iRight, int iEnd, int [] workArray)
        {
            int i1 = iLeft;
            int i2 = iRight;
            for (int j = iLeft; j < iEnd; j++)
            {
                if (i1 < iRight && (i2 >= iEnd || array[i1] <= array[i2]))
                {
                    workArray[j] = array[i1];
                    i1++;
                }
                else
                {
                    workArray[j] = array[i2];
                    i2++;
                }
            }
        }
        static void Main()
        {
            Console.Write("Input array length: ");
            int arrayLenth = int.Parse(Console.ReadLine());
            int[] array = new int[arrayLenth];
            for (int i = 0; i < arrayLenth; i++)
            {
                Console.Write("Input array elemet with index [{0}]: ", i);
                array[i] = int.Parse(Console.ReadLine());
            }
            Sort(array, arrayLenth);
            Console.WriteLine("The array sorted...");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
