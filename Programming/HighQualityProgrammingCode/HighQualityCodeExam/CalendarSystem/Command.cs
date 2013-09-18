namespace CalendarSystem
{
    using System;

    public struct Command
    {
        public string Name { get; private set; }

        public string[] Parameters { get; private set; }

        public static Command Parse(string command)
        {
            var commandName = GetCommandName(command);
            var commandParameters = GetCommandParameters(command);

            Command parsedCommand = new Command { Name = commandName, Parameters = commandParameters };

            return parsedCommand;
        }

        private static string GetCommandName(string command)
        {
            int commandLength = GetCommandLength(command);
            string commandName = command.Substring(0, commandLength);
            return commandName;
        }

        private static string[] GetCommandParameters(string command)
        {
            int commandLength = GetCommandLength(command);

            string commandParameters = command.Substring(commandLength + 1);
            string[] commandParametersSplitted = commandParameters.Split('|');

            if (commandParametersSplitted.Length > 3)
            {
                throw new FormatException("Invalid paramaters!");
            }

            for (int i = 0; i < commandParametersSplitted.Length; i++)
            {
                CheckForEmptyParameter(commandParametersSplitted, i);
                commandParametersSplitted[i] = commandParametersSplitted[i].Trim();
            }

            return commandParametersSplitted;
        }

        private static int GetCommandLength(string command)
        {
            int commandLength = command.IndexOf(' ');

            if (commandLength == -1)
            {
                throw new ArgumentException("Invalid command: " + command);
            }

            return commandLength;
        }

        private static void CheckForEmptyParameter(string[] commandParametersSplitted, int i)
        {
            if (string.IsNullOrWhiteSpace(commandParametersSplitted[i]))
            {
                throw new FormatException("Whitespace parameter at position " + (i + 1));
            }
        }
    }
}