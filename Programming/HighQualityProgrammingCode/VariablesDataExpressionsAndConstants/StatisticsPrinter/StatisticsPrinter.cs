using System;

namespace StatisticsPrinter
{
    class StatisticsPrinter
    {
        static void Main()
        {
            double[] numbersSequence = new double[10];
            for (int i = 0; i < 10; i++)
            {
                numbersSequence[i] = i + 1;
            }

            PrintStatistics(numbersSequence, numbersSequence.Length);
        }

        public static void PrintStatistics(double[] numbersSequence, int sequenceLength)
        {
            double maxElement = double.MinValue;

            for (int i = 0; i < sequenceLength; i++)
            {
                if (numbersSequence[i] > maxElement)
                {
                    maxElement = numbersSequence[i];
                }
            }
            PrintMax(maxElement);

            double minElement = double.MaxValue;
            for (int i = 0; i < sequenceLength; i++)
            {
                if (numbersSequence[i] < minElement)
                {
                    minElement = numbersSequence[i];
                }
            }
            PrintMin(minElement);

            double sumOfAllElements = 0;
            for (int i = 0; i < sequenceLength; i++)
            {
                sumOfAllElements += numbersSequence[i];
            }
            PrintAvg(sumOfAllElements / sequenceLength);
        }

        public static void PrintAvg(double value)
        {
            Console.WriteLine("The average of the elements is {0}.", value);
        }
  
        private static void PrintMin(double value)
        {
            Console.WriteLine("The min element is {0}.", value);
        }

        public static void PrintMax(double value)
        {
            Console.WriteLine("The max element is {0}.", value);
        }
    }
}