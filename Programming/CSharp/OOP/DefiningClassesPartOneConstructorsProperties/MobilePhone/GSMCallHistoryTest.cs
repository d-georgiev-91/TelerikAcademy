namespace MobilePhone
{
    using System;

    public class GsmCallHistoryTest
    {
        private readonly Gsm gsm = new Gsm("3310", "Nokia");

        public void Testing()
        {
            gsm.AddCall("12/3/2004 12:53:24", "0888123456", 53);
            gsm.AddCall("15/3/2004 03:52:12", "0888123456", 24);
            gsm.AddCall("16/3/2004 15:30:04", "0888125356", 553);
            gsm.AddCall("20/3/2004 02:13:37", "0888413456", 150);
            gsm.AddCall("31/3/2004 19:05:10", "0888122516", 215);
            gsm.PrintCallsInfo();

            Console.WriteLine("The total price is: " + gsm.CalculateTotalPriceOfCalls(0.37));
            int longestCall = gsm.CallHistory[0].Duration;

            for (int i = 1; i < gsm.CallHistory.Count; i++)
            {
                if (longestCall < gsm.CallHistory[i].Duration)
                {
                    longestCall = gsm.CallHistory[i].Duration;
                }
            }

            Console.WriteLine("\nTotal price after removing longest call...");
            gsm.DeleteCallByDuration(longestCall);
            Console.WriteLine("The total price is: " + gsm.CalculateTotalPriceOfCalls(0.37));

            Console.WriteLine();
            gsm.ClearCallHistory();
            gsm.PrintCallsInfo();
        }
    }
}
