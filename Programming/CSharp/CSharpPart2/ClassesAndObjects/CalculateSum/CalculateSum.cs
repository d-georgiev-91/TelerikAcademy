using System;

namespace CalculateSum
{
    class CalculateSum
    {
        /*
         * 6. You are given a sequence of positive integer values written into a string,
         * separated by spaces. Write a function that reads these values from given 
         * string and calculates their sum. 
         * Example: string = "43 68 9 23 318" -> result = 461
         */
        static ulong CalculateSequence(string sequence)
        {
            ulong result = 0;
            string[] numbers = sequence.Split(' ');
            foreach (var number in numbers)
            {
                result += Convert.ToUInt64(number);
            }
            return result;
        }
        static void Main()
        {
            Console.Write("Input sequnece");
            string sequence = Console.ReadLine();
            Console.WriteLine("The sum of the sequence is {0}.", CalculateSequence(sequence));
        }
    }
}
