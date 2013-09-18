using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CensuredMessage
{
    class CensuredMessage
    {
        /* 9. We are given a string containing a list of forbidden 
         * words and a text containing some of these words. 
         * Write a program that replaces the forbidden words with asterisks. */
        static void Main()
        {
            Console.Write("Input text to censure: ");
            string text = Console.ReadLine();
            Console.Write("Input list of forbidden words, separated with comas: ");
            string forbidenWords = Console.ReadLine();
            StringBuilder regex = new StringBuilder();
            regex.Append(forbidenWords);
            regex.Replace(", ","|");
            text = Regex.Replace(text, regex.ToString(), (censure => new String('*', censure.Length)));
            Console.WriteLine("\n" + text);
        }
    }
}
