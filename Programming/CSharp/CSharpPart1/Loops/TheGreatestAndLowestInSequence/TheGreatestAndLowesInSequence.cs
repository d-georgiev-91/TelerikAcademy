using System;

class TheGreatestAndLowesInSequence
{
    static void Main()
    {
        Console.Write("Input n: ");
        uint n = uint.Parse(Console.ReadLine());
        int number, theGreater = 1, theLowest = 1;
        for (int i = 1; i <= n; i++)
        {
            Console.Write("Input a number: ");
            number = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                theGreater = number;
                theLowest = number;
            }
            if (theGreater <= number)
            {
                theGreater = number;
            }
            if (theLowest >= number)
            {
                theLowest = number;
            }
        }
        Console.WriteLine("The greatest number in sequence is: " + theGreater + " and the lowest is: " + theLowest);
    }
}