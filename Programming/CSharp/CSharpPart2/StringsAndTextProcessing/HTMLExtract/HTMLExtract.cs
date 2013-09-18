using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace HTMLExtract
{
    class HTMLExtract
    {
        static void Main()
        {
            StreamReader read = new StreamReader("htmlFile.html");
            string html = read.ReadToEnd();
            read.Close();
            List<string> htmlContent = new List<string>();
            MatchCollection content = Regex.Matches(html, "(?<=^|>)[^><]+?(?=<|$)", RegexOptions.IgnoreCase);
            foreach (var line in content)
            {
                htmlContent.Add(line.ToString());
            }
            foreach (var line in htmlContent)
            {
                Console.WriteLine(line);
            }
        }
    }
}
