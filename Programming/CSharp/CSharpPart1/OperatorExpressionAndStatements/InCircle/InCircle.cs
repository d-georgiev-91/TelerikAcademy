using System;

class InCircle
{
    static void Main()
    {
        Console.Write("Input x: ");
        int xPoint = int.Parse(Console.ReadLine());
        Console.Write("Input y: ");
        int yPoint = int.Parse(Console.ReadLine());
        bool withinInCircle = (xPoint * xPoint + yPoint * yPoint) <= 5*5;
        Console.WriteLine(withinInCircle);
    }
}