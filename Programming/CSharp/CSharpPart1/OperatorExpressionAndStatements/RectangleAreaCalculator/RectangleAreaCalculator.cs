using System;

class RectangleAreaCalculator
{
    static void Main()
    {
        Console.Write("Input width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Input height: ");
        double height = double.Parse(Console.ReadLine());
        double area = height * width;
        Console.WriteLine("The are is: {0}", area);
    }
}