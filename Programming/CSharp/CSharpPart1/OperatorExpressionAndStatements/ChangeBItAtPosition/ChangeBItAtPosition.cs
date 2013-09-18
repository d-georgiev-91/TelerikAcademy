using System;

class ChangeBItAtPosition
{
    static void Main()
    {
        int v, p, n;
        Console.Write("Input number: ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Input the bit position to change: ");
        p = int.Parse(Console.ReadLine()); 
        Console.Write("Input value to change (0 or 1): ");
        v = int.Parse(Console.ReadLine());
        n &= (~(1 << p));
        n |= (v << p);
        Console.WriteLine(n);  
    }
}
