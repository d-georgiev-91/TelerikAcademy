using System;
using System.Collections.Generic;
using System.IO;

namespace ReadXML
{
    class ReadXML
    {
        static void Main()
        {
            StreamReader readTextFile = new StreamReader("Test.XML");
            List<string> xmlWithoutTags = new List<string>();
            int character;
            while ((character = readTextFile.Read()) != -1)
            {
                if (character == '>')
                {
                    string content = string.Empty;
                    while ((character = readTextFile.Read()) != -1 && character != '<')
                    {
                        content += (char)character;
                    }
                    if (!String.IsNullOrWhiteSpace(content))
                    {
                        Console.WriteLine(content.Trim());
                    }
                }
            }
            readTextFile.Close();
        }
    }
}
