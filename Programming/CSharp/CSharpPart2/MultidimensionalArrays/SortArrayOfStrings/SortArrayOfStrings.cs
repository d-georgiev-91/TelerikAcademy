using System;

namespace SortArrayOfStrings
{
    /* 5. You are given an array of strings. Write a method that sorts the array by the 
     * length of its elements (the number of characters composing them). */
    class SortArrayOfStrings
    {
        static void Main()
        {
            Console.Write("Input array length: ");
            int length = int.Parse(Console.ReadLine());
            string[] array = new string[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("Input array element: ");
                array[i] = Console.ReadLine();
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minElementIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].Length < array[minElementIndex].Length)
                    {
                        minElementIndex = j;
                    }
                }
                if (array[i].Length > array[minElementIndex].Length)
                {
                    string swap = array[i];
                    array[i] = array[minElementIndex];
                    array[minElementIndex] = swap;
                }
            }
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
