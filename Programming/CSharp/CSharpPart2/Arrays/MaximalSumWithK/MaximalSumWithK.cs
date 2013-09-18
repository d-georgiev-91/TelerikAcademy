using System;

namespace MaximalSum
{
    class MaximalSumWithK
    {
        static void Main()
        {
            /* 6. Write a program that reads two integer numbers N and 
             * K and an array of N elements from the console.
             * Find in the array those K elements that have maximal sum.*/
            int n = 0;
            int k = 1;
            while (n < k)
            {
                Console.WriteLine("Input K<N.");
                Console.Write("Input N: ");
                n = int.Parse(Console.ReadLine());
                Console.Write("Input K: ");
                k = int.Parse(Console.ReadLine());
            }
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Input array element: ");
                a[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(a);
            Console.Write("The elements with maximal sum are: ");
            for (int i = n-k; i < n; i++)
            {
                if (i == (n - 1))
                {
                    Console.WriteLine(a[i] + ".");
                }
                else
                {
                    Console.Write(a[i] + ", ");   
                }
            }
        }
    }
}
