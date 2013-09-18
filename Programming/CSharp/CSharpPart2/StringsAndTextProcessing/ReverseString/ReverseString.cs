using System;
using System.Text;

namespace ReverseString
{
    class ReverseString
    {
        /* 2. Write a program that reads a string,
         * reverses it and prints the result at the console.
         * Example: "sample"  "elpmas".*/
        static void Main()
        {
            Console.Write("Input your string: ");
            string inputString = Console.ReadLine();
            StringBuilder inputReversed = new StringBuilder(inputString.Length);
            for (int i = inputString.Length - 1; i >= 0 ; i--)
            {
                inputReversed.Append(inputString[i]);
            }
            Console.WriteLine("The reversed string is: {0}", inputReversed);
        }
    }
}
