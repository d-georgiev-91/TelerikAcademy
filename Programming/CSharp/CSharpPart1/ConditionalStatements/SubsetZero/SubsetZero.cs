using System;
using System.Diagnostics;
using System.IO;

class SubsetZero
{
    static void Main()
    {
        int a, b, c, d, e;
        Console.Write("Input first number: ");
        a = int.Parse(Console.ReadLine());
        Console.Write("Input second number: ");
        b = int.Parse(Console.ReadLine());
        Console.Write("Input third number: ");
        c = int.Parse(Console.ReadLine());
        Console.Write("Input fourth number: ");
        d = int.Parse(Console.ReadLine());
        Console.Write("Input fifth number: ");
        e = int.Parse(Console.ReadLine());
        if (a + b + c + d + e == 0)
        {
            Console.WriteLine("There is some subset with sum 0.");
        }
        else if ((a + b + c + d == 0) || (a + b + c + e == 0) || (a + b + d + e == 0) || (b + c + d + e == 0) || (a + c + d + e == 0))
        {
            Console.WriteLine("There is some subset with sum 0.");
        }
        else if ((a + b + c == 0) || (a + b + d == 0) || (a + b + e == 0) || (a + c + d == 0) || (a + c + e == 0) || (a + d + e == 0) || (b + c + d == 0) || (b + c + e == 0) || (b + d + e == 0) || (c + d + e == 0))
        {
            Console.WriteLine("There is some subset with sum 0.");
        }
        else if ((a + b == 0) || (a + c == 0) || (a + d == 0) || (a + e == 0) || (b + c == 0) || (b + d == 0) || (b + e == 0) || (c + d == 0) || (c + e == 0) || (d + e == 0))
        {
            Console.WriteLine("There is some subset with sum 0.");
        }
        else if ((a == 0) || (b == 0) || (c == 0) || (d == 0) || (e == 0))
        {
            Console.WriteLine("There is some subset with sum 0.");
        }
        else
        {
            Console.WriteLine("There is no subset with sum 0.");
        }
    }
}