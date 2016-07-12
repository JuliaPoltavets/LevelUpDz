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

        public static int[,] SnakeMatrixInit(int[] initData, int rowCount, int colunmCount)
        {
            int[,] result = new int[rowCount, colunmCount];
            SetRandomValues(result, 0, 0);
            int dataIndex = 0;
            int currentRow = 0;
            int currentColumn = 0;
            result[currentColumn, currentColumn] = initData[dataIndex];
            ++dataIndex;
            while ((dataIndex < initData.Length) && (dataIndex < rowCount * colunmCount))
            {
                if (currentColumn < result.GetLength(1) - 1)
                {
                    SetRight(result, initData, ref dataIndex, ref currentRow, ref currentColumn);
                }
                else
                {
                    SetDown(result, initData, ref dataIndex, ref currentRow, ref currentColumn);
                }

                SetDownDiagonal(result, initData, ref dataIndex, ref currentRow, ref currentColumn);

                if (currentRow < result.GetLength(0) - 1)
                {
                    SetDown(result, initData, ref dataIndex, ref currentRow, ref currentColumn);
                }
                else
                {
                    SetRight(result, initData, ref dataIndex, ref currentRow, ref currentColumn);
                }

                SetUpDiagonal(result, initData, ref dataIndex, ref currentRow, ref currentColumn);
            }

            return result;
        }

        public static void SetRandomValues(int[,] matrix, int leftBound = 50, int rightBound=100)
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

        #region Private
        private static void SetRight(int[,] matrix, int[] initData, ref int dataIndex, ref int currentRow, ref int currentColumn)
        {
            ++currentColumn;
            if (dataIndex < initData.Length)
            {
                matrix[currentRow, currentColumn] = initData[dataIndex];
            }
            ++dataIndex;
        }
        private static void SetDownDiagonal(int[,] matrix, int[] initData, ref int dataIndex, ref int currentRow, ref int currentColumn)
        {
            while ((currentColumn > 0)&&(currentRow < matrix.GetLength(0)-1))
            {
                --currentColumn;
                ++currentRow;
                if (dataIndex < initData.Length)
                {
                    matrix[currentRow, currentColumn] = initData[dataIndex];
                    ++dataIndex;
                }
            }
        }

        private static void SetUpDiagonal(int[,] matrix, int[] initData, ref int dataIndex, ref int currentRow, ref int currentColumn)
        {
            while ((currentRow > 0) && (currentColumn < matrix.GetLength(1) - 1))
            {
                --currentRow;
                ++currentColumn;
                if (dataIndex < initData.Length)
                {
                    matrix[currentRow, currentColumn] = initData[dataIndex];
                    ++dataIndex;
                }
            }
        }

        private static void SetDown(int[,] matrix, int[] initData, ref int dataIndex, ref int currentRow, ref int currentColumn)
        {
            ++currentRow;
            if (dataIndex < initData.Length)
            {
                matrix[currentRow, currentColumn] = initData[dataIndex];
            }
            ++dataIndex;
        }
        #endregion

    }
}
