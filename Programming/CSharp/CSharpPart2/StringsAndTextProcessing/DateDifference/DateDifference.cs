using System;
using System.Globalization;

namespace DateDifference
{
    class DateDifference
    {
        /* 16. Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. */
        static void Main()
        {
            Console.WriteLine("Input two dates in the format\nday.month.year ...");
            try
            {
                Console.Write("Enter the first date: ");
                string firstDateInString = Console.ReadLine();
                DateTime firstDate = DateTime.Parse(firstDateInString);
                Console.Write("Enter the second date: ");
                string secondDateInString = Console.ReadLine();
                DateTime secondDate = DateTime.Parse(secondDateInString);
                Console.WriteLine("Distance {0} days", (firstDate - secondDate).Days);
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid date!");
            }
        }
    }
}
