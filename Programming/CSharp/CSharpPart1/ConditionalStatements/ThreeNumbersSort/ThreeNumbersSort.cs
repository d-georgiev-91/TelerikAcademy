using System;

class ThreeNumbersSort
{
    static void Swap(ref double firstArg, ref double secondArg)
    {
        double temp;
        temp = firstArg;
        firstArg = secondArg;
        secondArg = temp;
    }
    static void Main()
    {
        double firstNumber, secondNumber, thirdNumber;
        Console.Write("Input the first number: ");
        firstNumber = double.Parse(Console.ReadLine());
        Console.Write("Input the second number: ");
        secondNumber = double.Parse(Console.ReadLine());
        Console.Write("Input the third number: ");
        thirdNumber = double.Parse(Console.ReadLine());
        if (firstNumber < secondNumber)
        {
            if (firstNumber < thirdNumber)
            {
                if (secondNumber < thirdNumber)
                {
                    Console.WriteLine("{0}, {1}, {2}", firstNumber, secondNumber, thirdNumber);
                }
                else
                {
                    Console.WriteLine("{0}, {1}, {2}", firstNumber, thirdNumber, secondNumber);
                }
            }
            else
            {
                Console.WriteLine("{0}, {1}, {2}", thirdNumber, firstNumber,secondNumber);
            }
        }
        else if (secondNumber < thirdNumber)
        {
            if (firstNumber < thirdNumber)
            {
                Console.WriteLine("{0}, {1}, {2}", secondNumber, firstNumber, thirdNumber);
            }
            else
            {
                Console.WriteLine("{0}, {1}, {2}", secondNumber, thirdNumber, firstNumber);
            }
        }
        else
        {
            Console.WriteLine("{0}, {1}, {2}", thirdNumber, secondNumber, firstNumber);
        }
    }
}
