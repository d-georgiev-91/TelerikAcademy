using System;

namespace IndexMultiplicationBy5
{
    class IndexMultiplicationBy5
    {
        static void Main()
        {
            /* Uslovie 
             * 1. Write a program that allocates array of 20 integers and initializes each 
             * element by its index multiplied by 5. Print the obtained array on the console.
             */
            int[] array = new int[20];
            for (int i = 0; i < 20; i++)
            {
                array[i] = i * 5;
            }
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("a[{0}]= {1}", i, array[i]);
            }
        }
    }
}