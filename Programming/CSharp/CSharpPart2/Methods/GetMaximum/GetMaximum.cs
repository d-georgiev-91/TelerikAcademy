using System;

namespace GetMaximum
{
    class GetMaximum
    {   /*
         * 2. Write a method GetMax() with two parameters that returns the bigger of two integers.
         * Write a program that reads 3 integers from the console and prints the biggest of 
         * them using the method GetMax().
         */
        static int GetMax(int firstInt, int secondInt)
        {
            if (firstInt > secondInt)
            {
                return firstInt;
            }
            else
            {
                return secondInt;
            }
        }

        static void Main()
        {
            Console.Write("Input first int: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("Input second int: ");
            int second = int.Parse(Console.ReadLine());
            Console.Write("Input third int: ");
            int third = int.Parse(Console.ReadLine());
            Console.WriteLine("The biggest integer is: {0}.", GetMax(GetMax(first, second),third));
        }
    }
}
