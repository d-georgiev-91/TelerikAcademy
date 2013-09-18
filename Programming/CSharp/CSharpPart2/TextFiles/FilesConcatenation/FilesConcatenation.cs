using System;
using System.IO;

namespace FilesConcatenation
{
    class FilesConcatenation
    {
        static string ReadFile(string fileLocation)
        {
            StreamReader readTextFile = new StreamReader(fileLocation);
            string content = readTextFile.ReadToEnd();
            readTextFile.Close();
            return content;
        }
        static void Main()
        {
            string concatenation = ReadFile("FirstFile.txt") + "\n" + ReadFile("SecondFile.txt");
            StreamWriter writeToFile = new StreamWriter("ConcatenationOfTheFiles.txt");
            writeToFile.Write(concatenation);
            writeToFile.Close();
        }
    }
}
