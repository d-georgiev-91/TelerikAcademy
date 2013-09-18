using System;
using System.Collections.Generic;
using System.IO;

namespace DeleteOddLines
{
    class DeleteOddLines
    {
        /*9. Write a program that deletes from given text file all odd lines. The result should be in the same file.*/
        static void Main()
        {
            StreamReader readTextFile = new StreamReader("TestFile.txt");
            int lineNumber = 0;
            string line = readTextFile.ReadLine();
            List<string> nonOddLines = new List<string>();
            Console.WriteLine("The file is:");
            while (line != null)
            {
                lineNumber++;
                if (lineNumber%2 == 0 && line!= null)
                {
                    nonOddLines.Add(line);
                }
                Console.WriteLine("{0}. {1}", lineNumber, line);
                line = readTextFile.ReadLine();
            }
            readTextFile.Close();
            StreamWriter writeTextFile = new StreamWriter("TestFile.txt");
            foreach (var item in nonOddLines)
            {
                if (item == nonOddLines[nonOddLines.Count-1])
                {
                     writeTextFile.WriteLine(item);
                }
                else
                {
                    writeTextFile.Write(item);
                }
            }
            writeTextFile.Close();
        }
    }
}
