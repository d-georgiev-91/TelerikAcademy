using System;

namespace FindingValueInArray
{
    class FindingValueInArray
    {
        static void Main()
        {
            int [] array = new int[100];

            FillArray(array);

            LookForValueInArray(array, 352);

            //LookForValueInArray(array, 15);
        }

        public static void LookForValueInArray(int[] array, int value)
        {

            bool isValueFound = false;
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
                if (array[i] == value)
                {
                    isValueFound = true;
                    break;
                }
            }

            if (isValueFound)
            {
                Console.WriteLine("Value found!");
            }
            else
            {
                Console.WriteLine("Value not found!");
            }
        }

        public static void FillArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
        }
    }
}
