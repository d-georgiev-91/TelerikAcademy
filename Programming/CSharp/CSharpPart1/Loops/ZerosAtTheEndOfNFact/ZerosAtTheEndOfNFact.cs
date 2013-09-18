using System;
using System.Numerics;

class ZerosAtTheEndOfNFact
{
    public static int Power(int nubmer, int power)
    {
        int result = 1;
        for (int i = 1; i <= power; i++)
			{
			    result *= nubmer;
			}
        return result;
    }
    static void Main()
    {
        Console.Write("Input N: ");
        int n = int.Parse(Console.ReadLine());
        int countZeros = 0;
        int power = 1;
        while (n/Power(5, power) != 0)
        {
            countZeros += n / Power(5, power);
            power++;
        }
        Console.WriteLine(countZeros);
    }
}