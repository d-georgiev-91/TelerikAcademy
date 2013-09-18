using System;

class ExtractBitAtPosition
{
    static void Main()
    {
        int i, b;
        Console.Write("Input number: ");
        i = int.Parse(Console.ReadLine());
        Console.Write("Input the bit position to extract: ");
        b = int.Parse(Console.ReadLine());
        int mask = (1 << b);
        Console.WriteLine((i & mask) >> b);
    }
}