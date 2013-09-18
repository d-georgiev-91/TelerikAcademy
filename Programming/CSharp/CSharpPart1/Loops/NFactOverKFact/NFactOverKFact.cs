using System;
using System.Numerics;

class NFactOverKFact
{
    static void Main()
    {
        uint n = 0, k = 0;
        while ( k <= 1 || n <= k)
        {
            Console.WriteLine("1<K<N");
            Console.Write("Input N: ");
            n = uint.Parse(Console.ReadLine());
            Console.Write("Input K: ");
            k = uint.Parse(Console.ReadLine());
        }
        BigInteger result = 1;
        for (uint i = k + 1; i <= n; i++)
        {
            result *= i;
        }
        Console.WriteLine(result);
    }
}