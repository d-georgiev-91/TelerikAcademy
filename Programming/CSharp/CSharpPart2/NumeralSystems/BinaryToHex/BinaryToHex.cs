using System;

namespace BinaryToHex
{
    class BinaryToHex
    {
        /* 6. Write a program to convert binary numbers to hexadecimal numbers (directly). */
        static string BinaryToHexDigit(string binary)
        {
            switch (binary)
            {
                case "0000":
                    return "0";
                    break;
                case "0001":
                    return "1";
                    break;
                case "0010":
                    return "2";
                    break;
                case "0011":
                    return "3";
                    break;
                case "0100":
                    return "4";
                    break;
                case "0101":
                    return "5";
                    break;
                case "0110":
                    return "6";
                    break;
                case "0111":
                    return "7";
                    break;
                case "1000":
                    return "8";
                    break;
                case "1001":
                    return "9";
                    break;
                case "1010":
                    return "a";
                    break;
                case "1011":
                    return "b";
                    break;
                case "1100":
                    return "c";
                    break;
                case "1101":
                    return "d";
                    break;
                case "1110":
                    return "e";
                    break;
                case "1111":
                    return "f";
                    break;
                default:
                    Console.WriteLine("Invalid binary number!");
                    break;
            }
            return null;
        }
        static string ConvertBinaryToHex(string binary)
        {
            int zerosToFill = 0; //1 0000
            string hex = "";
            if (binary.Length % 4 != 0)
            {
                zerosToFill = 4 - (binary.Length - (4 * (binary.Length / 4)));
            }
            for (int i = 1; i <= zerosToFill; i++)
            {
                binary = "0" + binary;
            }
            for (int i = 0; i < binary.Length; i=i+4)
            {
                hex += BinaryToHexDigit(binary.Substring(i, 4));
            }
            return hex.ToUpper();
        }
        static void Main()
        {
            Console.Write("Input a number in binary: ");
            string binary = Console.ReadLine();
            Console.WriteLine("The number in hex is {0}", ConvertBinaryToHex(binary));
        }
    }
}
