using System;

namespace VariatonsOfKElements
{
    /*
     *  20. Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. Example:
	    N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
     */
    class VariatonsOfKElements
    {
        static void Variation(int [] array, int n, int i)
        {
            if (i == array.Length)
            {
                Console.Write("{ ");
                for (int j = 0; j < array.Length; j++)
                {
                    if (j != array.Length-1)
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
                for (int j = 1; j <= n; j++)
                {
                    array[i] = j;
                    Variation(array, n, i + 1);
                }
            }
        }
        static void Main()
        {
            /*
             * 20. Write a program that reads two numbers N and K and generates all 
             * the variations of K elements from the set [1..N]. Example:
               N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
             */
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
            int[] variations = new int[k];
            Variation(variations, n, 0);
        }
    }
}