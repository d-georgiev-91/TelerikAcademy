/* 3. Modify the previous program to skip duplicates:
 * n=4, k=2 => (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
 */

namespace CombinationWithoutDuplications
{
    using System;

    class CombinationWithoutDuplications
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

                GenerateCombinations(currentCombination, n, i + 1, currentIndex + 1);
            }
        }
    }
}
