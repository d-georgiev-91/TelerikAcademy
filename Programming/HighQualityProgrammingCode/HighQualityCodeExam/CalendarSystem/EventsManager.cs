namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventsManager : IEventsManager
    {
        private readonly List<Event> events = new List<Event>();

        public void AddEvent(Event ev)
        {
            this.events.Add(ev);
        }

        public int DeleteEventsByTitle(string title)
        {
            var remainingEvents = this.events.RemoveAll(ev => ev.Title.ToLowerInvariant() == title.ToLowerInvariant());
            return remainingEvents;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var selectedEvents =
                                from ev in this.events
                                where ev.Date >= date
                                orderby ev.Date, ev.Title, ev.Location
                                select ev;
            var takenEvents = selectedEvents.Take(count);
            return takenEvents;
        }
    }
}