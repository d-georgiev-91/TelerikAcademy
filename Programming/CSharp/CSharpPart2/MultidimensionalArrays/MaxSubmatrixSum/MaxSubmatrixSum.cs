using System;

namespace MaxSubmatrixSum
{
    class MaxSubmatrixSum
    {
        /* 
         * Uslovie 
         * 2. Write a program that reads a rectangular matrix of size N x M and 
         * finds in it the square 3 x 3 that has maximal sum of its elements.
         */
        static int SumMatrix(int[,] matrix, int currentRow, int currentColumn)
        {
            int sum = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    sum += matrix[row + currentRow, column + currentColumn];
                }
            }
            return sum;
        }
        static void PrintMatrix(int[,] matrix, int maxRow, int maxColumn)
        {
            int maxWidth = matrix[0, 0];
            foreach (var item in matrix)
            {
                maxWidth = Math.Max(maxWidth, item);
            }
            for (int row = maxRow; row < maxRow + 3; row++)
            {
                for (int column = maxColumn; column < maxColumn + 3; column++)
                {
                    Console.Write(Convert.ToString(matrix[row, column]).PadRight(maxWidth.ToString().Length, ' ') + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main()
        {
            Console.Write("Input n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Input m: ");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[m, n];
            for (int row = 0; row < m; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    Console.Write("m[{0},{1}]= ", row, column);
                    matrix[row, column] = int.Parse(Console.ReadLine());
                }
            }
            int maxColumn = 0;
            int maxRow = 0;
            int MaxSum = SumMatrix(matrix, 0, 0);
            for (int row = 0; row <= m - 3; row++)
            {
                for (int column = 0; column <= n - 3; column++)
                {
                    int currentSum = SumMatrix(matrix, row, column);
                    if (currentSum >= MaxSum)
                    {
                        MaxSum = currentSum;
                        maxColumn = column;
                        maxRow = row;
                    }
                }
            }
            PrintMatrix(matrix, maxRow, maxColumn);
        }
    }
}