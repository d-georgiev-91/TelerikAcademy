using System;

class PrintIntegerSum
{
    static void Main()
    {
        int firstNumber, secondNumber, thirdNumber;
        Console.Write("Input the first number: ");
        firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Input the second number: ");
        secondNumber = int.Parse(Console.ReadLine());
        Console.Write("Input the third number: ");
        thirdNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("The first number is: {0}, the second is {1} and third is {2}.", firstNumber, secondNumber, thirdNumber );
    }
}
