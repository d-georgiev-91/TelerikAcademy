using System;

class QuadraticEquasion
{
    static void Main()
    {
        double a, b, c, D;
        Console.Write("Input a: ");
        a = double.Parse(Console.ReadLine());
        Console.Write("Input b: ");
        b = double.Parse(Console.ReadLine());
        Console.Write("Input c: ");
        c = double.Parse(Console.ReadLine());
        D = b * b - 4 * a * c;
        if (a == 0)
            Console.WriteLine("The result is x= {0:F2}", -c / b);
        else
        {
            if (D < 0)
                Console.WriteLine("No real roots");
            else if (D == 0)
                Console.WriteLine("The result is x1=x2= {0:F2}", -b / 2 * a);
            else
                Console.WriteLine("The result is x1= {0:F2}, x2= {1:F2}", (-b - Math.Sqrt(D)) / 2, (-b + Math.Sqrt(D)) / 2);
        }
    }
}

