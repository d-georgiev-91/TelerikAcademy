using System;
using System.Linq;

namespace BattleShips
{
    public class MatrixCoordinates
    {
        private int row;
        private int col;

        public MatrixCoordinates(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + row.GetHashCode();
                result = result * 23 + col.GetHashCode();
                return result;
            }
        }

        public bool Equals(MatrixCoordinates value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }
            if (ReferenceEquals(this, value))
            {
                return true;
            }
            return row == value.row &&
                col == value.col;
        }

        public override bool Equals(object obj)
        {
            MatrixCoordinates temp = obj as MatrixCoordinates;
            if (temp == null) return false;
            return Equals(temp);
        }

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
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
                col = value;
            }
        }
    }
}
