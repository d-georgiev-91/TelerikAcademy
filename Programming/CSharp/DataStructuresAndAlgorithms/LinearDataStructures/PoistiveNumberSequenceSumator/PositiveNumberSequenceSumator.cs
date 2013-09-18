// 1. Write a program that reads from the console a sequence of positive integer numbers. 
// The sequence ends when empty line is entered. Calculate and print the sum and average
// of the elements of the sequence. Keep the sequence in List<int>.

namespace PoistiveNumberSequenceSumator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PositiveNumberSequenceSumator
    {
        static void Main()
        {
            List<int> sequence = ReadSequence();
            long sum = CalculateSum(sequence);
            double average = CalculateAverage(sequence);
            Console.WriteLine("The sum of the sequence is {0}.\nThe average is {1}.", sum, average);
        }
  
        private static double CalculateAverage(List<int> sequence)
        {
            if (sequence.Count == 0)
            {
                return 0;   
            }

            double average = sequence.Average();

            return average;
        }
  
        private static long CalculateSum(List<int> sequence)
        {
            if (sequence.Count == 0)            
            {
                return 0;
            }

            long sum = sequence.Sum();

            return sum;
        }

        private static List<int> ReadSequence()
        {
            List<int> sequence = new List<int>();
            string line;

            while (true)
            {
                Console.Write("Enter positive number: ");
                line = Console.ReadLine();
                if (line == string.Empty)
                {
                    break;
                }

                int number = 0;

                try
                {
                    number = int.Parse(line);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a valid number!");
                    continue;
                }

                if (number <= 0)
                {
                    Console.WriteLine("Numer is not positive!");
                    continue;
                }

                sequence.Add(number);
            }

            return sequence;
        }
    }
}