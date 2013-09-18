namespace FindWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    class FindWords
    {
        static void Main()
        {
            var words = File.ReadAllLines("..\\..\\words.txt");
            Console.Clear();
            Console.WriteLine("Loading list of words finished");
            Console.WriteLine("Loading text...");
            var text = File.ReadAllText("..\\..\\text.txt");
            Console.Clear();
            Console.WriteLine("Loading text finished");
            Trie trie = new Trie();
            AddWordsToTrie(trie, words);
            IncrementWordOccuranceOnMatch(trie, ExtractWords(text));
            PrintWordOccurances(trie, words);
        }

        private static void PrintWordOccurances(Trie trie, string [] words)
        {
            foreach (var word in words)
            {
                Console.WriteLine("{0} -> {1}", word, trie.CountWords(trie, word.ToLowerInvariant()));
            }
        }

        private static void AddWordsToTrie(Trie trie, string[] words)
        { 
            foreach (var word in words)
            {
                trie.AddWord(trie, word.ToLowerInvariant());
            }
        }

        private static void IncrementWordOccuranceOnMatch(Trie trie, List<string> text)
        {
            foreach (var word in text)
            {
                trie.AddOccuranceIfExists(trie, word.ToLowerInvariant());
            }
        }

        private static List<string> ExtractWords(string text)
        {
            var matches = Regex.Matches(text, @"\b[a-zA-Z]\w*\b");
            var words = new List<string>();
            
            foreach (var match in matches)
            {
                words.Add(match.ToString().ToLowerInvariant());
            }

            return words;
        }
    }
}