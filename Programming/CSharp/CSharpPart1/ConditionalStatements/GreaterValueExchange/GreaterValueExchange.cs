using System;

class GreaterValueExchange
{
    static void Main()
    {
        int firstInteger, secondInteger;
        Console.Write("Input the first integer: ");
        firstInteger = int.Parse(Console.ReadLine());
        Console.Write("Input the second integer: ");
        secondInteger = int.Parse(Console.ReadLine());
        if (firstInteger > secondInteger)
        {
            firstInteger += secondInteger;
            secondInteger = firstInteger - secondInteger;
            firstInteger -= secondInteger;
        }
        Console.WriteLine("The first integer is {0}, the second integer is {1}", firstInteger, secondInteger);
    }
}