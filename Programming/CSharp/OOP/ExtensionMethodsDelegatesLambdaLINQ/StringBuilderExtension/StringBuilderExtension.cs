using System;
using System.Linq;
using System.Text;

/*
 * ULSOVIE 
 * 1. Implement an extension method Substring(int index, int length) for the 
 * class StringBuilder that returns new StringBuilder and has the same 
 * functionality as Substring in the class String.
 */

namespace StringBuilderExtension
{
    class StringBuilderExtension
    {
        static void Main()
        {
            StringBuilder someStringBuilderString = new StringBuilder("Bananana");
            Console.WriteLine(someStringBuilderString.Substring(7));
        }
    }
}
