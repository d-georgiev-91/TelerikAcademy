using System;

namespace LastDigitInEnglish
{
    class LastDigitInEnglish
    {
        /*
         * 3. Write a method that returns the last digit of given integer as an English word.
         * Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".
         */
        static string DigitInEnglish(int number)
        {
            int digit = number % 10;
            switch (digit)
            {
                case 0:
                    return "zero";
                    break;
                case 1:
                    return "one";
                    break;
                case 2:
                    return "two";
                    break;
                case 3:
                    return "three";
                    break;
                case 4:
                    return "four";
                    break;
                case 5:
                    return "five";
                    break;
                case 6:
                    return "six";
                    break;
                case 7:
                    return "seven";
                    break;
                case 8:
                    return "eight";
                    break;
                case 9:
                    return "nine";
                    break;
            }
            return "";
        }
        static void Main()
        {
            Console.Write("Input a number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(DigitInEnglish(number));
        }
    }
}
