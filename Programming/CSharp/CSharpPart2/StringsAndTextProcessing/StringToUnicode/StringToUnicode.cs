using System;

namespace StringToUnicode
{
    class StringToUnicode
    {
        /* 10. Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. */
        static void Main()
        {
            Console.Write("Input string: ");
            string input = Console.ReadLine();
            foreach (var character in input)
            {
                Console.Write("\\u{0:x4}", Convert.ToUInt16(character));
            }
            Console.WriteLine();
        }
    }
}
