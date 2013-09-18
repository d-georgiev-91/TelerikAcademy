using System;

class InCircleAndOutRectangle
{
    static void Main()
    {
        Console.Write("Input x: ");
        int xPoint = int.Parse(Console.ReadLine());
        Console.Write("Input y: ");
        int yPoint = int.Parse(Console.ReadLine());
        bool withinInCircle = (xPoint-1) * (xPoint-1) + (yPoint-1) * (yPoint-1) <= 3 * 3;
        bool outOfRectangle = !((xPoint >= -1 && xPoint <= 5) && (yPoint >= -1 && yPoint <= 1));
        bool isInCircleButOutRectangle = withinInCircle && outOfRectangle;
        Console.WriteLine(isInCircleButOutRectangle);
    }
}
