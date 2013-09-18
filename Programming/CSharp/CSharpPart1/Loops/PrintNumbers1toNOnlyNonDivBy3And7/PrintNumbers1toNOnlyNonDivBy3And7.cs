using System;

class PrintNumbers1toNOnlyNonDivBy3And7
{
    static void Main()
    {
        Console.Write("Input n: ");
        uint n = uint.Parse(Console.ReadLine());
        for (int i = 1; i <=n ; i++)
        {
            if (i % 3 != 0 && i % 7 != 0)
            {
                Console.WriteLine("N= " + i);
            }
        }
    }
}