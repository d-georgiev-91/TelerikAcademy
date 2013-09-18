using System;

class PrintSequence1ToN
{
    static void Main()
    {
        Console.Write("Input n: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i < n; i++)
        {
            Console.Write(i + ", ");
        }
        Console.WriteLine(n + ".");
    }
}
