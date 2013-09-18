using System;

namespace QuickSort
{
    /*
     * 14. Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
     */
    class QuickSort
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static int Partition(int [] array, int left, int right, int pivotIndex)
        {
            int pivotValue = array[pivotIndex];
            Swap(ref array[pivotIndex], ref array[right]);
            int storeIndex = left;
            for(int i = left; i < right; i++)
                if (array[i] < pivotValue)
                {
                    Swap(ref array[i], ref array[storeIndex]);
                    storeIndex++;
                }
            Swap(ref array[storeIndex], ref array[right]);
            return storeIndex;
        }
        static void QSort(int [] array, int left, int right)
        {

            if (left < right)
            {
                int pivotIndex = (left + right) / 2;
                int pivotNewIndex = Partition(array, left, right, pivotIndex);
                QSort(array, left, pivotNewIndex - 1);
                QSort(array, pivotNewIndex + 1, right);
            }
        }
        static void Main()
        {
            /* Uslovie
             * 14. Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
             */
            Console.Write("Input array length: ");
            int arrayLenth = int.Parse(Console.ReadLine());
            int[] array = new int[arrayLenth];
            for (int i = 0; i < arrayLenth; i++)
            {
                Console.Write("Input array elemet with index [{0}]: ", i);
                array[i] = int.Parse(Console.ReadLine());
            }
            QSort(array, 0, arrayLenth - 1);
            Console.WriteLine("The sorted array is: ");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
