using System;
using System.Text;

namespace ChangeTags
{
    class ChangeTags
    {
        static void Main()
        {
            Console.Write("Input html fragment: ");
            string fragment = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            result.Append(fragment);
            result.Replace("<a href=\"", "[URL=");
            result.Replace("\">", "]");
            result.Replace("</a>", "[/URL]");
            Console.WriteLine("The result is: ");
            Console.WriteLine(result);
        }
    }
}
