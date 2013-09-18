using System;

namespace DecimalToHex
{
    class DecimalToHex
    {
        /* 3. Write a program to convert decimal numbers to their hexadecimal representation. */
        static string ConvertToHex(int number)
        {
            return number.ToString("X");
        }
        static void Main()
        {
            Console.Write("Input a number in decimal: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("The number in hex is {0}", ConvertToHex(number));
        }
    }
}
