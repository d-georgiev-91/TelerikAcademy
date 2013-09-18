using System;

namespace ShapeCalculator
{
    public abstract class Shape
    {
        private double width;
        private double height;

        public Shape(double width, double height)
        {
            this.Height = height;
            this.Width = width;
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
                    throw new ArgumentException("Heighth must be greater than zero.");
                }
            }
        }

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
                    throw new ArgumentException("Width must be greater than zero.");
                }
            }
        }

        public abstract double CalculateSurface();
    }
}
