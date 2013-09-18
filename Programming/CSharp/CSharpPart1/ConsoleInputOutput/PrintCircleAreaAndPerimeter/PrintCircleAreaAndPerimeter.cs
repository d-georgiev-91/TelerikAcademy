using System;

class PrintCircleAreaAndPerimeter
{
    static void Main()
    {
        Console.Write("Input your radius: ");
        double radius = double.Parse(Console.ReadLine());
        double pi = Math.PI;
        double perimeter = 2 * pi * radius;
        double area = pi * radius * radius;
        Console.WriteLine("The Area is {0:F2}, and perimeter is {1:F2}.", area, perimeter);
    }
}
