using System;

class FloatPrecisionComparasion
{
    static void Main()
    {
        Console.Write("Input the first value, that you want to compare: ");
        float firstVarible = float.Parse(Console.ReadLine());
        Console.Write("Input the second value: ");
        float secondVarible = float.Parse(Console.ReadLine());
        if (Math.Abs(firstVarible - secondVarible) < 0.000001)
            Console.WriteLine("True");
        else
            Console.WriteLine("False");
    }
}

