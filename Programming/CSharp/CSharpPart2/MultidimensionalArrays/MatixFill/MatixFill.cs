using System;

namespace MatixFill
{
    class MatixFill
    {
        /*
         * 1. Write a program that fills and prints a matrix of size (n, n) as shown below...
         */
        static void PrintMatrix(int [,] matrix, int n)
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main()
        {
            /*
             * 1. Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
             */
            Console.Write("Input n: ");
            int n = int.Parse(Console.ReadLine());
            int i, j;
            int[,] matrix = new int[n, n];
            //variant A
            Console.WriteLine("Variant A");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write("Input matrix element: ");
                    matrix[j, i] = int.Parse(Console.ReadLine());
                }
            }
            PrintMatrix(matrix, n);

            //variant B
            Console.WriteLine("Variant B");
            for (i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    for (j = 0; j < n; j++)
                    {
                        Console.Write("Input matrix element: ");
                        matrix[j, i] = int.Parse(Console.ReadLine());
                    }

                }
                else
                {
                    for (j = n - 1; j >= 0; j--)
                    {
                        Console.Write("Input matrix element: ");
                        matrix[j, i] = int.Parse(Console.ReadLine());
                    }
                }
            }
            PrintMatrix(matrix, n);

            //Variant C
            Console.WriteLine("Variant C");
            i = n - 1;
            j = 0;
            while (j < n)
            {
                Console.Write("Input matrix element: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
                if (j == n - 1)
                {
                    j = n - i;
                    i = 0;
                }
                else if (i == n - 1)
                {
                    i = i - 1 - j;
                    j = 0;
                }
                else
                {
                    i++;
                    j++;
                }
            }
            PrintMatrix(matrix, n);
        }
    }
}
