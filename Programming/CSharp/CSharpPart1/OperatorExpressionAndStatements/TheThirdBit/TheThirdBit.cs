using System;

class TheThirdBit
{
    static void Main()
    {
        Console.Write("Input a nubmer: ");
        int myInt = int.Parse(Console.ReadLine());
        int mask = 1 << 3;
        int myIntAndMask = myInt & mask;
        int myIntBIt = myIntAndMask >> 3;
        bool theThirdBit = (myIntBIt == 1);
        Console.WriteLine(theThirdBit);
    }
}
