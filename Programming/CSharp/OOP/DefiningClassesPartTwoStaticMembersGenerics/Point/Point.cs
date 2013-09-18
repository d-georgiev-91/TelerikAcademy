using System;

namespace Point
{
    class Point
    {
        static void Main()
        {
            Console.WriteLine("The distance is {0:.##}", DistanceBetweenTwo3DPoints.CalculateDistance());
            Path path = new Path();
            path.AddPoint(3, 6, 7);
            path.AddPoint(31, 6, 63);
            path.AddPoint(32, 6153, 63);
            path.AddPoint(23.4, -24.6, 34.5);
            PathStorage.SavePath("test", path);
            Path pathLoadTest = new Path();
            pathLoadTest = PathStorage.LoadPath("test");
            foreach (var point in pathLoadTest.Points)
            {
                Console.WriteLine(point.ToString());
            }
        }
    }
}
