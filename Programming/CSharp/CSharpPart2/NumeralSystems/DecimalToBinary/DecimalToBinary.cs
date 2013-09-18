using System;
using System.Numerics;

namespace DecimalToBinary
{
    class DecimalToBinary
    {
        /* 1. Write a program to convert decimal numbers to their binary representation. */
        static BigInteger ConvertToBinary(int number)
        {
            BigInteger result = 0;
            BigInteger.TryParse(Convert.ToString(number, 2), out result );
            return result;
        }
        static void Main()
        {
            Console.Write("Input a number in decimal: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("The number in binary is {0}", ConvertToBinary(number));
        }
    }
}
