namespace HashedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using HashTable;

    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<int, T> hashedSet;

        public HashedSet()
        {
            this.hashedSet = new HashTable<int, T>();
        }

        public void Add(T value)
        {
            try
            {
                this.hashedSet.Add(value.GetHashCode(), value);
                this.Count++;
            }
            catch (ArgumentException)
            {
                return;
            }
        }

        public void Remove(T value)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The set is empty");
            }

            hashedSet.Remove(value.GetHashCode());
            Count--;
        }

        public bool Find(T value)
        {
            if (this.Count == 0)
            {
                return false;
            }

            return hashedSet.Contais(value.GetHashCode());
        }

        public void Clear()
        {
            Count = 0;
            hashedSet.Clear();
        }

        public HashedSet<T> Union(HashedSet<T> set)
        {
            if (set == null)
            {
                throw new ArgumentNullException("Invalid argument");
            }

            if (Count == 0 || set.Count == 0)
            {
                return null;
            }

            HashedSet<T> union = new HashedSet<T>();

            foreach (T item in this)
            {
                union.Add(item);
            }

            foreach (T item in set)
            {
                if (!this.Find(item))
                {
                    union.Add(item);
                }
            }

            return union;
        }

        public HashedSet<T> Intersect(HashedSet<T> set)
        {
            if (set == null)
            {
                throw new ArgumentNullException("Invalid argument");
            }

            if (Count == 0 || set.Count == 0)
            {
                return null;
            }

            HashedSet<T> intersection = new HashedSet<T>();

            foreach (T item in set)
            {
                if (this.Find(item))
                {
                    intersection.Add(item);
                }
            }

            return intersection;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (int key in hashedSet.Keys)
            {
                if (hashedSet[key] == null)
                {
                    break;
                }

                yield return hashedSet[key];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)this.GetEnumerator();
        }

        public int Count { get; private set; }
    }
}