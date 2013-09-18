using System;

class SpiralMatrixPrint
{
    static void Main()
    {
        int n = 0;
        while (n < 1 || n > 20)
        {
            Console.Write("Input positive N and less then 20: ");
            n = int.Parse(Console.ReadLine());
        }
        int [,] spiralMatrix = new int[n, n];
        int upperColumnBound = (int)(n - 1);
        int lowerColumnBound = 0;
        int upperRowBound = (int)(n - 1);
        int lowerRowBound = 0;
        int value = 1;
        int columnIndex, rowIndex;
        do
        {
            Console.WriteLine(value + "mai si cikli a");
            for (columnIndex = lowerColumnBound; columnIndex <= upperColumnBound; columnIndex++)
            {
                spiralMatrix[lowerRowBound, columnIndex] = value;
                value++;
            }
            lowerRowBound++;
            for (rowIndex = lowerRowBound ; rowIndex <= upperRowBound; rowIndex++)
            {
                spiralMatrix[rowIndex, upperColumnBound] = value;
                value++;
            }
            upperColumnBound--;
            for (columnIndex = upperColumnBound; columnIndex >= lowerColumnBound; columnIndex--)
            {
                spiralMatrix[upperRowBound, columnIndex] = value;
                value++;
            }
            upperRowBound--;
            for (rowIndex = upperRowBound; rowIndex >= lowerRowBound; rowIndex--)
            {
                spiralMatrix[rowIndex, lowerColumnBound] = value;
                value++;
            }
            lowerColumnBound++;
        }
        while (value <= n * n);

        Console.WriteLine();
        for (int rows = 0; rows < n; rows++)
        {
            for (int columns = 0; columns < n; columns++)
            {
                if (spiralMatrix[rows, columns] < 10)
                {
                    Console.Write(spiralMatrix[rows, columns] + "   ");
                }
                else if (spiralMatrix[rows, columns] < 100)
                {
                    Console.Write(spiralMatrix[rows, columns] + "  ");
                }
                else
                {
                    Console.Write(spiralMatrix[rows, columns] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}