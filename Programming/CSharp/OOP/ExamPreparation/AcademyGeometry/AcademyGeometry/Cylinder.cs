using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryAPI
{
    class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
    {
        public double Radius { get; private set; }

        public Cylinder(Vector3D top, Vector3D bottom, double radius)
            : base (top, bottom)
        {
            this.Radius = radius;   
        }

        public double GetArea()
        {
            double baseArea = GetBaseArea();
            double topAndBottomArea = 2 * baseArea;
            double height = GetHeight();
            double basePerimeter = 2 * Math.PI * this.Radius;
            double sideArea = basePerimeter * height;

            return sideArea + topAndBottomArea;
        }
  
        private double GetBaseArea()
        {
            double baseArea = Math.PI * this.Radius * this.Radius;
            return baseArea;
        }
  
        private double GetHeight()
        {
            double height = (this.vertices[0] - this.vertices[1]).Magnitude;
            return height;
        }

        public double GetVolume()
        {
            return this.GetArea() * this.GetHeight();   
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }
    }
}
