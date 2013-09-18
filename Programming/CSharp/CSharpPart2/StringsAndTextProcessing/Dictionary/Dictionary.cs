using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class Dictionary
    {
        /* 14. A dictionary is stored as a sequence of text lines containing words 
         * and their explanations. Write a program that enters a word and translates 
         * it by using the dictionary. */
        static void Main()
        {
            StringBuilder word = new StringBuilder();
            StringBuilder explanation = new StringBuilder();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            Console.Write("Input how many words you want ot add: ");
            int wordsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= wordsCount; i++)
            {
                Console.WriteLine("Input a word with explanation in the following format\n[word] - [explanation]: ");
                while (true)
                {
                    string line = Console.ReadLine();
                    try
                    {
                        int indexeOfDash = line.IndexOf('-');
                        for (int j = 0; j < indexeOfDash; j++)
                        {
                            word.Append(line[j]);
                        }
                        word.Replace(word.ToString(), word.ToString().Trim());
                        for (int j = indexeOfDash + 1; j < line.Length; j++)
                        {
                            explanation.Append(line[j]);
                        }
                        explanation.Replace(explanation.ToString(), explanation.ToString().Trim());
                        dictionary.Add(word.ToString(), explanation.ToString());
                        word.Clear();
                        explanation.Clear();
                        break;
                    }
                    catch (ArgumentException)
                    {
                        Console.Beep();
                        Console.Error.WriteLine("Input a word with explanation in correct format!");
                    }
                }
            }
            Console.Write("Input a word to search for: ");
            string wordToSearch = Console.ReadLine();
            try
            {
                Console.WriteLine("The explanation of {0} is: {1}", wordToSearch, dictionary[wordToSearch]);
            }
            catch (KeyNotFoundException)
            {
                Console.Beep();
                Console.Error.WriteLine("No such word!");
            }
        }
    }
}
