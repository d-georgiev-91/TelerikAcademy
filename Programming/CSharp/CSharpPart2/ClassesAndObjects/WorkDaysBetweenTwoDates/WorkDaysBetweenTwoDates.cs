using System;

namespace WorkDaysBetweenTwoDates
{
    class WorkDaysBetweenTwoDates
    {
        /* Uslovieto
         * 5. Write a method that calculates the number of 
         * workdays between today and given date, passed as 
         * parameter. Consider that workdays are all days 
         * from Monday to Friday except a fixed list of 
         * public holidays specified preliminary as array. */

        /* Oficialni praznici => http://bg.wikipedia.org/wiki/%D0%9E%D1%84%D0%B8%D1%86%D0%B8%D0%B0%D0%BB%D0%BD%D0%B8_%D0%BF%D1%80%D0%B0%D0%B7%D0%BD%D0%B8%D1%86%D0%B8_%D0%B2_%D0%91%D1%8A%D0%BB%D0%B3%D0%B0%D1%80%D0%B8%D1%8F 
         * E da, ama velikden nqma kak da go smqtam koga e!!! :D
         * "Формулата за определяне датата на Великден в 
         * западната и източната църква е еднаква: Страстната седмица е от понеделник до 
         * неделя след първото пролетно пълнолуние, а Великден е в неделния ден на Страстната седмица."
         */

        static int InputYear()
        {
            int year = 0;
            while (year < 1 || year > 9999)
            {
                Console.Write("Input year: ");
                year = int.Parse(Console.ReadLine());
            }
            return year;
        }

        static int InputMonth()
        {
               int maxMonthDays;
            int month = 0;
            while (month < 1 || month > 12)
            {
                Console.Write("Input month: ");
                month = int.Parse(Console.ReadLine());
            }
            return month;
        }

        static int InputDay(int year, int month)
        {
            int day = 0;
            while (day < 1 || day > DateTime.DaysInMonth(year, month))
            {
                Console.Write("Input day: ");
                day = int.Parse(Console.ReadLine());
            }
            return day;
        }

        static string InputDate()
        {
            int year = InputYear();
            int month = InputMonth();
            int day = InputDay(year, month);
            string result = String.Format("{0}-{1}-{2}", year.ToString(), month.ToString(), day.ToString());
            Console.WriteLine();
            return result;
        }

        static string DayAndMonth(DateTime date)
        {
            return date.Day.ToString() + "." + date.Month.ToString();
        }

        static ulong CalculateWorkingDays()
        {
            DateTime today = DateTime.Now;
            DateTime toDate = new DateTime(1, 1, 1);
            ulong workDays = 0;
            while (DateTime.Compare(today, toDate) > 0)
            {
                Console.WriteLine("Input date after today's!");
                toDate = DateTime.Parse(InputDate());
            }
            for (DateTime i = today; DateTime.Compare(i, toDate.AddDays(1)) <= 0 ; i = i.AddDays(1))
            {
                
                if (i.DayOfWeek != DayOfWeek.Sunday && i.DayOfWeek != DayOfWeek.Saturday && 
                    DayAndMonth(i)!= "1.1" && DayAndMonth(i) != "3.3" && DayAndMonth(i) != "1.5"
                    && DayAndMonth(i) != "6.5" && DayAndMonth(i) != "24.5" && DayAndMonth(i) != "6.9" &&
                    DayAndMonth(i) != "22.9" && DayAndMonth(i) != "1.11" && DayAndMonth(i) != "24.12" &&
                    DayAndMonth(i) != "25.12" && DayAndMonth(i) != "26.12")
                {
                    workDays++;
                }
            }
            return workDays;
        }
        static void Main()
        {
            
            Console.WriteLine("There are {0} workdays",CalculateWorkingDays());
        }
    }
}