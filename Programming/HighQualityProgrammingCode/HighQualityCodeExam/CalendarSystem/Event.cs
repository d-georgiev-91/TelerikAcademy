using System;

namespace CalendarSystem
{
    public class Event : IComparable<Event>
    {
        public DateTime Date { get; private set; }

        public string Title { get; private set; }

        public string Location { get; private set; }

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public override string ToString()
        {
            string dateFormat = "{0:yyyy-MM-ddTH:mm:ss} | {1}";

            if (this.Location != null)
            {
                dateFormat += " | {2}";
            }

            string eventAsString = string.Format(dateFormat, this.Date, this.Title, this.Location);

            return eventAsString;
        }

        public int CompareTo(Event ev)
        {
            int result = DateTime.Compare(this.Date, ev.Date);

            if (result == 0)
            {
                result = string.Compare(this.Title, ev.Title, StringComparison.Ordinal);
            }

            if (result == 0)
            {
                result = string.Compare(this.Location, ev.Location, StringComparison.Ordinal);
            }
            
            return result;
        }
    }
}