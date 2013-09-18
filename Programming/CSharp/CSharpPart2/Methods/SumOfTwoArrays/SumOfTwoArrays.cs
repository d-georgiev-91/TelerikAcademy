using System;
using System.Collections.Generic;

namespace SumOfTwoArrays
{
    class SumOfTwoArrays
    {
        /* 8. Write a method that adds two positive integer numbers represented 
         * as arrays of digits (each array element arr[i] contains a digit; the 
         * last digit is kept in arr[0]). Each of the numbers that will be 
         * added could have up to 10 000 digits.*/
        static List <int> Sum(int [] firstNumber, int [] secondNumber)
        {
            List<int> result = new List<int>();
            int min = Math.Min(firstNumber.Length, secondNumber.Length);
            int max = Math.Max(firstNumber.Length, secondNumber.Length);
            int x = 0;
            for (int i = 0; i < min; i++)
            {
                
                result.Add((firstNumber[i] + secondNumber[i] + x )%10);
                x = (firstNumber[i] + secondNumber[i] + x )/10;
            }
            if (max == firstNumber.Length)
            {
                for (int i = min; i < max; i++)
                {
                    result.Add((firstNumber[i] + x)%10);
                    x = (firstNumber[i] + x) / 10;
                }
                if (x != 0)
                {
                    result.Add(x);
                }
            }
            else
            {
                for (int i = min; i < max; i++)
                {
                    result.Add((secondNumber[i] + x)%10);
                    x = (secondNumber[i] + x) / 10;
                }
                if (x != 0)
                {
                    result.Add(x);
                }
            }
            result.Reverse();
            return result;
        }
        static void Main()
        {
            int[] first  = { 1, 5, 3, 4, 4, 3, 9, 9 }; //99344351
            int[] second = { 2, 5, 3, 5, 6, 7 };         //765352
            foreach (var item in Sum(first, second))
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
