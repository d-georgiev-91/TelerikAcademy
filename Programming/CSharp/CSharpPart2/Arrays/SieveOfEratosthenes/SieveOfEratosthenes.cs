using System;

namespace SieveOfEratosthenes
{
    class SieveOfEratosthenes
    {
        static void Main()
        {
            /*Uslovie
             * 15. Write a program that finds all prime numbers in the range [1...10 000 000].
             * Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
             */
            bool [] array = new bool[10000000];
            for (int i = 2; i < array.Length; i++)
            {
                array[i] = true;
            }
            for (int i = 2; i*i < array.Length; i++)
            {
                if (array[i])
                {
                    for (int j = i; i * j < array.Length; j++)
                    {
                        array[i * j] = false;
                    }   
                }
            }
            for (int i = 2; i < array.Length; i++)
            {
                if (array[i])
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
