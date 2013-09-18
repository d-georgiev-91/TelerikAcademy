namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    catalog.Add(new ContentItem(ContentItemType.Book, command.Parameters));
                    output.AppendLine("Book added");
                    break;
                case CommandType.AddMovie:
                    catalog.Add(new ContentItem(ContentItemType.Movie, command.Parameters));
                    output.AppendLine("Movie added");
                    break;
                case CommandType.AddSong:
                    catalog.Add(new ContentItem(ContentItemType.Song, command.Parameters));
                    output.AppendLine("Song added");
                    break;
                case CommandType.AddApplication:
                    catalog.Add(new ContentItem(ContentItemType.Application, command.Parameters));
                    output.AppendLine("Application added");
                    break;
                case CommandType.Update:
                    if (command.Parameters.Length != 2)
                    {
                        throw new FormatException("Invalid parameters!");
                    }
                    
                    int itemsUpated = catalog.UpdateContent(command.Parameters[0], command.Parameters[1]);

                    output.AppendLine(String.Format("{0} items updated", itemsUpated));
                    break;
                case CommandType.Find:
                    
                    if (command.Parameters.Length != 2)
                    {
                        throw new FormatException("Invalid number of parameters!");
                    }

                    int numberOfElementsToList = int.Parse(command.Parameters[1]);

                    IEnumerable<IContent> foundContent = catalog.GetListContent(command.Parameters[0], numberOfElementsToList);

                    if (foundContent.Count() == 0)
                    {
                        output.AppendLine("No items found");
                    }
                    else
                    {
                        foreach (IContent content in foundContent)
                        {
                            output.AppendLine(content.TextRepresentation);
                        }
                    }
                    break;
                default:
                    throw new InvalidCastException("Unknown command!");
            }
        }
    }
}