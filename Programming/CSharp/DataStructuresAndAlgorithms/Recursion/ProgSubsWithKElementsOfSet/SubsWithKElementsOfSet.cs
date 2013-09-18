/*  6. Write a program for generating and printing all subsets of k strings from given set of strings.
*  Example: s = {test, rock, fun}, k=2
*  (test rock),  (test fun),  (rock fun)
*/

using System;

namespace SubsWithKElementsOfSet
{
    class SubsWithKElementsOfSet
    {
        private static bool[] isUsed;

        static void Main()
        {
            string[] set = new string[] { "test", "rock", "fun", "pesho" };
            int k;

            do
            {
                Console.Write("K= ");
                k = int.Parse(Console.ReadLine());
            }
            while (k < 1 || set.Length < k);

            string[] subset = new string[k];
            isUsed = new bool[set.Length];
            GenerateSubset(set, subset, 0, 0);
        }

        private static void GenerateSubset(string[] set, string[] subset, int combinationFirstMember, int currentIndex)
        {
            if (currentIndex >= subset.Length)
            {
                Console.WriteLine("(" + string.Join(" ", subset) + ")");

                return;
            }

            for (int i = combinationFirstMember; i < set.Length; i++)
            {
                subset[currentIndex] = set[i];
                GenerateSubset(set, subset, i + 1, currentIndex + 1);
            }
        }
    }
}