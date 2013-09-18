using System;

class Program
{
    static void Main()
    {
        int theGreatest , theNumbers;
        Console.Write("Input a number: ");
        theNumbers = int.Parse(Console.ReadLine());
        theGreatest = theNumbers;
        for (int i = 0; i < 4; i++)
        {
            Console.Write("Input a number: ");
            theNumbers = int.Parse(Console.ReadLine());
            if (theGreatest < theNumbers)
            {
                theGreatest = theNumbers;
            }
        }
        Console.WriteLine("The greates is " + theGreatest + ".");
    }
}
