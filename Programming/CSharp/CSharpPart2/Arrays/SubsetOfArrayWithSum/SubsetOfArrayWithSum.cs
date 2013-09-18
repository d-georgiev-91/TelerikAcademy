using System;

namespace SubsetOfArrayWithSum
{
    class SubsetOfArrayWithSum
    {
        static void Main()
        {
            /** 16. We are given an array of integers and a number S.
             * Write a program to find if there exists a subset of 
             * the elements of the array that has a sum S. Example:	arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)
             */
            Console.Write("Input array length: ");
            int arrayLenth = int.Parse(Console.ReadLine());
            int[] array = new int[arrayLenth];
            for (int i = 0; i < arrayLenth; i++)
            {
                Console.Write("Input array elemet: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Input S: ");
            int s = int.Parse(Console.ReadLine());             
            bool[] problem = new bool[s + 1];
            problem[0] = true;
            for (int i = 1; i <= s; i++)
            {
                problem[i] = false;
            }
            for (int i = 1; i < array.Length; i++)
            {

                for (int j = s; j >= 0; j--)
                {
                    Console.WriteLine("j= " + j);
                    Console.WriteLine("i= " + i);
                    if(problem[j] && ((array[i] + j) <= s))
                    {
                        problem[(array[i] + j)] = true;
                    }
                }
            }
            if (problem[s])
            {
                Console.WriteLine("Yes.");
            }
            else
            {
                Console.WriteLine("No.");
            }
        }
    }
}
