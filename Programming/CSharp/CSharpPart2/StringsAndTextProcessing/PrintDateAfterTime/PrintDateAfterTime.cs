using System;

namespace PrintDateAfterTime
{
    class PrintDateAfterTime
    {
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("bg-BG");
            Console.WriteLine("Give date in the format\nday.month.year hour:minute:second");
            DateTime dateAndTime = DateTime.Parse(Console.ReadLine());
            dateAndTime = dateAndTime.AddMinutes(30);
            dateAndTime = dateAndTime.AddHours(6);
            Console.WriteLine("The time after 6 hours and 30 minutes will be {0}", dateAndTime);
        }
    }
}
