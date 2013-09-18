namespace SortingNSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
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

            var sortedCollection = MergeSort(collection);

            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = sortedCollection[i];
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int middle = (collection.Count) / 2;

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            for (int i = 0; i < middle; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = middle; i < collection.Count; i++)
            {
                right.Add(collection[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            IList<T> collectionMerge = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) <= 0)
                    {
                        AddFirstItemAndResizeSubCollection(collectionMerge, ref left);
                    }
                    else
                    {
                        AddFirstItemAndResizeSubCollection(collectionMerge, ref right);
                    }
                }
                else if (left.Count > 0)
                {
                    AddFirstItemAndResizeSubCollection(collectionMerge, ref left);
                }
                else if (right.Count > 0)
                {
                    AddFirstItemAndResizeSubCollection(collectionMerge, ref right);
                }
            }

            return collectionMerge;
        }

        private void AddFirstItemAndResizeSubCollection(IList<T> collection, ref IList<T> subCollection)
        {
            collection.Add(subCollection[0]);
            subCollection = GetRest(subCollection);
        }

        private IList<T> GetRest(IList<T> collection)
        {
            IList<T> rest = new List<T>();

            for (int i = 1; i < collection.Count; i++)
            {
                rest.Add(collection[i]);
            }

            return rest;
        }
    }
}