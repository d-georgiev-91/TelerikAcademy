using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometryAPI
{
    public class Circle : Figure, IAreaMeasurable, IFlat
    {
        public double Radius { get; private set; }

        public Circle(Vector3D center, double radius) 
            : base(center)
        {
            this.Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public Vector3D GetNormal()
        {
            Vector3D center = this.GetCenter();
            Vector3D A = new Vector3D(center.X + this.Radius, center.Y, center.Z);
            Vector3D B = new Vector3D(center.X, center.Y + this.Radius, center.Z);
            Vector3D normal = Vector3D.CrossProduct(center - A, center - B);
            normal.Normalize();
            return normal;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }
    }
}
