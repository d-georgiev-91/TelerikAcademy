using System;
using System.Collections.Generic;
using System.IO;

namespace CompareFiles
{
    class CompareFiles
    {
        /*
         * 4. Write a program that compares two text files line by line and 
         * prints the number of lines that are the same and the number of 
         * lines that are different. Assume the files have equal number of lines.
         */
        static void Main()
        {
            int lines = 0;
            List <int> equalLines = new List<int>();
            List<int> differentLines = new List<int>();
            StreamReader firstFile = new StreamReader("FirstFile.txt");
            StreamReader secondFile = new StreamReader("SecondFile.txt");
            string lineFirstFile = "a";
            string lineSecondFile = "a";
            lineFirstFile = firstFile.ReadLine();
            lineSecondFile = secondFile.ReadLine();
            while (lineFirstFile != null)
            {
                lines++;
                lineFirstFile = firstFile.ReadLine();
                lineSecondFile = secondFile.ReadLine();
                
                if (lineFirstFile == lineSecondFile)
                {
                    equalLines.Add(lines);
                }
                else
                {
                    differentLines.Add(lines);
                }
            }
            firstFile.Close();
            secondFile.Close();
            Console.Write("The equal lines are ");
            foreach (var item in equalLines)
            {
                if (item != equalLines[equalLines.Count - 1])
                {
                    Console.Write("{0}, ", item);
                }
                else
                {
                    Console.WriteLine("{0}.", item);
                }
            }
            Console.Write("The different lines are: "); 
            foreach (var item in differentLines)
            {
                if (item != differentLines[differentLines.Count - 1])
                {
                    Console.Write("{0}, ", item);
                }
                else
                {
                    Console.WriteLine("{0}.", item);
                }
            }
        }
    }
}
