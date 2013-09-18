using System;

class IsBitAtPosition1
{
    static void Main()
    {
        int v, p;
        Console.Write("Input number: ");
        v = int.Parse(Console.ReadLine());
        Console.Write("Input the bit position to compare: ");
        p = int.Parse(Console.ReadLine());
        int mask = 1 << p;
        bool bitAtPPosition = (((v & mask)>>p) == 1);
        Console.WriteLine(bitAtPPosition);
    }
}