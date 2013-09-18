using System;
using System.IO;

namespace ReadTextFile
{
    class ReadTextFile
    {
        static void Main()
        {
            Console.Write(@"Input path (for example C:\WINDOWS\win.ini): ");
            string path = Console.ReadLine();
            try
            {
                Console.WriteLine(File.ReadAllText(path));
            }
            catch (ArgumentException)
            {
                Console.Error.WriteLine("Invalid path!");
            }
            catch (PathTooLongException)
            {
                Console.Error.WriteLine("The path is too long!");
            }
            catch (DriveNotFoundException)
            {
                Console.Error.WriteLine("No such drive!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("No such directory!");
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("File not found!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.Error.WriteLine("No access!");
            }
            catch (NotSupportedException)
            {
                Console.Error.WriteLine("The path is invalid!");
            }
            catch (FileLoadException)
            {
                Console.Error.WriteLine("File cannot be loaded!");
            }
        }
    }
}
