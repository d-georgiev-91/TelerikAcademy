using System;

namespace FirstBiggerThanItsNeigbours
{
    class FirstBiggerThanItsNeigbours
    {
        /*
         * 6. Write a method that returns the index of the first element in array 
         * that is bigger than its neighbors, or -1, if there’s no such element.
         */
        static bool BiggerThanNeigbours(int[] array, int index)
        {
            if (index == 0)
            {
                return array[index] > array[index + 1];
            }
            else if (index == array.Length - 1)
            {
                return array[index] > array[index - 1];
            }
            else
            {
                return (array[index] > array[index - 1]) && (array[index] > array[index + 1]);
            }
        }
        static void Main()
        {

            Console.Write("Input array size: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Input array element: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (BiggerThanNeigbours(array, i))
                {   
                    Console.WriteLine("The index of the element is {0}.", i);
                    break;
                }
            }
        }
    }
}
