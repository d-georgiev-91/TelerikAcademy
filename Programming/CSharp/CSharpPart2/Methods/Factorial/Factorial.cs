using System;
using System.Numerics;

namespace Factorial
{
    class Factorial
    {
        static BigInteger NFactorial(int n)
        {
            /* 10. Write a program to calculate n! for each n in the range [1..100]. 
             * Hint: Implement first a method that multiplies a number represented as 
             * array of digits by given integer number.*/
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
        static void Main()
        {
            int n = 0;
            while (n<1 || n > 100)
            {
                Console.Write("Input n in [1,100]: ");
                n = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("{0}! is {1}.", n, NFactorial(n));
        }
    }
}
