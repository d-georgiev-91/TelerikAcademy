namespace RotatingWalkinMatrix
{
    using System;

    public class Direction
    {
        private int x;
        private int y;

        public Direction(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (-1 <= value && value <= 1)
                {
                    this.x = value;
                }
                else
                {
                    throw new ArgumentException("Invalid direction. Direction should be in range [-1,1].");
                }
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (-1 <= value && value <= 1)
                {
                    this.y = value;
                }
                else
                {
                    throw new ArgumentException("Invalid direction. Direction should be in range [-1,1].");
                }
            }
        }
    }
}