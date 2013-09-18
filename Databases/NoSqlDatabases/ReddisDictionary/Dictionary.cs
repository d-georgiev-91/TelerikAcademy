namespace ReddisDictionary
{
    using ServiceStack.Redis;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Dictionary : IEnumerable<WordTranslationPair>
    {
        private RedisClient client;
        private string dictionaryName;

        public Dictionary(RedisClient client, string dictionaryName)
        {
            this.client = client;
            this.dictionaryName = dictionaryName;
        }

        public void Add(string word, string translation)
        {
            this.client.HSet(this.dictionaryName, word.ToAsciiCharArray(), translation.ToAsciiCharArray());
        }

        public void Remove(string key)
        {
            if (ContainsWord(key))
            {
                this.client.HDel(this.dictionaryName, key.ToAsciiCharArray());
            }
            else
            {
                throw new ArgumentException("The key does not exist.");
            }
        }

        public bool ContainsWord(string word)
        {
            long containsValue = this.client.HExists(this.dictionaryName, word.ToAsciiCharArray());

            if (containsValue == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string this[string word]
        {
            get
            {
                byte[] valueToReturn = this.client.HGet(this.dictionaryName, word.ToAsciiCharArray());

                return valueToReturn.StringFromByteArray();
            }

            set
            {
                this.client.HSet(this.dictionaryName, word.ToAsciiCharArray(), value.ToAsciiCharArray());
            }
        }

        public IEnumerator<WordTranslationPair> GetEnumerator()
        {
            byte[][] allValues = this.client.HGetAll(this.dictionaryName);

            for (int i = 0; i < allValues.Length; i += 2)
            {
                if (i >= allValues.Length)
                {
                    break;
                }
                yield return new WordTranslationPair(allValues[i], allValues[i + 1]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
