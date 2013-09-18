namespace HashTable
{
    public class KeyValuePair<TKey, TValue>
    {
        public KeyValuePair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public override string ToString()
        {
            string keyAsString = this.Key.ToString();
            string valueAsString = this.Value.ToString();
            string keyValueAsString = string.Format("[{0}, {1}]", keyAsString, valueAsString);

            return keyValueAsString;
        }

        public TKey Key { get; internal set; }

        public TValue Value { get; set; }
    }
}