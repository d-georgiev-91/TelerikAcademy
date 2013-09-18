using System;
using System.Text;

namespace FillTheRestWithStars
{
    class FillTheRestWithStars
    {
        static void Main()
        {
            string input = null;
            while (String.IsNullOrEmpty(input) || input.Length > 20)
            {
                Console.Write("Input string with 20 or less charcters: ");   
                input = Console.ReadLine();
            }
            Console.WriteLine(input.PadRight(20,'*'));
        }
    }
}
