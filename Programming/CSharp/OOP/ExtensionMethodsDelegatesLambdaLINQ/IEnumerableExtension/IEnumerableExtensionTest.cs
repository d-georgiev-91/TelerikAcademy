using System;
using System.Collections.Generic;

//2. Implement a set of extension methods for IEnumerable<T> that implement the 
//   following group functions: sum, product, min, max, average.

namespace IEnumerableExtension
{
    class IEnumerableExtensionTest
    {
        static void Main()
        {
            int[] array = new int[] { 1, 5, 6, 2, 5, 6, 24 };
            Console.WriteLine("Sum: " + array.Sum());
            Console.WriteLine("Max: " + array.Max());
            Console.WriteLine("Min: " + array.Min());
            Console.WriteLine("Average: " + array.Average());

            Console.WriteLine("List");
            List<double> list = new List<double>(new double[]{ 1.6, 5.2, -6.5, 2.6, 5.3, 9.5, 2.5 });
            Console.WriteLine("Sum: " + list.Sum());
            Console.WriteLine("Max: " + list.Max());
            Console.WriteLine("Min: " + list.Min());
            Console.WriteLine("Average: " + list.Average());
        }
    }
}
