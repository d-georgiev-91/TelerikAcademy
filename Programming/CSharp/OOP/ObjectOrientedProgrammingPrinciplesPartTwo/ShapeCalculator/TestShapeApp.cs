using System;

namespace ShapeCalculator
{
    class TestShapeApp
    {
        static void Main()
        {
            Shape[] figures = {
                new Rectangle(3.6, 6.2),
                new Rectangle(24, 5),
                new Circle(6.5),
                new Circle(10),
                new Triangle(53, 5),
                new Triangle(3, 5.5),
            };

            foreach (var figure in figures)
            {
                Console.WriteLine("This is a {0} with area {1:.##}", 
                    figure.GetType().ToString().Replace("ShapeCalculator.", String.Empty).ToLower(),
                    figure.CalculateSurface());
            }
        }
    }
}
