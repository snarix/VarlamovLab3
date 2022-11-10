using System;
using LibMatrix;

namespace Lib_3
{
    public static class ExtensionMatrix
    {
        public static void CreateArray(this Matrix<int> matrix, int min = 1, int max = 10)
        {
            Random rnd = new Random();

            for (int i = 0; i < matrix.CountRow; i++)
            {
                for (int j = 0; j < matrix.CountColumn; j++)
                {
                    matrix[i, j] = rnd.Next(min, max);
                }
            }
        }

        public static int ArrayDifference(this Matrix<int> matrix)
        {
            int diff = 0;
            for (int i = 0; i < matrix.CountRow; i++)
            {
                for (int j = 0; j < matrix.CountColumn; j++)
                {
                    diff -= matrix[i,j];                   
                }
            }
            return diff;
        }

    }
}
