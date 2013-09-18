namespace CalendarSystem
{
    using System;
    using System.Linq;

    public class CalendarSystem
    {
        public static void Main()
        {
            var eventsManager = new EventsManager();
            var commandProcessor = new CommandProcessor(eventsManager);

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End" || command == null)
                {
                    break;
                }

                try
                {
                    Command parsedCommand = Command.Parse(command);
                    string commandOutput = commandProcessor.ProcessCommand(parsedCommand);
                    Console.WriteLine(commandOutput);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}