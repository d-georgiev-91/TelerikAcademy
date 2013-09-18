/*
 * 2. Write a recursive program for generating and printing 
 * all the combinations with duplicates of k elements from n-element set. 
 * Example: n=3, k=2  (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
 */

namespace CombinationsWithDuplicates
{
    using System;

    class CombinationsWithDuplicates
    {
        static void Main()
        {
            Console.Write("N= ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K= ");
            int k = int.Parse(Console.ReadLine());
            int[] currentCombination = new int[k];
            GenerateCombinations(currentCombination, n, 0, 0);
        }

        private static void GenerateCombinations(int[] currentCombination, int n, int combinationFirstMember, int currentIndex)
        {
            if (currentIndex >= currentCombination.Length)
            {
                Console.WriteLine("(" + string.Join(" ", currentCombination) + ")");

                return;
            }

            for (int i = combinationFirstMember; i < n; i++)
            {
                currentCombination[currentIndex] = i + 1;

                GenerateCombinations(currentCombination, n, i, currentIndex + 1);
            }
        }
    }
}