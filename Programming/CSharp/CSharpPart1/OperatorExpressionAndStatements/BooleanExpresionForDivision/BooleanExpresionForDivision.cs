using System;

class BooleanExpresionForDivision
{
    static void Main()
    {
        Console.Write("Please, input a number: ");
        int myInt = int.Parse(Console.ReadLine());
        bool expresionForDivision = (myInt % 7 == 0) && (myInt% 5 == 0);
        Console.WriteLine(expresionForDivision);
    }
}