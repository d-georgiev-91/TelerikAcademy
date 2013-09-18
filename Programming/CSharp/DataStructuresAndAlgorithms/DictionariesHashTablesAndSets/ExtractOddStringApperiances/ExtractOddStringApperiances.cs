namespace ExtractOddStringApperiances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ExtractOddStringApperiances
    {
        static void Main()
        {
            string[] sequence = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            IDictionary<string, int> wordApperiance = new SortedDictionary<string, int>();

            foreach (var word in sequence)
            {
                if (wordApperiance.ContainsKey(word))
                {
                    wordApperiance[word]++;
                }
                else
                {
                    wordApperiance.Add(word, 1);
                }
            }

            foreach (var word in wordApperiance.Keys)
            {
                if (wordApperiance[word] % 2 != 0)
                {
                    Console.Write(word + " ");
                }
            }

            Console.WriteLine();
        }
    }
}