using System;

class SequenceSum
{
    static void Main()
    {
        double sumTotal = 1;
        double sumLast;
        sbyte sing;
        double denominator = 2;
        do
        {
            sumLast = sumTotal;
            if (denominator % 2 == 0)
                sing = 1;
            else
                sing = -1;
            sumTotal = sumLast + sing * (1 / denominator);
            denominator++;
        }
        while (Math.Abs(sumTotal - sumLast) >= 0.001);
        Console.WriteLine(sumTotal);
    }
}
