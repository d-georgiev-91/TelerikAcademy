using System;
using System.Collections.Generic;

namespace Point
{
    internal class Path
    {
        private int length;
        private List<Point3D> points = new List<Point3D>();

        public List<Point3D> Points
        {
            get
            {
                return this.points;
            }
            set
            {
                this.points = value;
            }
        }

        public int Length
        {
            get
            {
                return this.length;
            }
        }

        public Path(int length) : this()
        {
            this.length = length;
        }

        public Path()
        {
            this.length = 0;
        }

        public void AddPoint(double x, double y, double z)
        {
            Point3D point = new Point3D(x, y, z);
            Points.Add(point);
            this.length++;
        }
    }
}