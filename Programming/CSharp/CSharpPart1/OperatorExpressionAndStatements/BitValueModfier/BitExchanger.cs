using System;

class BitExchanger
{
    static void Main()
    {
        uint n;
        Console.Write("Input number: ");
        n = uint.Parse(Console.ReadLine());
        uint lowerMask = (7 << 3);
        uint greaterMask = (7 << 24);       
        uint temp1 = lowerMask & n;        
        uint temp2 =  greaterMask & n;
        temp1 <<= 21;
        temp2 >>= 21;
        n &= ~lowerMask;
        n |= temp1;
        n &= ~greaterMask;
        n |=  temp1;
        Console.WriteLine(n);
    }

}