using System;
using System.Globalization;
using System.Linq;

namespace DateTimeToBulgarian.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DayToBulgarianService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DayToBulgarianService.svc or DayToBulgarianService.svc.cs at the Solution Explorer and start debugging.
    public class DayToBulgarianService : IServiceDayToBulgarian
    {
        public string GetDayInBulgarian(DateTime date)
        {
            CultureInfo bulgarianCulture = new CultureInfo("bg-BG");
            string day = bulgarianCulture.DateTimeFormat.DayNames[(int)date.DayOfWeek];

            return day;
        }
    }
}