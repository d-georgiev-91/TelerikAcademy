using System;

namespace ShapeCalculator
{
    public class Circle : Shape
    {
        public Circle(double radius) : base(radius, radius)
        {
        }

        public override double CalculateSurface()
        {
            double radius = this.Height;
            return Math.PI * radius * radius;
        }
    }
}