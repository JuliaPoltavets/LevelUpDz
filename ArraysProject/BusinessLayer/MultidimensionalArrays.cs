using System;

namespace ArraysProject.BusinessLayer
{
    public class MultidimensionalArrays
    {
        public static int[,] MultiplexTwoMatrices(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.GetLength(1) != matrixB.GetLength(0))
            {
                Console.WriteLine("Impossible to multiplex these matrices");
                return null;
            }
            int[,] matrixResult = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    for (int k = 0; k < matrixB.GetLength(0); k++)
                    {
                        matrixResult[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixResult;
        }

        public static void SetRandomValues(int[,] matrix,int leftBound = 50, int rightBound=100)
        {
            Random rnd = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(leftBound, rightBound);
                }
            }
        }
    }
}
