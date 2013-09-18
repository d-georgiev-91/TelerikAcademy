namespace BiDicitionaryDemo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class BiDictionary<TKey1, TKey2, TValue> : IEnumerable<TValue>
    {
        private Dictionary<Tuple<TKey1, TKey2>, TValue> container;

        public BiDictionary()
        {
            this.container = new Dictionary<Tuple<TKey1, TKey2>, TValue>();
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var keysPair in this.container.Keys)
            {
                if (this.container[keysPair] == null)
                {
                    break;
                }

                yield return this.container[keysPair];
            }
        }

        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
        {
            return (IEnumerator<TValue>)this.GetEnumerator();
        }

        public void Add(TKey1 firstKey, TKey2 secondKey, TValue value)
        {
            this.container.Add(new Tuple<TKey1, TKey2>(firstKey, secondKey), value);
            this.Count++;
        }

        public void Remove(TKey1 firstKey, TKey2 secondKey)
        {
            var key = new Tuple<TKey1, TKey2>(firstKey, secondKey);
            
            if (!this.container.ContainsKey(key))
            {
                throw new ArgumentException(string.Format("Invalid key pairs - {0} {1}", firstKey, secondKey));
            }

            this.container.Remove(key);
            this.Count--;
        }

        public void RemoveByFirstKey(TKey1 firstKey)
        {
            Tuple<TKey1, TKey2> pairToRemove = null;

            foreach (var keys in this.container.Keys)
            {
                if (keys.Item1.Equals(firstKey))
                {
                    pairToRemove = keys;
                    break;
                }
            }

            if (pairToRemove == null)
            {
                throw new ArgumentException(string.Format("No such key {0}", firstKey));   
            }

            this.container.Remove(pairToRemove);
            this.Count--;
        }

        public void RemoveBySecondKey(TKey2 secondKey)
        {
            Tuple<TKey1, TKey2> pairToRemove = null;

            foreach (var keys in this.container.Keys)
            {
                if (keys.Item2.Equals(secondKey))
                {
                    pairToRemove = keys;
                    break;
                }
            }

            if (pairToRemove == null)
            {
                throw new ArgumentException(string.Format("No such key {0}", secondKey));
            }

            this.container.Remove(pairToRemove);
            this.Count--;
        }

        public int Count { get; private set; }

        public ICollection Keys
        {
            get
            {
                return this.container.Keys;
            }
        }

        public TValue this[Tuple<TKey1, TKey2> index]
        {
            get
            {
                return this.container[index];
            }
            set
            {
                this.container[index] = value;
            }
        }
    }
}