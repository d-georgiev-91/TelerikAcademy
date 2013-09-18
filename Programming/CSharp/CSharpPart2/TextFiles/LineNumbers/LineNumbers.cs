using System;
using System.IO;
using System.Text;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main()
        {
            StreamReader readTextFile = new StreamReader("TestFile.txt");
            int lineNumber = 0;
            string line = readTextFile.ReadLine();
            StreamWriter writeTextFile = new StreamWriter("TestFileWithLineNumbers.txt");
            while (line != null)
            {
                lineNumber++;
                writeTextFile.WriteLine("{0}. {1}", lineNumber, line);
                line = readTextFile.ReadLine();
            }
            readTextFile.Close();
            writeTextFile.Close();
        }
    }
}
