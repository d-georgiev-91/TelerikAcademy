using System;
using System.Text;

namespace Point
{
    struct Point3D
    {
        private double x;
        private double y;
        private double z;
        private static readonly Point3D pointO = new Point3D(0, 0, 0);

        public Point3D(double x, double y, double z): this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D PointO
        {
            get { return pointO; }
        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{{{0}, {1}, {2}}}", this.X, this.Y, this.Z));
            return result.ToString();
        }
    }
}