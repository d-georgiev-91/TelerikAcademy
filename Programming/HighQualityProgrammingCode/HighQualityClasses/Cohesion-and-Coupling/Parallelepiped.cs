using System;

namespace CohesionAndCoupling
{
    class Parallelepiped
    {
        private double width;
        private double height;
        private double depth;
                
        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width mush be positive number!");
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Width mush be positive number!");
                }
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }
            set
            {
                if (value > 0)
                {
                    this.depth = value;
                }
                else
                {
                    throw new ArgumentException("Width mush be positive number!");
                }
            }
        }

        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public  double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public  double CalcDiagonalXYZ()
        {
            double distance = DistanceCalculator.CalcDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        public  double CalcDiagonalXY()
        {
            double distance = DistanceCalculator.CalcDistance2D(0, 0, Width, Height);
            return distance;
        }

        public  double CalcDiagonalXZ()
        {
            double distance = DistanceCalculator.CalcDistance2D(0, 0, Width, Depth);
            return distance;
        }

        public  double CalcDiagonalYZ()
        {
            double distance = DistanceCalculator.CalcDistance2D(0, 0, Height, Depth);
            return distance;
        }
    }
}