﻿using System;
using System.Linq;

namespace ShapeCalculator
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            : base(width, height) { }

        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
