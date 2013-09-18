using System;

class SingOfProductOfThreeRealNumbers
{
    static void Main()
    {
        double firstNumber, secondNumber, thirdNumber;
        Console.Write("Input the first number: ");
        firstNumber = double.Parse(Console.ReadLine());
        Console.Write("Input the second number: ");
        secondNumber = double.Parse(Console.ReadLine());
        Console.Write("Input the third number: ");
        thirdNumber = double.Parse(Console.ReadLine());
        int minus = 0;
        if (firstNumber < 0)
        {
            minus++;
        }
        if (secondNumber < 0)
        {
            minus++;
        }
        if (thirdNumber < 0)
        {
            minus++;
        }
        if (minus % 2 == 0)
        {
            Console.WriteLine("The sing is \"+\" ");
        }
        else
        {
            Console.WriteLine("The sing is \"-\" ");
        }
    }
}
