using System;
using System.Text;

namespace ReversesWords
{
    class ReversesWords
    {
        /* 13. Write a program that reverses the words in given sentence.
	     * Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".
         */
        static void Main()
        {
            Console.Write("Input a sentence: ");
            string sentence = Console.ReadLine();
            string [] words = sentence.Split(new char[] {' ', ',', ';', '.', '!', '?', ':'}, StringSplitOptions.RemoveEmptyEntries );
            char[] nonSings = new char['~' - '"' - 4];
            int j = 0; 
            for (char i = '"'; i <= '~'; i++)
			{
                if (i != ',' && i != ';' && i != '.'  && i != '?' && i != ':')
                {
                    nonSings[j++] = i;
                }
			}
            string [] sings = sentence.Split(nonSings, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            StringBuilder result = new StringBuilder(sings.Length);
            for (int i = 0; i < sings.Length; i++)
            {
                result.Append(words[i]);
                result.Append(sings[i]);
            }
            Console.WriteLine(result);
        }
    }
}
