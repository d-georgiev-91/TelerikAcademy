using System;
using System.IO;

namespace PrintOddLines
{
    class PrintOddLines
    {
        /*
         * 1. Write a program that reads a text file and prints on the console its odd lines.
         */
        static void Main()
        {
            StreamReader readTextFile = new StreamReader("TestFile.txt");
            Console.WriteLine("The file contains the following lines\n\n{0}", readTextFile.ReadToEnd());
            int lineNumber = 1;
            string line = readTextFile.ReadLine();
            while (line != null)
            {
                if (lineNumber % 2 != 0)
                {
                    Console.WriteLine(lineNumber+ " " + line);
                }
                lineNumber++;
                line = readTextFile.ReadLine();
            }
            readTextFile.Close();
        }
    }
}
