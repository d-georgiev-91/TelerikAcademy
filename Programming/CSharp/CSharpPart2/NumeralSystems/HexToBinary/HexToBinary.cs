using System;
using System.Numerics;

namespace HexToBinary
{
    /*
     * 5. Write a program to convert hexadecimal numbers to binary numbers (directly).
     */
    class HexToBinary
    {
        static string HexToBinaryDigit (char hex)
        {
            switch (hex)
            {
                case '0':
                    return "0000";
                    break; 
                case '1':
                    return "0001";
                    break;
                case '2':
                    return "0010";
                    break;
                case '3':
                    return "0011";
                    break;
                case '4':
                    return "0100";
                    break;
                case '5':
                    return "0101";
                    break;
                case '6':
                    return "0110";
                    break;
                case '7':
                    return "0111";
                    break;
                case '8':
                    return "1000";
                    break;
                case '9':
                    return "1001";
                    break;
                case 'a':
                    return "1010";
                    break;
                case 'b':
                    return "1011";
                    break;
                case 'c':
                    return "1100";
                    break;
                case 'd':
                    return "1101";
                    break;
                case 'e':
                    return "1110";
                    break;
                case 'f':
                    return "1111";
                    break;
                default:
                    Console.WriteLine("Invalid hex number!");
                    break;
            }
            return null;
        }
        static string ConvertHexToBinary(string hex)
        {
            string binary = "";
            hex = hex.ToLower();
            foreach (var digit in hex)
            {
                Console.WriteLine(digit);
                binary += HexToBinaryDigit(digit);
            }
            int start = 0;
            foreach (var digit in binary)
            {
                start++;
                if (digit != '0')
                {
                    break;
                }
            }
            Console.WriteLine(start);
            return binary.Substring(start-1, binary.Length-start);
        }
        static void Main()
        {
            Console.Write("Input a number in hex: ");
            string hex = Console.ReadLine();
            Console.WriteLine("The number in binary is {0}", ConvertHexToBinary(hex));
        }
    }
}
