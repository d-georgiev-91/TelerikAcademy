using System;
using System.Text;

namespace RemoveRepeating
{
    class RemoveRepeating
    {
        /* 23. Write a program that reads a string from the console and replaces all series of consecutive 
         * identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".*/
        static void Main()
        {
            Console.Write("Input string: ");
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            result.Append(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[i - 1])
                {
                    result.Append(input[i]);
                }
            }
            Console.WriteLine(result);
        }
    }
}
