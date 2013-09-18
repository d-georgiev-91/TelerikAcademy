using System;

namespace SortWords
{
    class SortWords
    {
        /*24. Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order. */
        static void Main()
        {
            Console.Write("Input list of words separated by spaces: ");
            string listOfWords = Console.ReadLine();
            string[] words = listOfWords.Split(' ');
            Array.Sort(words);
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
