using System;

namespace DayOfWeekToday
{
    class DayOfWeekToday
    {
        static void Main()
        {
            DateTime dayNow = DateTime.Now;
            Console.WriteLine("Today is {0}.",dayNow.DayOfWeek);
        }
    }
}
