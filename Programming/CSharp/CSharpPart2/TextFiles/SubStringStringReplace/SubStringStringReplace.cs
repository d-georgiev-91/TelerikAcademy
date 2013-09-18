using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SubStringStringReplace
{
    class SubStringStringReplace
    {
        /* 6. Write a program that replaces all occurrences of the substring "start" with 
         * the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB). 
         */
        static void Main()
        {
            File.WriteAllText("TestFile.txt", Regex.Replace(File.ReadAllText("TestFile.txt"), "start", "finish"));
        }
    }
}
