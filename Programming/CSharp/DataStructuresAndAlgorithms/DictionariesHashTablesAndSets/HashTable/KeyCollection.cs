namespace HashTable
{
    using System.Collections;
    using System.Collections.Generic;

    public class KeyCollection<T>: IEnumerable<T>   
    {
        internal KeyCollection()
        {
            this.Keys = new List<T>();
        }

        public IEnumerator GetEnumerator()
        {
            foreach (T key in this.Keys)
            {
                if (key == null)
                {
                    break;
                }

                yield return key;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)this.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return this.Keys.Count;
            }
        }

        internal void Add(T key)
        {
            this.Keys.Add(key);
        }

        internal void Remove(T key)
        {
            this.Keys.Remove(key);
        }

        internal bool Contains(T key)
        {
            return this.Keys.Contains(key);
        }

        public T this[int index]
        {
            get
            {
                return this.Keys[index];
            }
        }

        private List<T> Keys { get; set; }
    }
}