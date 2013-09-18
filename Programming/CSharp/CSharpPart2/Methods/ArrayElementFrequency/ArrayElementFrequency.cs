using System;

namespace ArrayElementFrequency
{
    class ArrayElementFrequency
    {
        /*
         * 4.Write a method that counts how many times given number appears in given array.
         * Write a test program to check if the method is working correctly.
         */
        static int Frequency(int [] array, int number)
        {
            int frequency = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    frequency++;
                }
            }
            return frequency;
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
            Console.Write("Input number to search for: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("The number appears {0} times in the array.", Frequency(array, number));
        }
    }
}
