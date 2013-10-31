using System;
using System.Text;

namespace Matrix
{
    class Matrix<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private int rows;
        private int cols;
        private T[,] matrix;

        public int Rows
        {
            get
            {
                return this.rows;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }
        }

        public T this[int rows, int cols]
        {
            get
            {
                if ((rows >= 0 && rows < this.Rows) && cols >= 0 && cols < this.Cols)
                {
                    return matrix[rows, cols];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of boundries");
                }
            }

            set
            {
                if ((rows >= 0 && rows < this.Rows) && (cols >= 0 && cols < this.Cols))
                {
                    matrix[rows, cols] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of boundries");
                }
            }
        }

        public Matrix(int rows, int cols)
        {
            this.matrix = new T[rows, cols];
            this.rows = rows;
            this.cols = cols;
        }

        public static Matrix<T> operator +(Matrix<T> leftSide, Matrix<T> rightSide)
        {
            if (leftSide.Cols != 0 && leftSide.Rows != 0 && rightSide.Cols != 0 && rightSide.Rows != 0)
            {
                if (leftSide.Rows == rightSide.Rows && leftSide.Cols == rightSide.Cols)
                {
                    Matrix<T> result = new Matrix<T>(leftSide.rows, leftSide.cols);
                    for (int i = 0; i < leftSide.Rows; i++)
                    {
                        for (int j = 0; j < leftSide.cols; j++)
                        {
                            result[i, j] = (dynamic)leftSide[i, j] + rightSide[i, j];
                        }
                    }

                    return result;
                }
                else
                {
                    throw new InvalidOperationException("Matrices should have the same rows and columns.");
                }
            }
            else
            {
                throw new NullReferenceException("Matrices doesn't contains any elements.");
            }
        }

        public static Matrix<T> operator -(Matrix<T> leftSide, Matrix<T> rightSide)
        {
            if (leftSide.Cols != 0 && leftSide.Rows != 0 && rightSide.Cols != 0 && rightSide.Rows != 0)
            {
                if (leftSide.Rows == rightSide.Rows && leftSide.Cols == rightSide.Cols)
                {
                    Matrix<T> result = new Matrix<T>(leftSide.rows, leftSide.cols);

                    for (int i = 0; i < leftSide.Rows; i++)
                    {
                        for (int j = 0; j < leftSide.cols; j++)
                        {
                            result[i, j] = (dynamic)leftSide[i, j] - rightSide[i, j];
                        }
                    }

                    return result;
                }
                else
                {
                    throw new InvalidOperationException("Matrices should have the same rows and columns.");
                }
            }
            else
            {
                throw new NullReferenceException("Matrices doesn't contains any elements.");
            }
        }

        public static Matrix<T> operator *(Matrix<T> leftSide, Matrix<T> rightSide)
        {
            if (leftSide.Cols != 0 && leftSide.Rows != 0 && rightSide.Cols != 0 && rightSide.Rows != 0)
            {
                if (leftSide.Cols == rightSide.Rows)
                {
                    Matrix<T> result = new Matrix<T>(leftSide.Rows, rightSide.Cols);

                    for (int i = 0; i < result.Rows; i++)
                    {
                        for (int j = 0; j < result.Cols; j++)
                        {
                            result[i, j] = default(T);

                            for (int k = 0; k < leftSide.Rows; k++)
                            {
                                result[i, j] += (dynamic)leftSide[i, k] * rightSide[k, j];
                            }
                        }
                    }

                    return result;
                }
                else
                {
                    throw new InvalidOperationException("Matrices should have the same rows and columns.");
                }
            }
            else
            {
                throw new NullReferenceException("Matrices doesn't contains any elements.");
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    if (row == this.Rows - 1 && col == this.Cols - 1)
                    {
                        result.Append(matrix[row, col] + ".");
                    }
                    else
                    {
                        result.Append(matrix[row, col] + ", ");
                    }
                }

                result.Append("\n");
            }

            return result.ToString();
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if (matrix[row, col].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if (!matrix[row, col].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}