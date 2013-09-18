using System;

namespace WordLetterIndexes
{
    class WordLetterIndexes
    {
        static void Main()
        {
            /* Uslovie
             * 12. Write a program that creates an array containing all letters from 
             * the alphabet (A-Z). Read a word from the console and print the index 
             * of each of its letters in the array.
             */
            Console.Write("Input a word [A-Z] only: ");
            string word = Console.ReadLine();
            word = word.ToUpper();
            char [] letters = new char[26];
            for (int i = 0; i < 26; i++)
            {
                letters[i] = (char)(i + 'A'); 
            }
            foreach (var item in word)
            {
                for (int i = 0; i < 26; i++)
                {
                    if (item == letters[i])
                    {
                        Console.WriteLine("{0} has index {1}.", item, i);
                    }
                }
            }
        }
    }
}
