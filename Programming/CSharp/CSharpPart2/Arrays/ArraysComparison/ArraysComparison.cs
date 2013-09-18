using System;

namespace ArraysComparison
{
    class ArraysComparison
    {
        static void Main()
        {
            /* Uslovie
             * 2. Write a program that reads two arrays from the console and compares them element by element.
             */
            Console.Write("Input first array size: ");
            int firstArraySize = int.Parse(Console.ReadLine());
            Console.Write("Input second array size: ");
            int secondArraySize = int.Parse(Console.ReadLine());
            bool areEqual = false;
            if (firstArraySize == secondArraySize)
            {
                int[] firstArray = new int[firstArraySize];
                for (int i = 0; i < firstArraySize; i++)
                {
                    Console.Write("a1[" + (i + 1) + "]= ");
                    firstArray[i] = int.Parse(Console.ReadLine());
                }
                int[] secondArray = new int[secondArraySize];
                for (int i = 0; i < secondArraySize; i++)
                {
                    Console.Write("a2[" + (i + 1) + "]= ");
                    secondArray[i] = int.Parse(Console.ReadLine());
                }
                for (int i = 0; i < firstArraySize; i++)
                {
                    if (firstArray[i] != secondArray[i])
                    {
                        areEqual = false;
                        break;
                    }
                    else
                    {
                        areEqual = true;
                    }
                }
                if (areEqual)
                {
                    Console.WriteLine("The arrays are equal.");
                }
            }
            if (!areEqual)
            {
                Console.WriteLine("The arrays are different.");
            }
        }
    }
}
