using System;
using System.Linq;

namespace Timer
{
    class TimerTest
    {
        public static void Method(int time)
        {
            Console.WriteLine("I'm called at every {0} seconds.", time);
        }

        static void Main()
        {
            Timer timer = new Timer(5, 10, Method);
            timer.Run();
        }
    }
}
