using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CountAlphabeticalLetters
{
    class CountAlphabeticalLetters
    {
        /* 21. Write a program that reads a string from the console and prints all different 
         * letters in the string along with information how many times each letter is found. */
        static void Main()
        {
            Console.Write("Input string: ");
            string input = Console.ReadLine();
            char[] characters = input.ToCharArray();
            Array.Sort(characters);
            StringBuilder lettersCount = new StringBuilder();
            lettersCount.Append(characters);
            while (lettersCount.Length != 0)
            {
                Console.WriteLine("{0} - {1}", lettersCount[0], Regex.Matches(lettersCount.ToString(), String.Format("[{0}]", lettersCount[0])).Count);
                lettersCount.Replace(lettersCount[0].ToString(), String.Empty);
            }
        }
    }
}
