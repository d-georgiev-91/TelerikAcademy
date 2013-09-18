namespace ReddisDictionary
{
    using System;

    public struct WordTranslationPair
    {
        private string word;
        private string translation;

        public WordTranslationPair(byte[] word, byte[] translation)
        {
            this.word = word.StringFromByteArray();
            this.translation = translation.StringFromByteArray();
        }

        public string Translation
        {
            get { return translation; }
        }

        public string Word
        {
            get { return word; }
        }

    }
}
