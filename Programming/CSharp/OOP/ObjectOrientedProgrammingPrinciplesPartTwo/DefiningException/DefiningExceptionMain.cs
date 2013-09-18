using System;
using System.Linq;

namespace DefiningException
{
    class DefiningExceptionMain
    {
        static void Main()
        {
            //DateTime startDate = DateTime.Parse("12/12/2003");
            //DateTime endDate = DateTime.Parse("12/12/2005");

            //DateTime date;
            //Console.Write("Enter a date in format dd/mm/yyyy: ");
            //date = DateTime.Parse(Console.ReadLine());

            //if (date < startDate || date > endDate)
            //{
            //    throw new InvalidRangeException<DateTime>("Date not in range", startDate, endDate);
            //}

            int firstNumber = int.Parse("10");
            int endNumber = int.Parse("50");

            int number;
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());

            if (number < firstNumber || number > endNumber)
            {
                throw new InvalidRangeException<int>("Int not in range", firstNumber, endNumber);
            }
        }
    }
}
