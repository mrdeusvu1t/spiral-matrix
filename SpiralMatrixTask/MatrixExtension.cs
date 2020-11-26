using System;

#pragma warning disable CA1814
#pragma warning disable S2368

namespace SpiralMatrixTask
{
    /// <summary>
    /// Matrix manipulation.
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Fills the matrix with natural numbers, starting from 1 in the top-left corner, increasing in an inward, clockwise spiral order.
        /// </summary>
        /// <param name="size">Matrix size.</param>
        /// <returns>Filled matrix.</returns>
        /// <exception cref="ArgumentException">Thrown when matrix size less or equal zero.</exception>
        /// <example> size = 3
        ///     1 2 3
        ///     8 9 4
        ///     7 6 5.
        /// </example>
        /// <example> size = 4
        ///     1  2  3  4
        ///     12 13 14 5
        ///     11 16 15 6
        ///     10 9  8  7.
        /// </example>
        public static int[,] GetMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("error");
            }

            int count = 1;
            int[,] arr = new int[size, size];


            int i = 0;
            while (i < size / 2)
            {
                for (int j = i; j < size - i; j++)
                {
                    arr[i, j] = count++;
                }

                for (int k = i + 1; k < size - i - 1; k++)
                {
                    arr[k, size - i - 1] = count++;
                }

                for (int l = size - i - 1; l >= i; l--)
                {
                    arr[size - i - 1, l] = count++;
                }

                for (int m = size - i - 2; m >= i + 1; m--)
                {
                    arr[m, i] = count++;

                    if (m + 1 == i)
                    {
                        arr[m + 1, i] = count;
                    }
                }

                i++;
            }

            if (size % 2 != 0)
            {
                arr[i, i] = count;
            }

            return arr;
        }
    }
}
