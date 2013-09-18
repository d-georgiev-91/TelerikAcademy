using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RemoveListedWord
{
    class RemoveListedWord
    {
        /*
         * 12. Write a program that removes from a text file
         * all words listed in given another text file. Handle all possible exceptions in your methods.
         */
        static void Main()
        {
            try
            {
                string match = "\\b(" + String.Join("|", File.ReadAllLines("Words.txt")) + ")\\b";
                string line;
                using (StreamReader read = new StreamReader("TheOriginalFile.txt"))
                {
                    using (StreamWriter write = new StreamWriter("TheResult.txt"))
                    {
                        while ((line = read.ReadLine()) != null)
                        {
                            write.WriteLine(Regex.Replace(line, match, String.Empty));
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("File not found!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("No such directory!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.Error.WriteLine("No permission!");
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Invalid input!");
            }
        }
    }
}
