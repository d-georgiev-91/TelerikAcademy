using System;
using System.Numerics;

class NFactByKFactDividedByKMinusNFact
{
    static void Main()
    {
        uint n = 0, k = 0;
        while (n <= 1 || k <= n)
        {
            Console.WriteLine("1<N<K");
            Console.Write("Input N: ");
            n = uint.Parse(Console.ReadLine());
            Console.Write("Input K: ");
            k = uint.Parse(Console.ReadLine());
        }
        BigInteger result = 1;
        for (uint i = 1; i <= k; i++)
        {
            if (i <= n)
            {
                result *= i;
            }
            else if (i >= k - n + 1)
            {
                result *= i;
            }
        }
        Console.WriteLine(result);
    }
}