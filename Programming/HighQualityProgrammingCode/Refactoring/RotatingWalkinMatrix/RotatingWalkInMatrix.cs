namespace RotatingWalkinMatrix
{
    using System;

    public class RotatingWalkInMatrix
    {
        private static int matrixSize;

        public static int MatrixSize
        {
            get
            {
                return matrixSize;
            }
            set
            {
                matrixSize = value;
            }
        }

        public static Direction GetNextDirection(Direction currentDirection)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < directionX.Length; i++)
            {
                if (directionX[i] == currentDirection.X && directionY[i] == currentDirection.Y)
                {
                    Direction nextDirection = new Direction(
                        directionX[(i + 1) % directionX.Length],
                        directionY[(i + 1) % directionY.Length]);
                    return nextDirection;
                }
            }

            throw new InvalidOperationException(
                string.Format("Could not find next direction x: {0}, y: {1}", currentDirection.X, currentDirection.Y));
        }

        public static bool CheckMatrix(int[,] arr, int x, int y)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (x + directionX[i] >= arr.GetLength(0) || x + directionX[i] < 0)
                {
                    directionX[i] = 0;
                }

                if (y + directionY[i] >= arr.GetLength(0) || y + directionY[i] < 0)
                {
                    directionY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + directionX[i], y + directionY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static MatrixCell GetFirstEmptyCell(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        MatrixCell emptyCell = new MatrixCell(row, col);
                        return emptyCell;
                    }
                }
            }
            return null;
        }

        public static void Main(string[] args)
        {
            MatrixSize = ReadMatrixSize();
            int[,] matrix = GenerateRotatingMatrix(MatrixSize);
            PrintMatrix(matrix);
        }

        public static int[,] GenerateRotatingMatrix(int MatrixSize)
        {
            int[,] matrix = new int[MatrixSize, MatrixSize];

            int currentNumber = 1;
            MatrixCell currentCell = new MatrixCell(0,0);
            Direction currentDirection = new Direction(1, 1);

            FillMatrixWhilePossible(matrix, currentCell, MatrixSize, ref currentDirection, ref currentNumber);

            currentNumber++;

            currentCell = GetFirstEmptyCell(matrix);
            if (currentCell != null)
            {
                if (currentCell.Row != 0 && currentCell.Col != 0)
                { 
                    currentDirection.X = 1;
                    currentDirection.Y = 1;

        
                    FillMatrixWhilePossible(matrix, currentCell, MatrixSize, ref currentDirection, ref currentNumber);
                }
            }
            return matrix;
        }
  
        private static void FillMatrixWhilePossible(int[,] matrix, MatrixCell currentCell, int MatrixSize, ref Direction currentDirection, ref int currentNumber)
        {

            while (true)
            {
                matrix[currentCell.Row, currentCell.Col] = currentNumber;


                if (!CheckMatrix(matrix, currentCell.Row, currentCell.Col))
                {
                    break;
                }
                  
                while (IsNextCellAvailable(currentCell, currentDirection, MatrixSize, matrix))
                {
                    currentDirection = GetNextDirection(currentDirection);
                }

                currentCell.Row += currentDirection.X;
                currentCell.Col += currentDirection.Y;
                currentNumber++;
            }
        }
  
        private static bool IsNextCellAvailable(MatrixCell cell, Direction currentDirection, int MatrixSize, int[,] matrix)
        {
            return cell.Row + currentDirection.X >= MatrixSize || cell.Row + currentDirection.X < 0 || cell.Col + currentDirection.Y >= MatrixSize ||
                   cell.Col + currentDirection.Y < 0 || matrix[cell.Row + currentDirection.X, cell.Col + currentDirection.Y] != 0;
        }

        private static int ReadMatrixSize()
        {
            Console.Write("Enter a positive number ");
            int number = int.Parse(Console.ReadLine());
            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException("Number should be in range [1, 100]!");
            }

            return number;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int spaceSeparatorCount = (int)(Math.Log10(MatrixSize) + 2);
            for (int row = 0; row < MatrixSize; row++)
            {
                Console.Write("{");
                for (int col = 0; col < MatrixSize; col++)
                {
                    if (col == MatrixSize - 1)
                    {
                        Console.Write("{0, 3}", matrix[row, col]);
                    }
                    else
                    {
                        Console.Write("{0," + spaceSeparatorCount + "}, ", matrix[row, col]);
                    }
                }
                Console.WriteLine("},");
            }
        }
    }
}