using System;

namespace MinMaxAvgSumProductOfSet
{
    class MinMaxAvgSumProductOfSet
    {
        static int[] InputSet()
        {
            int length = 0;
            while (length <= 0)
            {
                Console.Write("Input the set legnth (the set must cointain at least 1 element): ");
                length = int.Parse(Console.ReadLine());
            }
            int[] set = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("Input element for set: ");
                set[i] = int.Parse(Console.ReadLine());
            }
            return set;
        }

        static void PrintSet(int [] set)
        {
            Console.Write("{ ");
            for (int i = 0; i < set.Length; i++)
            {
                if (i != set.Length)
                {
                    Console.Write("{0}, ", set[i]);
                }
                else
                {
                    Console.WriteLine("{0} }", set[i]);
                }
            }
        }
        static int Min(int[] set)
        {
            int min = set[0];
            for (int i = 1; i < set.Length; i++)
            {
                if (min > set[i])
                {
                    min = set[i];
                }
            }
            return min;
        }

        static int Max(int[] set)
        {
            int max = set[0];
            for (int i = 1; i < set.Length; i++)
            {
                if (max < set[i])
                {
                    max = set[i];
                }
            }
            return max;
        }

        static double Average(int [] set)
        {
            double sum = 0;
            for (int i = 0; i < set.Length; i++)
            {
                sum += set[i];
            }
            return sum / (double)(set.Length);
        }

        static int Sum(int[] set)
        {
            int sum = 0;
            for (int i = 0; i < set.Length; i++)
            {
                sum += set[i];
            }
            return sum;
        }

        static long Product(int[] set)
        {
            long product = 1;
            for (int i = 0; i < set.Length; i++)
            {
                product *= set[i];
            }
            return product;
        }

        static void Main()
        {
            int[] set = InputSet();
            Console.WriteLine("The minimum in the set is {0}", Min(set));
            Console.WriteLine("The maximum in the set is {0}", Max(set));
            Console.WriteLine("The average of the set is {0}", Average(set));
            Console.WriteLine("The sum of set is {0}", Sum(set));
            Console.WriteLine("The product of set is {0}", Product(set));
        }
    }
}
