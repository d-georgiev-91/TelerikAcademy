using System;

namespace SurfaceOfTriangle
{
    class SurfaceOfTriangle
    {
        /* 4. Write methods that calculate the surface of a triangle by given: 
         * Side and an altitude to it; Three sides; Two sides and an angle 
         * between them. Use System.Math.
         */
        static double TriangeSurfaceBySideAndAltitude(double a, double h)
        {
            return (a * h) / 2;
        }
        static double TriangleSurfaceByTwoSidesAndAngle(double a, double b, double angle)
        {
            angle *= Math.PI / 180;
            return (a * b * Math.Sin(angle)) / 2;
        }
        static double TriangleSurfaceByAllSides(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        static void Main()
        {
            Console.Write("Input a side: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Input an altitude to the side: ");
            double h = double.Parse(Console.ReadLine());
            Console.WriteLine("The surface is {0:0.##}", TriangeSurfaceBySideAndAltitude(a, h));
            Console.Write("Input a side: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Input a side: ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Input an angle between them in degrees: ");
            double angle = double.Parse(Console.ReadLine());
            Console.WriteLine("The surface is {0:0.##}", TriangleSurfaceByTwoSidesAndAngle(a, b, angle));
            Console.Write("Input a side: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Input a side: ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Input a side: ");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("The surface is {0:0.##}", TriangleSurfaceByAllSides(a, b, c));
        }
    }
}
