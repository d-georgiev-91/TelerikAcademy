using System;
using System.Linq;

namespace divisibleBySevenAndThree
{
    class divisibleBySevenAndThree
    {
        //6. Write a program that prints from given array of integers all 
        //   numbers that are divisible by 7 and 3. Use the built-in extension 
        //   methods and lambda expressions. Rewrite the same with LINQ.
        public static void DivisibleToSevenAndThreeLambda(int[] array)
        {
            var divisibleItem = array.Where(x => (x % 21) == 0);
            foreach (var item in divisibleItem)
            {
                Console.WriteLine(item);
            }
        }

        public static void DivisibleToSevenAndThreeLINQ(int[] array)
        {
            var divisibleItem =
                from item in array
                where item % 21 == 0
                select item;
            foreach (var item in divisibleItem)
            {
                Console.WriteLine(item);   
            }
        }

        static void Main()
        {
            int[] array = { 3, 6, 210, 21, 4, 5, 6, 352, 42 };

            DivisibleToSevenAndThreeLambda(array);
            Console.WriteLine();
            DivisibleToSevenAndThreeLINQ(array);
        }
    }
}
