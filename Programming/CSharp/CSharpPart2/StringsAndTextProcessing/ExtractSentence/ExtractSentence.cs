using System;
using System.Text.RegularExpressions;

namespace ExtractSentence
{
    /* 8. Write a program that extracts from a given text all sentences containing given word.*/
    class ExtractSentence
    {
        static void Main()
        {
            Console.Write("Input text: ");
            string text = Console.ReadLine();
            Console.Write("Input word: ");
            string wordMatch = Console.ReadLine();
            string regex = @"\s*([^\.]*\b" + wordMatch + @"\b.*?\.)";
            MatchCollection sentences = Regex.Matches(text, regex, RegexOptions.IgnoreCase);
            foreach (var sentence in sentences)
            {
                Console.WriteLine(sentence.ToString().Trim());
            }
        }
    }
}
