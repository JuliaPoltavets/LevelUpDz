﻿using System;
using System.Diagnostics;
using ArraysProject.BusinessLayer;

namespace ArraysProject.PresentationLayer
{
    public class PrintArray
    {
        public void PrintSingleArray(int[] givenArray, string message, string[,] arrayArgs=null)
        {
            Console.Write(message);
            PrintArrayOnConsole(givenArray);
            Console.WriteLine();
            if (arrayArgs != null)
            {

            }
        }

        public void PrintInitAndOutputArrays(int[] initArray, int[] outputArray, string message, string[,] arrayArgs = null)
        {
            Console.WriteLine(message);
            Console.Write("Intial array is ");
            PrintArrayOnConsole(initArray);
            Console.Write("Output array is ");
            PrintArrayOnConsole(outputArray);
            if (arrayArgs != null)
            {

            }
        }

        public static void PrintMultidimensionalArray(int[,] matrix)
        {
            int matrixPrintPadding = GetMaxPad(matrix) + 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("[{0," + matrixPrintPadding+"}]",matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static int GetMaxPad(int[,] matrix)
        {
            int result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int curElLength = matrix[i, j].ToString().Length;
                    if (result < curElLength)
                    {
                        result = curElLength;
                    }
                }
            }
            return result;
        }

        private static void PrintArrayOnConsole(string[] array)
        {
            string result = "{";
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    result += array[i] + "}";
                }
                else
                {
                    result += array[i] + ", ";
                }
            }
            Console.WriteLine(result);
        }

        private static void PrintArrayOnConsole(double[] array)
        {
            string result = "{";
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    result += array[i] + "}";
                }
                else
                {
                    result += array[i] + ", ";
                }
            }
            Console.WriteLine(result);
        }

        private static void PrintArrayOnConsole(int[] array)
        {
            string result = "{";
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    result += array[i] + "}";
                }
                else
                {
                    result += array[i] + ", ";
                }
            }
            Console.WriteLine(result);
        }
    }
}