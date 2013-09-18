using System;
using System.Text;

class IsosclesTriangle
{
    static void Main()
    {
        char copyRight = (char)169;
        Console.OutputEncoding = Encoding.Unicode;
        Console.WriteLine(@"           {0}
          {0} {0}
         {0}   {0}
        {0} {0} {0} {0}", copyRight);
    }
}