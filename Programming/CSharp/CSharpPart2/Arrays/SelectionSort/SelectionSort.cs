using System;

namespace SelectionSort
{
    class SelectionSort
    {
        static void Main()
        {
            Console.Write("Input array length: ");
            int arrayLength = int.Parse(Console.ReadLine());
            int[] array = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                Console.Write("Input element in sequence: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minElementIndex = i;
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[j]<array[minElementIndex])
                    {
                        minElementIndex = j;
                    }
                }
                if (array[i]>array[minElementIndex])
                {
                    int swap = array[i];
                    array[i] = array[minElementIndex];
                    array[minElementIndex] = swap;
                }
            }
            Console.Write("The sorted array is: { ");
            for (int i = 0; i < arrayLength; i++)
            {
                if (i == arrayLength - 1)
                {
                    Console.WriteLine(array[i] + " }");
                }
                else
                {
                    Console.Write(array[i] + ", ");
                }
            }
        }
    }
}
