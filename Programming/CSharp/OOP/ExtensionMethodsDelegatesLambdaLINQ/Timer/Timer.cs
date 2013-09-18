using System;
using System.Threading;

namespace Timer
{
    public delegate void TimerDelegate(int runAtEveryTSeconds);
    class Timer
    {
        private TimerDelegate callback;
        private int runAtEveryTSeconds;
        private int start = 0;
        private int duration = 0;

        public Timer(int time, int duration, TimerDelegate callback)
        {
            this.runAtEveryTSeconds = time;
            this.callback = callback;
            this.start = 0;
            this.duration = duration;
        }

        public void Run()
        {
            while (start <= duration)
            {
                this.callback(runAtEveryTSeconds);
                Thread.Sleep(runAtEveryTSeconds * 1000);
                start += runAtEveryTSeconds;
            }
        }
    }
}
