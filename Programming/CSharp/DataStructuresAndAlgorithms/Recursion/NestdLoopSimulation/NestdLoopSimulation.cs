/* 1. Write a recursive program that simulates the execution of n nested loops from 1 to n. Examples:
 *                            1 1 1
 *                            1 1 2
 *                            1 1 3
 *          1 1               1 2 1
 * n=2  ->  1 2      n=3  ->  ...
 *          2 1               3 2 3
 *          2 2               3 3 1
 *                            3 3 2
 *                            3 3 3
 * 
 */
namespace NestdLoopSimulation
{
    using System;

    class NestdLoopSimulation
    {
        static void Main()
        {
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());
            int[] sets = new int[n];
            SimulateLoops(sets, 0, n);
        }

        private static void SimulateLoops(int[] sets, int currentIndex, int n)
        {
            if (currentIndex >= n)
            {
                Console.WriteLine(string.Join(" ", sets));

                return;
            }

            for (int i = 0; i < n; i++)
            {
                sets[currentIndex] = i + 1;
                SimulateLoops(sets, currentIndex + 1, n);
            }
        }
    }
}