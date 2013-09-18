using System;

class IsThirdDigit7
{
    static void Main()
    {
        Console.Write("Input a number: ");
        int myNumber = int.Parse(Console.ReadLine());
        bool thridDigit = (myNumber / 100 % 10 % 7 == 0);

    }
}