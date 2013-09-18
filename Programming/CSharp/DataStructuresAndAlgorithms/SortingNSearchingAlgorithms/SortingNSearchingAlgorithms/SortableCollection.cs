namespace SortingNSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        private static Random randomGenerator = new Random();

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            return this.BinarySearch(item, 0, this.items.Count - 1);
        }
        
        private bool BinarySearch(T item, int iMin, int iMax) 
        {
            if (iMax < iMin)
            {
                return false;
            }
            else
            {
                int iMid = (iMax - iMin) / 2 + 1;
                
                if (this.items[iMid].CompareTo(item) > 0)
                {
                    return BinarySearch(item, iMin, iMid - 1);
                }
                else if (this.items[iMid].CompareTo(item) < 0)
                {
                    return BinarySearch(item, iMid + 1, iMax);
                }
                else
                {
                    return true;
                }
            }
        }

        public void Shuffle()
        {
            for (int i = this.items.Count - 1; i > 0; i--)
            {
                int j = RandomIndex(i);
                CollectionUtils.Swap<T>(this.items, i, j);
            }
        }

        private int RandomIndex(int i)
        {
            return randomGenerator.Next(0, i + 1);
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}