namespace SortingNSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
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

            this.Sort(collection, 0, collection.Count - 1);
        }

        private void Sort(IList<T> collection, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = (left + right) / 2;
                int pivotNewIndex = Partition(collection, left, right, pivotIndex);
                Sort(collection, left, pivotNewIndex - 1);
                Sort(collection, pivotNewIndex + 1, right);
            }
        }

        private int Partition(IList<T> collection, int left, int right, int pivotIndex)
        {
            T pivotValue = collection[pivotIndex];
            CollectionUtils.Swap<T>(collection, pivotIndex, right);
            int storeIndex = left;
            
            for (int i = left; i < right; i++)
            {
                if (collection[i].CompareTo(pivotValue) <= 0)
                {
                    CollectionUtils.Swap<T>(collection, i, storeIndex);
                    storeIndex++;
                }
            }

            CollectionUtils.Swap<T>(collection, storeIndex, right);

            return storeIndex;
        }
    }
}