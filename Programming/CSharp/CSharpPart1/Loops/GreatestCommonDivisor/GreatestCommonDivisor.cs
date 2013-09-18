using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        int firstNumber, secondNumber;
        Console.Write("Input first number: ");
        firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Input second number: ");
        secondNumber = int.Parse(Console.ReadLine());
        int remainder = 1;
        int divisor = Math.Min(firstNumber, secondNumber);
        int dividend = Math.Max(firstNumber, secondNumber);
        do
        {
            remainder = dividend % divisor;
            if (remainder != 0)
            {
                dividend = divisor;
                divisor = remainder;
            }
        }
        while (remainder != 0);
        Console.WriteLine("The greatest common divisor of {0} and {1} is: {2}", firstNumber, secondNumber, divisor);
    }
}