using System;

class Program
{
    static void Main()
    {
       int firstNumber, secondNumber;
       Console.Write("Input the first number: ");
       firstNumber = int.Parse(Console.ReadLine());
       Console.Write("Input the second number: ");
       secondNumber = int.Parse(Console.ReadLine());
       int theGreaterNumber = firstNumber - ((firstNumber - secondNumber) & ((firstNumber - secondNumber) >> 31));
       Console.WriteLine("The greater number is {0} ", theGreaterNumber);
    }
}

