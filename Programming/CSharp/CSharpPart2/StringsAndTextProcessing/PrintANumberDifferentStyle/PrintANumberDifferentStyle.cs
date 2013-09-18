using System;

namespace PrintANumberDifferentStyle
{
    class PrintANumberDifferentStyle
    {
        /* 11. Write a program that reads a number and prints it as a 
         * decimal number, hexadecimal number, percentage and in 
         * scientific notation. Format the output aligned right in 15 symbols. */
        static void Main()
        {
            Console.Write("Input a number: ");
            decimal number = decimal.Parse(Console.ReadLine());
            Console.WriteLine("{0:D}".PadRight(15), (int)number);
            Console.WriteLine("{0:X}".PadRight(15), (int)number);
            Console.WriteLine("{0:P}".PadRight(15), number/100);
            Console.WriteLine("{0:00e+0}".PadRight(15), number);
        }
    }
}
