namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CatalogOfFreeContent
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();
            
            var commands = ReadInputCommands();

            foreach (ICommand command in commands)
            {
                commandExecutor.ExecuteCommand(catalog, command, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> ReadInputCommands()
        {
            List<ICommand> commands = new List<ICommand>();
            bool end = false;

            do
            {
                string line = Console.ReadLine();
                end = (line.Trim() == "End");
                if (!end)
                {
                    commands.Add(new Command(line));
                }
            }
            while (!end);

            return commands;
        }
    }
}