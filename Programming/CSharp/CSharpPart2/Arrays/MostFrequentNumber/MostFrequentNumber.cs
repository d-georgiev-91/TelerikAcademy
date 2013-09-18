using System;

namespace MostFrequentNumber
{
    class MostFrequentNumber
    {
        static void Main()
        {
            /* Uslovie
             * 9. Write a program that finds the most frequent number in an array. Example:
             * {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)
            */
            int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            int frequency = 0;
            int mostFrequent = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int frequencyCurrent = 1;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        frequencyCurrent++;
                    }
                }
                if (frequencyCurrent > frequency)
                {
                    mostFrequent = array[i];
                    frequency = frequencyCurrent;
                }
            }
            if (frequency == 1 && array.Length != 1)
            {
                Console.WriteLine("There is no most frequent number.");
            }
            else
            {
                Console.WriteLine("The most frequent number is {0} with frequency {1}.", mostFrequent, frequency);
            }
        }
    }
}
