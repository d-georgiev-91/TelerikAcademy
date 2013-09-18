namespace FindWords
{
    using System;

    public class Trie
    {
        private int words;
        private int prefixes;
        private Trie[] edges;

        public Trie()
        {
            this.words = 0;
            this.prefixes = 0;
            this.edges = new Trie[26];
        }

        public Trie AddWord(Trie trie, string word)
        {
            var newTrie = this.AddWord(trie, word, 0);

            return newTrie;
        }

        private Trie AddWord(Trie trie, string word, int wordIndex)
        {
            if (word.Length != wordIndex)
            {
                trie.prefixes ++;

                int index = word[wordIndex] - 'a';
                wordIndex++;

                if (trie.edges[index] == null)
                {
                    trie.edges[index] = new Trie();
                }

                trie.edges[index] = AddWord(trie.edges[index], word, wordIndex);
            }

            return trie;
        }

        public int CountWords(Trie trie, string word)
        {
            return this.CountWords(trie, word, 0);
        }

        private int CountWords(Trie trie, string word, int wordIndex)
        {
            if (word.Length == wordIndex)
            {
                return trie.words;
            }
            else
            {
                int nextCharIndex = word[wordIndex] - 'a';
                wordIndex++;

                if (trie.edges[nextCharIndex] == null)
                {
                    return 0;
                }
                else
                {
                    return CountWords(trie.edges[nextCharIndex], word, wordIndex);
                }
            }
        }

        public int CountPrefix(Trie trie, string word)
        {
            return this.CountPrefix(trie, word, 0);
        }

        private int CountPrefix(Trie trie, string word, int wordIndex)
        {
            if (word.Length == wordIndex)
            {
                return trie.prefixes;
            }
            else
            {
                int nextCharIndex = word[wordIndex] - 'a';
                wordIndex++;

                if (trie.edges[nextCharIndex] == null)
                {
                    return 0;
                }
                else
                {
                    return this.CountPrefix(trie.edges[nextCharIndex], word, wordIndex);
                }
            }
        }

        public void AddOccuranceIfExists(Trie trie, string word)
        {
            this.InceraseOccuranceIfExists(trie, word, 0);
        }

        private void InceraseOccuranceIfExists(Trie trie, string word, int wordIndex)
        {
            if (word.Length == wordIndex)
            {
                trie.words++;
            }
            else
            {
                int nextCharIndex = word[wordIndex] - 'a';
                wordIndex++;
                trie.prefixes++;

                if (trie.edges[nextCharIndex] == null)
                {
                    return;
                }
                else
                {
                    InceraseOccuranceIfExists(trie.edges[nextCharIndex], word, wordIndex);
                }
            }
        }
    }
}