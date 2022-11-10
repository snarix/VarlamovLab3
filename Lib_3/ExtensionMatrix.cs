using System;
using LibMatrix;

namespace Lib_3
{
    public static class ExtensionMatrix
    {
        public static void CreateArray(this Matrix<int> matrix, int min = 1, int max = 10)
        {
            Random rnd = new Random();

            for (int i = 0; i < matrix.Column; i++)
            {
                for (int j = 0; j < matrix.Row; j++)
                {
                    matrix[i, j] = rnd.Next(min, max);
                }
            }
        }

        public static int ArrayDifference(this Matrix<int> matrix)
        {
            int diff = matrix[0,0];
            for (int i = 0; i < matrix.Column; i++)
            {
                for (int j = 1; j < matrix.Row; j++)
                {
                    diff -= matrix[i,j];
                }
            }
            return diff;
        }

    }
}
