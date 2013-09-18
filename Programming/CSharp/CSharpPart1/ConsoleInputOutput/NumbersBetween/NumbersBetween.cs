using System;

class NumbersBetween
{
    static void Main()
    {
        int firstArgument = 0, secondArgument = 0;
        Console.WriteLine("All arguments must be positive integer numbers!!!");
        while(firstArgument <= 0)
        {
            Console.Write("Input first argument: ");
            firstArgument = int.Parse(Console.ReadLine());
        }
        while (secondArgument <= 0)
        {
            Console.Write("Input second argument: ");
            secondArgument = int.Parse(Console.ReadLine());
        }
        int lowerArgument = 0;
        if (Math.Min(firstArgument, secondArgument) % 5 == 0)
        lowerArgument = 1;
        Console.WriteLine("p({0},{1})= {2}", firstArgument, secondArgument, (Math.Max(firstArgument, secondArgument) / 5 - Math.Min(firstArgument, secondArgument) / 5) + lowerArgument);
    }
}

