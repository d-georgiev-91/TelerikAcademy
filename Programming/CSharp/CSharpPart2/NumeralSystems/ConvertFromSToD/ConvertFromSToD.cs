using System;
using System.Collections.Generic;

namespace ConvertFromSToD
{
    class ConvertFromSToD
    {
        /* 7. Write a program to convert from any numeral system of given 
         * base s to any other numeral system of base d (2 ≤ s, d ≤  16). */
        static char DigitToChar(int digit)
        {
            switch (digit)
            {
                case 10:
                    return 'a';
                    break;
                case 11:
                    return 'b';
                    break;
                case 12:
                    return 'c';
                    break;
                case 13:
                    return 'd';
                    break;
                case 14:
                    return 'e';
                    break;
                case 15:
                    return 'f';
                    break;
                default:
                    return (char)(digit + '0');
                    break;
            }

        }
        static int CharToDigit(char digit)
        {
            switch (digit)
            {
                case 'a':
                    return 10;
                    break;
                case 'b':
                    return 11;
                    break;
                case 'c':
                    return 12;
                    break;
                case 'd':
                    return 13;
                    break;
                case 'e':
                    return 14;
                    break;
                case 'f':
                    return 15;
                    break;
                default:
                    return digit - '0';
                    break;
            }
        }
        static int Power(int a, int x)
        {
            int power = 1;
            for (int i = 1; i <= x; i++)
            {
                power *= a;
            }
            return power;
        }
        static int BaseToDecimal(string number, int b)
        {
            number = number.ToLower();
            int result = 0;
            int power = 0;
            if (b != 10)
            {
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    result += CharToDigit(number[i]) * Power(b, power);
                    power++;
                }
            }
            else
            {
                result = Convert.ToInt32(number);
            }
            return result;
        }
        static string DecimalToBase(int number, int b)
        {
            List<int> baseNumberContainerInReverse = new List<int>();
            string result = "";
            if (b != 0)
            {
                for (int i = 0; number > 0; i++)
                {
                    baseNumberContainerInReverse.Add(number % b);
                    number = number / b;
                }
                for (int i = baseNumberContainerInReverse.Count - 1; i >= 0; i--)
                {
                    result = result + DigitToChar(baseNumberContainerInReverse[i]);
                }
            }
            else
            {
                result = number.ToString();
            }
            return result;
        }
        static string ConvertFromStoDBase(int s, int d, string number)
        {
            int baseToDecimal = BaseToDecimal(number, s);
            string decimalToBase = null;
            if (s != d)
            {
                decimalToBase = DecimalToBase(baseToDecimal, d);
            }
            else
            {
                return number;
            }
            return decimalToBase;
        }
        static void Main()
        {
            int s = 1;
            int d = 1;
            while (s < 2 || s > 16)
            {
                Console.Write("Input s in range [2,16]: ");
                s = int.Parse(Console.ReadLine());
            }
            Console.Write("Input number in {0}-base numer system: ", s);
            string number = Console.ReadLine();
            while (d < 2 || d > 16)
            {
                Console.Write("Input d in range [2, 16]: ");
                d = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(ConvertFromStoDBase(s, d, number));
        }
    }
}