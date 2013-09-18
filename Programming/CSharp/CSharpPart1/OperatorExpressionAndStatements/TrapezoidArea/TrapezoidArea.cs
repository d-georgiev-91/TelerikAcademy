using System;

class TrapezoidArea
{
    static void Main()
    {
        double a, b, h;
        Console.Write("Input side A: ");
        a = double.Parse(Console.ReadLine());
        Console.Write("Input side B: ");
        b = double.Parse(Console.ReadLine());
        Console.Write("Input height: ");
        h = double.Parse(Console.ReadLine());
        double area = ( a + b ) * h / 2;
        Console.WriteLine("The area of the trapezoid is: " + area);
    }
}
