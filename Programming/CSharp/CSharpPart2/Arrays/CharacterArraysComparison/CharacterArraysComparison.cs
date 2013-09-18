using System;

namespace CharacterArraysComparison
{
    class CharacterArraysComparison
    {
        static void Main()
        {
            /* Uslovie
             * 3. Write a program that compares two char arrays lexicographically (letter by letter).
             */
            Console.Write("Input first array size: ");
            int firstArraySize = int.Parse(Console.ReadLine());
            Console.Write("Input second array size: ");
            int secondArraySize = int.Parse(Console.ReadLine());
            int arrayCompare = 3; // if 0 equal, if 1 first is before second, if 2 second is before first
            if (firstArraySize == secondArraySize)
            {
                char[] firstArray = new char[firstArraySize];
                for (int i = 0; i < firstArraySize; i++)
                {
                    Console.Write("a1[" + (i + 1) + "]= ");
                    firstArray[i] = char.Parse(Console.ReadLine());
                }
                char[] secondArray = new char[secondArraySize];
                for (int i = 0; i < secondArraySize; i++)
                {
                    Console.Write("a2[" + (i + 1) + "]= ");
                    secondArray[i] = char.Parse(Console.ReadLine());
                }
                for (int i = 0; i < firstArraySize; i++)
                {
                    if (firstArray[i] != secondArray[i])
                    {
                        if (firstArray[i] > secondArray[i])
                        {
                            arrayCompare = 2;
                        }
                        else
                        {
                            arrayCompare = 1;
                        }
                        break;
                    }
                    else
                    {
                        arrayCompare = 0;
                    }
                }
                if (arrayCompare == 0)
                {
                    Console.WriteLine("The arrays are the same.");
                }
            }
            if (arrayCompare !=0)
            {
                if (arrayCompare == 1)
                {
                    Console.WriteLine("The arrays are different and the first is before the second.");
                }
                else if (arrayCompare == 2 )
                {
                    Console.WriteLine("The arrays are different and the second is before the first.");
                }
                else
                {
                    Console.WriteLine("The arrays are different.");
                }
            }
        }
    }
}
