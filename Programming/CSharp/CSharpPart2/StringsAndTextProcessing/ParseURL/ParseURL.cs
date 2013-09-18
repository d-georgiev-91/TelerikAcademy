using System;
using System.Text.RegularExpressions;

namespace ParseURL
{
    class ParseURL
    {
        /*  12.Write a program that parses an URL address given in the format:     
         *  [protocol]://[server]/[resource]                                        *
		 *  and extracts from it the [protocol], [server] and [resource] elements.  *
         *  For example from the URL http://www.devbg.org/forum/index.php           *
         *  the following information should be extracted:                          *
		 *  [protocol] = "http"                                                     *
		 *  [server] = "www.devbg.org"                                              *
		 *  [resource] = "/forum/index.php" */

        static void Main()
        {
            Console.WriteLine("Input url in the format [protocol]://[server]/[resource]: ");
            string url = Console.ReadLine();
            string protocol = Regex.Match(url, @"[^:]*").ToString();
            string server = Regex.Match(url, @"/([^/][\w\.]*)").Groups[1].ToString();
            string resource = Regex.Match(url, @"\b/[^/][\w.]*.+").ToString();
            Console.WriteLine("[protocol] = \"{0}\"" , protocol);
            Console.WriteLine("[server] = \"{0}\"", server);
            Console.WriteLine("[resource] = \"{0}\"", resource);
        }
    }
}
