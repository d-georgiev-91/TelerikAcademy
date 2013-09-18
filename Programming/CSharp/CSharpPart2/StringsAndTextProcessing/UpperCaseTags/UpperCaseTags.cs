using System;
using System.Text;
using System.Text.RegularExpressions;

namespace UpperCaseTags
{
    class UpperCaseTags
    {
        /* 5. You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. 
         */
        static void Main()
        {
            Console.Write("Input your text: ");
            try
            {
                string text = Console.ReadLine();
                string openTag = "<upcase>";
                string closeTag = "</upcase>";
                StringBuilder result = new StringBuilder();
                result.Append(text);
                int openTagIndex = 0;
                int closeTagIndex = 0;
                int index = -1;
                while (true)
                {
                    openTagIndex = text.IndexOf(openTag, openTagIndex + 1);

                    closeTagIndex = text.IndexOf(closeTag, closeTagIndex + 1);

                    if (openTagIndex == -1 && closeTagIndex == -1)
                    {
                        break;
                    }
                    int contentStartIndex = openTagIndex + (openTag.Length - 1);
                    int contentLength = closeTagIndex - contentStartIndex;
                    result.Replace(text.Substring(contentStartIndex, contentLength), text.Substring(contentStartIndex, contentLength).ToUpper(), contentStartIndex, contentLength);
                }
                result.Replace(openTag, String.Empty);
                result.Replace(openTag.ToUpper(), String.Empty);
                result.Replace(closeTag, String.Empty);
                Console.WriteLine(result);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Not all tags are correctly oppened/closed!!!");
            }
        }
    }
}