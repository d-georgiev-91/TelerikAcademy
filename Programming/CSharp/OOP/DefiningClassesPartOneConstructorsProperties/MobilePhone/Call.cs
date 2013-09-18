using System;
using System.Linq;
using System.Text;

namespace MobilePhone
{
    public class Call
    {
        private DateTime dateAndTime;
        private string dialedPhone;
        private int duration;

        public Call(DateTime dateAndTime, string dialedPhone, int duration)
        {
            this.dateAndTime = dateAndTime;
            this.dialedPhone = dialedPhone;
            this.duration = duration;
        }

        public DateTime DateAndTime
        {
            get { return this.dateAndTime; }
            set
            {
                if (value != null)
                {
                    this.dateAndTime = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public int Duration
        {
            get { return this.duration; }
            set
            {
                if (value != null)
                {
                    this.duration = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public string DialedPhone
        {
            get { return this.dialedPhone; }
            set
            {
                if (value != null)
                {
                    this.dialedPhone = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Date and time called: " + this.dateAndTime.ToString());
            result.AppendLine("Dialed number: " + this.dialedPhone.ToString());
            result.AppendLine("Call duration in seconds: " + this.duration.ToString());
            return result.ToString();
        }
    }
}
