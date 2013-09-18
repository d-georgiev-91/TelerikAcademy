using System;
using System.IO;

namespace MaxSubmatrixSum
{
    class MaxSubmatrixSum
    {
        /* 5. Write a program that reads a text file containing a square matrix of numbers 
         * and finds in the matrix an area of size 2 x 2 with a maximal sum of its elements. 
         * The first line in the input file contains the size of matrix N. Each of the next N 
         * lines contain N numbers separated by space. The output should be a single number in 
         * a separate text file. Example:
         * 4
         * 2 3 3 4
         * 0 2 3 4	= > 17
         * 3 7 1 2
         * 4 3 3 2 */

        static int SumMatrix(int[,] matrix, int currentRow, int currentColumn)
        {
            int sum = 0;
            for (int row = 0; row < 2; row++)
            {
                for (int column = 0; column < 2; column++)
                {
                    sum += matrix[row + currentRow, column + currentColumn];
                }
            }
            return sum;
        }

        static int MaxSum(int [,] matrix, int n)
        {
            int maxSum = SumMatrix(matrix, 0, 0);
            for (int row = 0; row <= n - 2; row++)
            {
                for (int column = 0; column <= n - 2; column++)
                {
                    int currentSum = SumMatrix(matrix, row, column);
                    if (currentSum >= maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
            return maxSum;
        }

        static void Main()
        {
            StreamReader matrixFile = new StreamReader("Matrix.txt");
            int n = int.Parse(matrixFile.ReadLine());
            Console.WriteLine(n);
            int [,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                string[] line = matrixFile.ReadLine().Split(' ');
                for (int column = 0; column < n; column++)
                {
                    matrix[row, column] = int.Parse(line[column]);
                }
            }
            matrixFile.Close();
            Console.WriteLine("The max sum is {0}", MaxSum(matrix, n));
        }
    }
}
