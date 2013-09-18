namespace SortingNSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection cannot be null");
            }

            if (collection.Count == 0)
            {
                throw new ArgumentException("Cannot sort an empty collection");
            }

            if (collection.Count == 1)
            {
                return;
            }

            for (int i = 0; i < collection.Count; i++)
            {
                int currentMinIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[currentMinIndex].CompareTo(collection[j]) > 0)
                    {
                        currentMinIndex = j;
                    }
                }

                if (currentMinIndex != i)
                {
                    CollectionUtils.Swap<T>(collection, currentMinIndex, i);
                }
            }
        }
    }
}