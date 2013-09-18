using System;
using System.IO;
using System.Text.RegularExpressions;

namespace WordReplace
{
    class WordReplace
    {
        /*
         * 8. Modify the solution of the previous problem to replace only whole words (not substrings).
         */
        static void Main()
        {
            File.WriteAllText("TestFile.txt", Regex.Replace(File.ReadAllText("TestFile.txt"), "\\bstart\\b", "finish"));
        }
    }
}
