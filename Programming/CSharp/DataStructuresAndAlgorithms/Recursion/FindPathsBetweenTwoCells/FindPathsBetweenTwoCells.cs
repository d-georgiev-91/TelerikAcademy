namespace FindPathsBetweenTwoCells
{
    using System;

    class FindPathsBetweenTwoCells
    {
        private static char[,] theMatriX =
        {
            { 'X', ' ', ' ', 'X', ' ' },
            { 'X', 'X', ' ', 'X', 'X' },
            { ' ', ' ', ' ', 'X', ' ' },
            { ' ', 'X', ' ', ' ', ' ' },
            { ' ', ' ', ' ', 'X', ' ' },
        };

        static void Main()
        {
            Cell startCell = new Cell(0, 1);
            Cell endCell = new Cell(4, 4);
            FindPathBetween(startCell, endCell);
        }

        private static void FindPathBetween(Cell startCell, Cell endCell)
        {
            if (startCell.Row < 0 || startCell.Row >= theMatriX.GetLength(0) ||
                startCell.Col < 0 || startCell.Col >= theMatriX.GetLength(1))
            {
                return;
            }

            if (startCell == endCell)
            {
                ShowPath();
                return;
            }

            if (theMatriX[startCell.Row, startCell.Col] != ' ')
            {
                return;
            }

            theMatriX[startCell.Row, startCell.Col] = '*';

            FindPathBetween(new Cell(startCell.Row, startCell.Col - 1), endCell);
            FindPathBetween(new Cell(startCell.Row - 1, startCell.Col), endCell);
            FindPathBetween(new Cell(startCell.Row, startCell.Col + 1), endCell);
            FindPathBetween(new Cell(startCell.Row + 1, startCell.Col), endCell);

            theMatriX[startCell.Row, startCell.Col] = ' ';
        }

        private static void ShowPath()
        {
            string horizontalBorder = new String('_', theMatriX.GetLength(1) * 2 - 1);
            Console.WriteLine(horizontalBorder);

            for (int rowIndeX = 0; rowIndeX < theMatriX.GetLength(0); rowIndeX++)
            {
                for (int colIndeX = 0; colIndeX < theMatriX.GetLength(1); colIndeX++)
                {
                    if (colIndeX < theMatriX.GetLength(1) - 1)
                    {
                        Console.Write(theMatriX[rowIndeX, colIndeX] + " ");
                    }
                    else
                    {
                        Console.Write(theMatriX[rowIndeX, colIndeX]);
                    }
                    
                    if (colIndeX == theMatriX.GetLength(1) - 1)
                    {
                        Console.Write("|");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine(horizontalBorder + "|");
        }
    }
}