using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableExtension
{
    public static class IEnumerableExtension
    {
        static public T Sum<T>(this IEnumerable<T> items) where T : IComparable
        {
            dynamic sum = 0;
            foreach (var item in items)
            {
                sum += item;
            }
            return sum;
        }

        static public T Product<T>(this IEnumerable<T> items) where T : IComparable
        {
            dynamic product = 1;

            foreach (var item in items)
            {
                product *= item;
            }

            return product;
        }

        static public T Max<T>(this IEnumerable<T> items) where T : IComparable
        {
            dynamic max = items.First();

            foreach (var item in items)
            {
                if (max < item)
                {
                    max = item;
                }
            }

            return max;
        }

        static public T Min<T>(this IEnumerable<T> items) where T : IComparable
        {
            dynamic min = items.First();

            foreach (var item in items)
            {
                if (min > item)
                {
                    min = item;
                }
            }

            return min;
        }

        static public decimal Average<T>(this IEnumerable<T> items) where T : IComparable, IConvertible
        {
            dynamic average = Convert.ToDecimal(items.Sum()) / Convert.ToDecimal(items.Count());
            return average;
        }
    }
}
