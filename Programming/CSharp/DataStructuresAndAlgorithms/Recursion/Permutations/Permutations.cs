namespace Permutations
{
    using System;

    class Permutations
    {
        static void Main()
        {
            Console.Write("N= ");
            int n = int.Parse(Console.ReadLine());
            int[] currentPermutation = new int[n];
            bool[] isUsed = new bool[n];
            GeneratePermutations(currentPermutation, isUsed, 0);
        }

        private static void GeneratePermutations(int[] currentPermutation, bool[] isUsed, int currentIndex)
        {
            if (currentIndex >= currentPermutation.Length)
            {
                Console.WriteLine("(" + string.Join(" ", currentPermutation) + ")");
            }

            for (int i = 0; i < currentPermutation.Length; i++)
            {
                if (!isUsed[i])
                {
                    isUsed[i] = true;
                    currentPermutation[currentIndex] = i + 1;
                    GeneratePermutations(currentPermutation, isUsed, currentIndex + 1);
                    isUsed[i] = false;
                }
            }
        }
    }
}