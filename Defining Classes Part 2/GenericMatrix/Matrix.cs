/* Problem 8. Matrix 
    Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). */

/* Problem 9. Matrix indexer 
    Implement an indexer this[row, col] to access the inner matrix cells.*/

/* Problem 10. Matrix operations
   Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
   Throw an exception when the operation cannot be performed.
   Implement the true operator (check for non-zero elements). */

namespace GenericMatrix
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Matrix<T> : IEnumerable<T> where T : struct, IComparable
    {
        private readonly T[,] content;
        private readonly int rowsLength;
        private readonly int colsLength;

        public Matrix(int rows, int cols)
        {
            this.ValidateNumericType();

            this.content = new T[rows, cols];
            this.rowsLength = rows;
            this.colsLength = cols;
        }

        private void ValidateNumericType()
        {
            var type = typeof(T);
            if (type != typeof(Int16) &&
                type != typeof(Int32) &&
                type != typeof(Int64) &&
                type != typeof(UInt16) &&
                type != typeof(UInt32) &&
                type != typeof(UInt64) &&
                type != typeof(float) &&
                type != typeof(double) &&
                type != typeof(decimal))
            {
                throw new ApplicationException("The matrix should be of numeric type");
            }
        }

        public T this[int row, int col]
        {
            get
            {
                this.ValidateCellIndex(row, col);
                return this.content[row, col];
            }

            set
            {
                this.ValidateCellIndex(row, col);
                this.content[row, col] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.rowsLength; i++)
            {
                for (int j = 0; j < this.colsLength; j++)
                {
                    yield return this.content[i, j];
                }
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            ValidateMatrixSizes(first, second);
            Matrix<T> result = PerformOperation(first, second, 1);

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            ValidateMatrixSizes(first, second);
            Matrix<T> result = PerformOperation(first, second, -1);

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            ValidateMatrixDimensions(first, second);

            Matrix<T> result = new Matrix<T>(first.rowsLength, second.colsLength);
            for (int i = 0; i < result.rowsLength; i++)
            {
                for (int j = 0; j < result.colsLength; j++)
                {
                    dynamic value = 1;
                    for (int k = 0; k < first.colsLength; k++)
                    {
                        value += first[i, k] * (dynamic)second[k, i];
                    }

                    result[i, j] = value;
                }
            }

            return result;
        }

        private static void ValidateMatrixDimensions(Matrix<T> first, Matrix<T> second)
        {
            if (first.colsLength != second.rowsLength)
            {
                throw new InvalidOperationException("Matrixes cannot be multiplied");
            }
        }

        public static Matrix<T> operator /(Matrix<T> first, Matrix<T> second)
        {
            ValidateMatrixSizes(first, second);
            Matrix<T> result = PerformOperation(first, second, 1);

            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            foreach (var element in matrix)
            {
                if ((int)Convert.ChangeType(element, typeof(int)) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            foreach (var element in matrix)
            {
                if ((int)Convert.ChangeType(element, typeof(int)) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void ValidateCellIndex(int row, int col)
        {
            if (row < 0 || this.rowsLength <= row)
            {
                throw new IndexOutOfRangeException("Invalid row index");
            }

            if (col < 0 || this.colsLength <= col)
            {
                throw new IndexOutOfRangeException("Invalid col index");
            }
        }

        private static Matrix<T> PerformOperation(Matrix<T> first, Matrix<T> second, int flag)
        {
            var result = new Matrix<T>(first.rowsLength, first.colsLength);

            for (int i = 0; i < result.rowsLength; i++)
            {
                for (int j = 0; j < result.colsLength; j++)
                {
                    dynamic value = first[i, j] + ((dynamic)second[i, j] * flag);
                    result[i, j] = value;
                }
            }

            return result;
        }

        private static void ValidateMatrixSizes(Matrix<T> first, Matrix<T> second)
        {
            if (first.rowsLength != second.rowsLength)
            {
                throw new InvalidOperationException("The matrixes are of different rows length");
            }

            if (first.colsLength != second.colsLength)
            {
                throw new InvalidOperationException("The matrixes are of different cols length");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}