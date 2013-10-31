using System;
namespace Point
{
    public static class DistanceBetweenTwo3DPoints
    {
        private static Point3D firstPoint = new Point3D(3, 5, 12);
        private static Point3D secondPoint = new Point3D(-3, 5, -42);

        public static double CalculateDistance()
        {
            double distance;
            distance = Math.Sqrt((firstPoint.X - secondPoint.X) * (firstPoint.X - secondPoint.X) + 
                               (firstPoint.Y - secondPoint.Y) * (firstPoint.Y - secondPoint.Y) + 
                               (firstPoint.X - secondPoint.X) * (firstPoint.Z - secondPoint.Z));
            return distance;
        }
    }
}
