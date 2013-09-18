using System;

namespace SubstringSearch
{
    class SubstringSearch
    {
        /* 4. Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
         */
        static void Main()
        {
            Console.Write("Input your text: ");
            string text = Console.ReadLine();
            Console.Write("Input substring: ");
            string substring = Console.ReadLine();
            int counter = 0;
            for (int i = 0; i < text.Length - (substring.Length - 1); i++)
            {
                if (text.Substring(i, substring.Length).ToLower() == substring.ToLower())
                {
                    counter++;
                }
            }
            Console.WriteLine("The string: \"{0}\" times is found {1} in the text.", substring, counter);
        }
    }
}
