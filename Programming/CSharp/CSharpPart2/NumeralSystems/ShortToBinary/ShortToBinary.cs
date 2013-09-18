using System;

namespace ShortToBinary
{
    class ShortToBinary
    {
        /* 8. Write a program that shows the binary 
         * representation of given 16-bit signed integer number (the C# type short). 
         */
        static ulong ConvertShortToBinary(short number)
        {
            ulong result = Convert.ToUInt64(Convert.ToString(number, 2));
            return result;
        }
        static void Main()
        {
            Console.Write("Input a signed 16-bit integer: ");
            short number = short.Parse(Console.ReadLine());
            Console.WriteLine("The number in binary is {0}.", ConvertShortToBinary(number));
        }
    }
}
