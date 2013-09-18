using System;
using System.Collections.Generic;

namespace ExtractPalindromes
{
    class ExtractPalindromes
    {
        /* 20. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe". */

        static bool IsPalindrome(string checkString)
        {
            string firstString = checkString.Substring(0, checkString.Length / 2);
            char[] characters = checkString.ToCharArray();
            Array.Reverse(characters);
            string temp = new string(characters);
            string secondSecond = temp.Substring(0, temp.Length / 2);
            return firstString.Equals(secondSecond);
        }
        static void Main()
        {
            Console.Write("Input some text: ");
            string text = Console.ReadLine();
            List<string> allPalindromes = new List<string>();
            string[] words = text.Split(new char[] { ',', ' ', '!', '.', '?', '-' });
            foreach (var word in words)
            {
                if (IsPalindrome(word.ToLower()))
                {
                    allPalindromes.Add(word);
                }
            }
            if (allPalindromes.Count > 0)
            {
                Console.WriteLine("All palindromes are: ");
                foreach (var palindrome in allPalindromes)
                {
                    Console.WriteLine(palindrome);
                }
            }
            else
            {
                Console.WriteLine("There are no palindromes in given text!");
            }
        }
    }
}