/*  5. Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
 *  Example: n=3, k=2, set = {hi, a, b} =>
 *  (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
 */

namespace GenerateSubSetVartionsOfSet
{
    using System;

    class GenerateSubSetVartionsOfSet
    {
        static void Main()
        {
            string[] set = new string[] { "hi", "a", "b" };
            int k;

            do
            {
                Console.Write("K= ");
                k = int.Parse(Console.ReadLine());
            }
            while (k < 0 || set.Length < k);

            string[] currentVartion = new string[k];
            bool[] isUsed = new bool[k];
            GenerateVations(set, currentVartion, 0);
        }

        private static void GenerateVations(string[] set, string[] currentVartion, int currentIndex)
        {
            if (currentIndex >= currentVartion.Length)
            {
                Console.WriteLine("(" + string.Join(" ", currentVartion) + ")");

                return;
            }

            for (int i = 0; i < set.Length; i++)
            {
                currentVartion[currentIndex] = set[i];
                GenerateVations(set, currentVartion, currentIndex + 1);
            }
        }
    }
}