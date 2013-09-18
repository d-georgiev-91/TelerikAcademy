using System;

class SequenceSumCalculator
{   
    public static long Factorial(int n)
    {
        long fact = 1;
        for (int i = 1; i <= n; i++)
        {
            fact *= i;
        }
        return fact;
    }
    public static long Power(int n, int power)
    {
        long result = 1;
        for (int i = 1; i <= power; i++)
        {
            result *= n;   
        }
        return result;
    }
    static void Main()
    {
        int n, x;
        Console.Write("Input N: ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Input X: ");
        x = int.Parse(Console.ReadLine());
        decimal sum = 1;
        for (int i = 1; i <= n; i++)
        {
            sum += (decimal)Factorial(i) / (decimal)Power(x, i);
        }
        Console.WriteLine("The sum is: {0}", sum);
    }
}