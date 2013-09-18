namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for managing events.
    /// </summary>
    public interface IEventsManager
    {
        /// <summary>
        /// Adds event of type <see cref="Event"/> to Events manager list.
        /// </summary>
        /// <param name="ev">The event that will be added</param>
        void AddEvent(Event ev);

        /// <summary>
        /// Removes all events, that matches given title from the Events manager list.
        /// </summary>
        /// <param name="title">Title that match the events</param>
        /// <returns>The count of delete events if such exist else returns 0.</returns>
        int DeleteEventsByTitle(string title);

        /// <summary>
        /// Returns the first N events that are less than the count and matches the date. 
        /// </summary>
        /// <param name="date">Events date to search for.</param>
        /// <param name="count">Events count to be listed.</param>
        /// <returns>Enumeration of events if such exist.</returns>
        IEnumerable<Event> ListEvents(DateTime date, int count);
    }
}