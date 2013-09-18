using System;
using System.Numerics;

class CatalanNumbers
{
    public static BigInteger Factorial(int n)
    {
        BigInteger result = 1;
        for (BigInteger i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
    static void Main()
    {
        Console.Write("Input N(must be equal or greater than 0): ");
        int n = -1;
        while (n < 0)
        {
            n = int.Parse(Console.ReadLine());
        }
        BigInteger catalanNumber;
        catalanNumber = Factorial(2*n)/(Factorial(n + 1)*Factorial(n));
        Console.WriteLine("The {0} Catalan number is {1}", n, catalanNumber);
    }
}
