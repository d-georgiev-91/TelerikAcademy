using System;
using System.Collections.Generic;
using System.IO;

namespace Point
{
    public static class PathStorage
    {
        public static void SavePath(string pathName, Path path)
        {
            StreamWriter pathsStorage = new StreamWriter(@"../../" + pathName + ".ptp");

            foreach (var point in path.Points)
            {
                pathsStorage.WriteLine(point.ToString());
            }

            pathsStorage.Close();
        }

        public static Path LoadPath(string pathName)
        {
            Path pathToLoad = new Path();
            StreamReader pathsStorage = new StreamReader(@"../../" + pathName + ".ptp");
            string line = pathsStorage.ReadLine();

            while (line != null)
            {

                    Point3D point = new Point3D();
                    string[] points = line.Split(new char[] { ',', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
                    point.X = double.Parse(points[0]);
                    point.Y = double.Parse(points[1]);
                    point.Z = double.Parse(points[2]);
                    pathToLoad.Points.Add(point);
                    line = pathsStorage.ReadLine();
            }

            pathsStorage.Close();

            return pathToLoad;
        }
    }
}
