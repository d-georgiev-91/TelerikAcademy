using System;
using System.Collections.Generic;
using System.Linq;

namespace ListDifferentWords
{
    class ListDifferentWords
    {
        /* 22. Write a program that reads a string from the console and lists all different
         * words in the string along with information how many times each word is found. */
        static void Main()
        {
            Console.Write("Input list of words: ");
            string input = Console.ReadLine();
            string[] words = input.Split(new char[] { ' ', ',' });
            Dictionary<string, int> wordsApperiance = new Dictionary<string, int>();
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (!wordsApperiance.ContainsKey(words[i]))
                {
                    int counter = 1;
                    for (int j = i + 1; j < words.Length; j++)
                    {
                        if (words[i]==words[j])
                        {
                            counter++;
                        }
                    }
                    wordsApperiance.Add(words[i], counter);
                }
            }
            foreach (var word in wordsApperiance.Keys)
            {
                Console.WriteLine("{0} - {1}", word, wordsApperiance[word]);
            }
        }
    }
}
