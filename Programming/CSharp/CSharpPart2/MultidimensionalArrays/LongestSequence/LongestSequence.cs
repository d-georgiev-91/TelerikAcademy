using System;

namespace LongestSequence
{
    /*Uslovie
     *3. We are given a matrix of strings of size N x M. 
     * Sequences in the matrix we define as sets of several 
     * neighbor elements located on the same line, column or 
     * diagonal. Write a program that finds the longest sequence of equal strings in the matrix.
     */
    class LongestSequence
    {
        static int ToRight(int [,] matrix, )
        {
            int frequency = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                
            }
        }
        static void Main()
        {
            //Console.Write("Input n: ");
            //int n = int.Parse(Console.ReadLine());
            //Console.Write("Input m: ");
            //int m = int.Parse(Console.ReadLine());
            //string [,] matrix = new string[m, n];
            //for (int row = 0; row < m; row++)
            //{
            //    for (int column = 0; column < n; column++)
            //    {
            //        Console.Write("m[{0},{1}]= ", row, column);
            //        matrix[row, column] = Console.ReadLine();
            //    }
            //}
            string[,] matrix = { {"ha", "fifi", "ho", "hi"},
                                 {"fo", "ha", "hi", "xx"}, 
                                 {"xxx", "ho", "ha", "xx" }};
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                        
                }
            }
        }
    }
}
