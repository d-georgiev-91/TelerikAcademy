using System;

namespace LargestNumberLowerThanK
{
    /*
     * 4. Write a program, that reads from the console an array of N integers 
     * and an integer K, sorts the array and using the method Array.BinSearch() 
     * finds the largest number in the array which is ≤ K. 
     */
    class LargestNumberLowerThanK
    {
        static void Main()
        {
            Console.Write("Input array length: ");
            int length = int.Parse(Console.ReadLine());
            int[] array = new int[length];
            Console.Write("Input k: ");
            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                Console.Write("Input array element: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(array);
            if (k < array[0])
            {
                Console.WriteLine("No such number!");
            }
            else
            {
                int number = 0;
                int i = Array.BinarySearch(array, k);
                if (i >= 0)
                {
                    number = array[i];
                }
                else
                { 
                    number = array[i*(-1) - 2]; 
                }
                Console.WriteLine(number);
            }
        }
    }
}
