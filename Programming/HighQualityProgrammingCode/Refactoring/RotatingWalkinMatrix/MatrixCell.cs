namespace RotatingWalkinMatrix
{
    using System;

    public class MatrixCell
    {
        private int row;
        private int col;

        public MatrixCell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Row cannot be negative!");
                }
                row = value;
            }
        }

        public int Col
        {
            get
            {
                return col;
            }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Col cannot be negative!");
                }
                col = value;
            }
        }
    }
}