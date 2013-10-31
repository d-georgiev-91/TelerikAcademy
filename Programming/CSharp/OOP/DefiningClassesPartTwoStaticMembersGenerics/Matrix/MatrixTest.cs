using System;

namespace Matrix
{
    class MatrixTest
    {
        static void Main()
        {
            Matrix<int> matrix1 = new Matrix<int>(2, 3);
            matrix1[0, 0] = 0;
            matrix1[0, 1] = 1;
            matrix1[0, 2] = 2;

            matrix1[1, 0] = 9;
            matrix1[1, 1] = 8;
            matrix1[1, 2] = 7;

            Matrix<int> matrix2 = new Matrix<int>(2, 3);
            matrix2[0, 0] = 6;
            matrix2[0, 1] = 5;
            matrix2[0, 2] = 4;

            matrix2[1, 0] = 3;
            matrix2[1, 1] = 4;
            matrix2[1, 2] = 5;

            Console.WriteLine((matrix1 + matrix2));
            Console.WriteLine((matrix1 - matrix2));

            Matrix<int>matrix3 = new Matrix<int>(1, 3);
            matrix3[0, 0] = 1;
            matrix3[0, 1] = 2;
            matrix3[0, 2] = 3;

            Matrix<int> matrix4 = new Matrix<int>(3, 1);
            matrix4[0, 0] = 4;
            matrix4[1, 0] = 5;
            matrix4[2, 0] = 6;
            Console.WriteLine((matrix3 * matrix4));

            Matrix<int> matrix5 = new Matrix<int>(3, 3);

            CheckMatrixHasNnonZeroElements(matrix3);
        }
  
        private static void CheckMatrixHasNnonZeroElements(Matrix<int> matrix)
        {
            if (matrix)
            {
                Console.WriteLine("Martix has non-zero elements.");
            }
            else
            {
                Console.WriteLine("Martix has zero elements.");
            }
        }
    }
}