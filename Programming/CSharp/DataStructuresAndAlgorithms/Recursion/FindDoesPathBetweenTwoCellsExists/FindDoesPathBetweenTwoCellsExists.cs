namespace FindDoesPathBetweenTwoCellsExists
{
    using System;

    class FindDoesPathBetweenTwoCellsExists
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

            //Cell startCell = new Cell(0, 4);
            //Cell endCell = new Cell(4, 4);

            FindPathBetween(startCell, endCell);
            Console.WriteLine("No such path exsists.");
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
                Console.WriteLine("Exit found!");
                Environment.Exit(0);
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
    }
}