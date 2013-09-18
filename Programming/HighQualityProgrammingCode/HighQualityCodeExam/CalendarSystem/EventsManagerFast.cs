namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionary<string, Event> eventsByTitle = new MultiDictionary<string, Event>(true);
        private readonly OrderedMultiDictionary<DateTime, Event> eventsByDate = new OrderedMultiDictionary<DateTime, Event>(true);

        public void AddEvent(Event ev)
        {
            string eventTitleLowerCase = ev.Title.ToLowerInvariant();
            this.eventsByTitle.Add(eventTitleLowerCase, ev);
            this.eventsByDate.Add(ev.Date, ev);
        }

        public int DeleteEventsByTitle(string title)
        {
            string eventTitleLowerCase = title.ToLowerInvariant();
            var eventsToDelete = this.eventsByTitle[eventTitleLowerCase];
            int deletedEventsCount = eventsToDelete.Count;

            foreach (var ev in eventsToDelete)
            {
                this.eventsByDate.Remove(ev.Date, ev);
            }

            this.eventsByTitle.Remove(eventTitleLowerCase);

            return deletedEventsCount;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var selectedEvents =
                    from ev in this.eventsByDate.RangeFrom(date, true).Values
                    select ev;
            var takenEvents = selectedEvents.Take(count);

            return takenEvents;
        }
    }
}