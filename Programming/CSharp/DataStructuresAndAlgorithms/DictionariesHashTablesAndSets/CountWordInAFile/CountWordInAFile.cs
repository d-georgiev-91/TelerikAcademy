namespace CountWordInAFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class CountWordInAFile
    {
        static void Main()
        {
            string text = System.IO.File.ReadAllText(@"..\..\words.txt");
            var matches = Regex.Matches(text, @"\b[a-zA-Z0-9]\w*\b");
            IDictionary<string, int> wordApereances = new SortedDictionary<string, int>();

            foreach (Match match in matches)
            {
                string word = match.Value.ToLower();

                if (wordApereances.ContainsKey(word))
                {
                    wordApereances[word]++;
                }
                else
                {
                    wordApereances.Add(match.Value.ToLower(), 1);
                }
            }

            int line = 1;

            foreach (var word in wordApereances.Keys)
            {
                Console.WriteLine("{0} -> {1}", word, wordApereances[word]);
                
                if (line % (Console.WindowHeight - 1) == 0)
                {
                    Console.WriteLine("Press any for more...");
                    Console.ReadKey();
                }

                line++;
            }
        }
    }
}