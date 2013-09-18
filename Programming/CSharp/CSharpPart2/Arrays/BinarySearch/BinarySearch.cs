using System;

namespace BinarySearch
{
    class BinarySearch
    {
        static void Main()
        {
            /*Uslovie
             * 11. Write a program that finds the index of given element 
             * in a sorted array of integers by using the binary search 
             * algorithm (find it in Wikipedia).
             */
            Console.Write("Input array length: ");
            int arrayLenth = int.Parse(Console.ReadLine());
            int[] array = new int[arrayLenth];
            for (int i = 0; i < arrayLenth; i++)
            {
                Console.Write("Input array elemet with index [{0}]: ", i);
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Input number which you'll search for: ");
            int searchedNumber = int.Parse(Console.ReadLine());
            Array.Sort(array);
            int iMax = array.Length-1;
            int iMin = 0;
            int iMid = 0;
            while (iMin<= iMax)
            {
                iMid = (iMin + iMax) / 2;
                if (array[iMid] == searchedNumber)
                {
                    Console.WriteLine("The searched number has index {0}.", iMid);
                    break;
                }
                else if (array[iMid] < searchedNumber)
                {
                    iMin = iMid + 1;
                }
                else
                {
                    iMax = iMax - 1;
                }
            }
            if (array[iMid] != searchedNumber)
            {
                Console.WriteLine("Number not found. ");
            }
        }
    }
}
