using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WordsCount
{
    class WordsCount
    {
        /*13. Write a program that reads a list of words from a file words.txt and finds 
         * how many times each of the words is contained in another file test.txt. The 
         * result should be written in the file result.txt and the words should be sorted 
         * by the number of their occurrences in descending order. Handle all possible 
         * exceptions in your methods.*/
        static void Main()
        {
            try
            {
                Dictionary<string, int> wordsCount = new Dictionary<string, int>();
                string line;
                using (StreamReader readWords = new StreamReader("word.txt"))
                {
                    while ((line = readWords.ReadLine()) != null)
                    {
                        wordsCount.Add(line, 0);
                    }
                }
                using (StreamReader readFile = new StreamReader("test.txt"))
                {
                    while ((line = readFile.ReadLine()) != null)
                    {
                        var words = new List<string>(wordsCount.Keys);
                        foreach (var word in words)
                        {
                            wordsCount[word] += Regex.Matches(line, @"\b" + word + @"\b").Count;
                        }
                    }
                }
                using (StreamWriter write = new StreamWriter("result.txt"))
                {
                    foreach (var word in wordsCount.Keys)
                    {
                        write.WriteLine(word + " - " + wordsCount[word]);
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
            catch (ArgumentException)
            {
                Console.Error.WriteLine("The words in the file must not repeats!");
            }
        }
    }
}
