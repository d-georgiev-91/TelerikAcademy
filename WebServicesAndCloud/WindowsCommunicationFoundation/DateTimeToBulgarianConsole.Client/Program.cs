namespace DateTimeToBulgarianConsole.Client
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using DateTimeToBulgarianConsole.Client.DayToBulgarianServiceReference;

    class Program
    {
        static void Main()
        {
            ServiceDayToBulgarianClient client = new ServiceDayToBulgarianClient();
            var date = InputDate();
            Console.WriteLine(client.GetDayInBulgarian(date));
        }

        private static DateTime InputDate()
        {
            DateTime date;
            string inputString = null;

            while (true)
            {
                try
                {
                    Console.Write("Enter date: ");
                    inputString = Console.ReadLine();
                    date = DateTime.Parse(inputString);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("'{0}' is not valid date format",inputString);
                }
            }

            return date;
        }
    }
}
