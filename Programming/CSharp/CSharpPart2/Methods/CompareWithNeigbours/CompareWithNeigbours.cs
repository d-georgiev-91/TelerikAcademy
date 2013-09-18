using System;

namespace CompareWithNeigbours
{
    class CompareWithNeigbours
    {
        /*
         * 5. Write a method that checks if the element at given position in given 
         * array of integers is bigger than its two neighbors (when such exist).
         */
        static bool BiggerThanNeigbours(int[] array, int index)
        {
            if (index == 0)
            {
                return array[index] > array[index + 1];
            }
            else if (index == array.Length - 1)
            {
                return array[index] > array[index - 1];
            }
            else
            {
                return (array[index] > array[index - 1]) && (array[index] > array[index + 1]);
            }
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
            Console.Write("Input elemnt index to compare: ");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine(BiggerThanNeigbours(array, index));
        }
    }
}
