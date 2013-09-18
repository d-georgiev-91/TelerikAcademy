using System;

class AgeAfter10Years
{
    static void Main()
    {
        Console.Write("Input your age at " + DateTime.Now + " - ");
        int inputAge = int.Parse(Console.ReadLine());
        Console.WriteLine("Your age after 10 years /on " + DateTime.Now.AddYears(10) + "/ will be: " + (inputAge+10));
    }
}
