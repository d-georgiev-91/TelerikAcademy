namespace CalendarSystem
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class CommandProcessor
    {
        private readonly IEventsManager eventsManager;

        public CommandProcessor(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        public IEventsManager EventsProcessor
        {
            get
            {
                return this.eventsManager;
            }
        }

        public string ProcessCommand(Command command)
        {
            switch (command.Name)
            {
                case "AddEvent":
                   return this.AddEvent(command);
                case "DeleteEvents":
                    return this.DeleteEvents(command);
                case "ListEvents":
                    return this.ListEvents(command);
                default:
                    throw new ArgumentException("Uknown command: " + command.Name);
            }
        }

        #region AddEvent
        private string AddEvent(Command command)
        {
            if (command.Parameters.Length == 2)
            {
                this.AddEventWithOutLocation(command);
            }

            if (command.Parameters.Length == 3)
            {
                this.AddEventWithLocation(command);
            }

            return "Event added";
        }

        private void AddEventWithLocation(Command command)
        {
            DateTime date = DateTime.ParseExact(command.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string title = command.Parameters[1];
            string location = command.Parameters[2];

            Event ev = new Event(date, title, location);

            this.eventsManager.AddEvent(ev);
        }

        private void AddEventWithOutLocation(Command command)
        {
            DateTime date = DateTime.ParseExact(command.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            string title = command.Parameters[1];
            string location = null;
            Event ev = new Event(date, title, location);
            this.eventsManager.AddEvent(ev);
        }
        #endregion
  
        private string DeleteEvents(Command command)
        {
            int count = this.eventsManager.DeleteEventsByTitle(command.Parameters[0]);

            if (count == 0)
            {
                return "No events found.";
            }

            return count + " events deleted";
        }

        private string ListEvents(Command command)
        {
            var date = DateTime.ParseExact(command.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var count = int.Parse(command.Parameters[1]);
            var events = this.eventsManager.ListEvents(date, count).ToList();
            var eventsOutput = new StringBuilder();

            if (!events.Any())
            {
                return "No events found";
            }

            foreach (var ev in events)
            {
                eventsOutput.AppendLine(ev.ToString());
            }

            return eventsOutput.ToString().Trim();
        }
    }
}