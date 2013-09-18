using System;

namespace ReversesNumber
{
    class ReversesNumber
    {
        /*
         * 9. Write a method that reverses the digits of given decimal number. Example: 256 -> 652
         */

        static int Reverse(int number)
        {
            int reversedNumber = 0;
            int reminder;
            while (number != 0)
            {
                reminder = number % 10;
                reversedNumber = reversedNumber * 10 + reminder;
                number = number / 10;
            }
            return reversedNumber;
        }

        static void Main()
        {
            Console.Write("Input number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("The number in reverse is {0}.", Reverse(number));
        }
    }
}
