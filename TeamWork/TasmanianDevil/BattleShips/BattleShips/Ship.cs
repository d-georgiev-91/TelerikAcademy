using System;
using System.Linq;

namespace BattleShips
{
    public abstract class Ship : IShipable
    {
        public const int Length = 0;
        public const char Symbol = 's';
        private Orientation orientation;
        private MatrixCoordinates topLeft;
        private bool isDestroyed;
        private int hitCounter = 0;

        public Ship(Orientation orientation, MatrixCoordinates topLeft)
        {
            this.Orientation = orientation;
            this.TopLeft = topLeft;
            this.isDestroyed = false;
        }
        
        public bool IsDestroyed
        {
            get
            {
                return isDestroyed;
            }
            private set
            {
                isDestroyed = value;
            }
        }

        public Orientation Orientation
        {
            get
            {
                return orientation;
            }
            private set
            {
                orientation = value;
            }
        }

        public MatrixCoordinates TopLeft
        {
            get
            {
                return topLeft;
            }
            set
            {
                topLeft = value;
            }
        }

        private void IsShipDestroyed()
        {
            if (hitCounter == this.GetShipLength())
            {
                this.isDestroyed = true;
            }
        }

        public bool IsHit(MatrixCoordinates hitPoint)
        {
            if (this.Orientation == Orientation.Horizontal)
            {
                for (int i = 0; i < this.GetShipLength(); i++)
                {
                    if (this.TopLeft.Row == hitPoint.Row && this.TopLeft.Col + i == hitPoint.Col)
                    {
                        this.hitCounter++;
                        IsShipDestroyed();
                        return true;
                    }
                }

                return false;
            }

            if (this.Orientation == Orientation.Vertical)
            {
                for (int i = 0; i < this.GetShipLength(); i++)
                {
                    if (this.TopLeft.Row + i == hitPoint.Row && this.TopLeft.Col == hitPoint.Col)
                    {
                        this.hitCounter++;
                        IsShipDestroyed();
                        return true;
                    }
                }
            }

            return false;
        }

        public MatrixCoordinates GetTopLeftPosition()
        {
            return this.TopLeft;
        }

        public virtual int GetShipLength()
        {
            return Ship.Length;
        }

        public Orientation GetOrientation()
        {
            return this.Orientation;
        }

        public virtual char GetSymbol()
        {
            return Ship.Symbol;
        }
    }
}