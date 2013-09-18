using System;

class PrintNumbers1toN
{
    static void Main()
    {
        Console.Write("Input a number: ");
        uint n = uint.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("N= " + i);
        }
    }
}