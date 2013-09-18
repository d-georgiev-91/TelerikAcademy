using System;
using System.Text;

namespace StringEncoderDecoder
{
    class StringEncoderDecoder
    {
        /* 7. Write a program that encodes and decodes a string using given encryption key (cipher). 
         * The key consists of a sequence of characters. The encoding/decoding is done by performing 
         * XOR (exclusive or) operation over the first letter of the string with the first of the key, 
         * the second – with the second, etc. When the last key character is reached, the next is the first. */
        static void Main()
        {
            Console.Write("Input string: ");
            string input = Console.ReadLine();
            Console.Write("Input cipher: ");
            string cipher = Console.ReadLine();
            StringBuilder encoded = new StringBuilder();
            StringBuilder decoded = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                encoded.Append((char)(input[i] ^ cipher[i % cipher.Length]));
            }
            Console.WriteLine("The encoded string is...\n {0}", encoded.ToString());
            for (int i = 0; i < encoded.Length; i++)
            {
                decoded.Append((char)(encoded[i] ^ cipher[i % cipher.Length]));
            }
            Console.WriteLine("The decoded string is: {0}", decoded);
        }
    }
}