using System;
using System.IO;
using System.Text.RegularExpressions;

namespace DeleteWords
{
    class DeleteWords
    {
        /*
         * 11. Write a program that deletes from a text file all words that
         * start with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.
         */
        static void Main()
        {
            File.WriteAllText("TestFile.txt", Regex.Replace(File.ReadAllText("TestFile.txt"), "\\btest\\w*\\b", String.Empty));
        }
    }
}
