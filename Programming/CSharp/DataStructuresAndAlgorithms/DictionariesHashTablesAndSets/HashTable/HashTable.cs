namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashTable<TKey, TValue> : IEnumerable<TKey>
    {
        private LinkedList<KeyValuePair<TKey, TValue>>[] hashTable;
        private const int InitalHashTableSize = 16;
        private KeyCollection<TKey> keys;

        public HashTable()
        {
            this.Count = 0;
            this.UsedCells = 0;
            this.hashTable = new LinkedList<KeyValuePair<TKey, TValue>>[InitalHashTableSize];
            this.Keys = new KeyCollection<TKey>();
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var key in Keys)
            {
                if (key == null)
                {
                    break;
                }

                int position = Math.Abs(key.GetHashCode() % this.hashTable.Length);
                var currentKeyValuePairs = hashTable[position];

                foreach (var currentValuePair in currentKeyValuePairs)
                {
                    yield return currentValuePair;
                }
            }
        }

        IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
        {
            return (IEnumerator<TKey>)this.GetEnumerator();
        }

        public void Add(TKey key, TValue value)
        {
            if (this.UsedCells >= hashTable.Length * 0.75)
            {
                ResizeHashTable();
            }

            int position = Math.Abs(key.GetHashCode() % this.hashTable.Length);

            if (hashTable[position] == null)
            {
                hashTable[position] = new LinkedList<KeyValuePair<TKey, TValue>>();
                this.UsedCells++;
            }

            if (Contais(key))
            {
                throw new ArgumentException(string.Format("Item with key \"{0}\" exist", key));
            }

            this.Keys.Add(key);
            var keyValuePair = new KeyValuePair<TKey, TValue>(key, value);
            hashTable[position].AddLast(keyValuePair);
            Count++;
        }

        public void Remove(TKey key)
        {
            CheckIsTableEmpty();

            if (!Contais(key))
            {
                throw new InvalidOperationException(string.Format("No such key {0}", key));
            }

            int position = Math.Abs(key.GetHashCode() % this.hashTable.Length);
            var keyValuePairs = hashTable[position];
            var currentKeyValuePair = keyValuePairs.First;

            while (currentKeyValuePair != null)
            {
                var currentKey = currentKeyValuePair.Value.Key;

                if (currentKey.Equals(key))
                {
                    keyValuePairs.Remove(currentKeyValuePair);
                }

                currentKeyValuePair = currentKeyValuePair.Next;
            }

            if (keyValuePairs.Count == 0)
            {
                keyValuePairs = null;
            }

            this.Keys.Remove(key);
            this.Count--;
        }

        private void CheckIsTableEmpty()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("The hash table is empty");
            }
        }

        public bool Contais(TKey key)
        {
            if (this.Count == 0)
            {
                return false;
            }
            
            int position = Math.Abs(key.GetHashCode() % this.hashTable.Length);
            var keyValuePairs = hashTable[position];

            if (keyValuePairs == null)
            {
                return false;
            }

            foreach (var keyValuePair in keyValuePairs)
            {
                if (keyValuePair.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        private void ResizeHashTable()
        {
            int currentHashTableSize = this.hashTable.Length;
            var currentHashTable = hashTable;
            hashTable = new LinkedList<KeyValuePair<TKey, TValue>>[currentHashTableSize * 2];

            for (int i = 0; i < currentHashTableSize; i++)
            {
                hashTable[i] = currentHashTable[i];
            }
        }

        public TValue Find(TKey key)
        {
            int position = Math.Abs(key.GetHashCode() % this.hashTable.Length);
            var keyValuePairs = hashTable[position];
            string notFoundErrorMessage = string.Format("No such item with key \"{0}\"", key);

            if (keyValuePairs == null)
            {
                throw new ArgumentException(notFoundErrorMessage);
            }

            foreach (var keyValuePair in keyValuePairs)
            {
                if (keyValuePair.Key.Equals(key))
                {
                    var value = keyValuePair.Value;
                    return value;
                }
            }

            throw new ArgumentException(notFoundErrorMessage);
        }

        public void Clear()
        {
            for (int i = 0; i < hashTable.Length; i++)
            {
                var keyValuePairs = hashTable[i];
                
                if (keyValuePairs == null)
                {
                    continue;
                }

                keyValuePairs.Clear();
                keyValuePairs = null;
            }

            this.Count = 0;
            this.UsedCells = 0;
            this.Keys = new KeyCollection<TKey>();
            hashTable = new LinkedList<KeyValuePair<TKey, TValue>>[InitalHashTableSize];
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value = this.Find(key);

                return value;
            }
            set
            {
                TValue val = this.Find(key);
                val = value;
            }
        }

        public KeyCollection<TKey> Keys
        {
            get
            {
                return this.keys;
            }
            private set
            {
                this.keys = value;
            }
        }

        public int Count { get; private set; }

        private int UsedCells { get; set; }
    }
}