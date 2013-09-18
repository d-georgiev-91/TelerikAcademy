using System;

namespace DistinctElemetsOfSet
{
    class DistinctElemetsOfSet
    {
        /*
         * 21. Write a program that reads two numbers N and K and generates all 
         * the combinations of K distinct elements from the set [1..N]. Example:
	     * N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
         */
        static void Combinations(int[] array, int n, int i, int iNext)
        {
            if (i == array.Length)
            {
                Console.Write("{ ");
                for (int j = 0; j < array.Length; j++)
                {
                    if (j != array.Length - 1)
                    {
                        Console.Write("{0}, ", array[j]);
                    }
                    else
                    {
                        Console.Write("{0}", array[j]);
                    }
                }
                Console.WriteLine(" }");
            }
            else
            {
                for (int j = iNext; j <= n; j++)
                {
                    array[i] = j;
                    Combinations(array, n, i + 1, j + 1);
                }
            }
        }
        static void Main()
        {
            int k = 1;
            int n = 0;
            Console.WriteLine("N > 1 and N >= K");
            while (k > n || n <= 1)
            {
                Console.Write("Input N: ");
                n = int.Parse(Console.ReadLine());
                Console.Write("Input K: ");
                k = int.Parse(Console.ReadLine());
            }
            int[] combinations = new int[k];
            Combinations(combinations, n, 0, 1);
        }
    }
}
