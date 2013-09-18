using System;

namespace BinaryToDecimal
{
    class BinaryToDecimal
    {
        /* 2. Write a program to convert binary numbers to their decimal representation. */
        static int PowerOfTwo(int power)
        {
            return 1 << power;
        }
        static int ConvertToDecimal(int number)
        {
            int power = 0;
            int numberInDecimal = 0;
            while (number!=0)
            {
                numberInDecimal += number%10 * PowerOfTwo(power);
                number /= 10;
                power++;
            }
            return numberInDecimal;
        }
        static void Main()
        {
            Console.Write("Input a number in decimal: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("The number in decimal is {0}", ConvertToDecimal(number));
        }
    }
}
