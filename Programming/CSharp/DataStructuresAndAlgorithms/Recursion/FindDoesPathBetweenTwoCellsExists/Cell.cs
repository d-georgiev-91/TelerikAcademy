namespace FindDoesPathBetweenTwoCellsExists
{
    class Cell
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public static bool operator ==(Cell firstCell, Cell secondCell)
        {
            return firstCell.Row == secondCell.Row && firstCell.Col == secondCell.Col;
        }

        public static bool operator !=(Cell firstCell, Cell secondCell)
        {
            return !(firstCell == secondCell);
        }
    }
}