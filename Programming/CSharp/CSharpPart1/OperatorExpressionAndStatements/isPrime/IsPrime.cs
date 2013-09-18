using System;

class IsPrime
{
    static void Main()
    {
        int n = 0;
        bool isPrime = true;
        while (n < 1 || n > 100)
        {
            Console.Write("Input number positive number lower or equal to 100: ");
            n = int.Parse(Console.ReadLine());
        }
        int divider = 2;
        while(isPrime && (divider*divider <= n) )
        {
            isPrime = n % divider != 0;
            divider++;
        }
        Console.WriteLine(isPrime);
    }
}
