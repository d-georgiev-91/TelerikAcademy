using System;

namespace LeapYear
{
    class LeapYear
    {
        /*
         * 1. Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.
         */
        static void Main()
        {
            int year = 0;
            while (year < 1 || year > 9999)
            {
                Console.Write("Input year between 1 and 9999: ");
                year = int.Parse(Console.ReadLine());   
            }
            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine("The year is leap.");
            }
            else
            {
                Console.WriteLine("The year is not leap.");
            }
        }
    }
}
