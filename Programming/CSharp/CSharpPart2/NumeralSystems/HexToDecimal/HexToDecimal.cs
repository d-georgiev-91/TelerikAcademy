using System;

namespace HexToDecimal
{
    class HexToDecimal
    {
        /*4. Write a program to convert hexadecimal numbers to their decimal representation.*/
        static int ConvertToDecimal(string number)
        {
            return Convert.ToInt32(number, 16);
        }
        static void Main()
        {
            Console.Write("Input a number in hex: ");
            string number = Console.ReadLine();
            Console.WriteLine("The number in decimal is {0}", ConvertToDecimal(number));
        }
    }
}
