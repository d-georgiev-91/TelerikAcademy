namespace SortingNSearchingAlgorithms
{
    using System.Collections.Generic;

    internal static class CollectionUtils
    {
        internal static void Swap<T>(IList<T> collection, int firstIndex, int secondIndex)
        {
            var swap = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = swap;
        }
    }
}
