using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysProject.BusinessLayer
{
    public class SortingAlgorithms
    {
        public static void InsertionSort(int[] array)
        {
            for (int j = 1; j < array.Length; j++)
            {
                int key = array[j];
                int i = j - 1;
                while ((i >= 0) && (array[i] > key))
                {
                    array[i + 1] = array[i];
                    i = i - 1;
                }
                array[i + 1] = key;
            }
        }

        public static void MergeSort(double[] array, int leftBound, int rightBound)
        {
            if (leftBound < rightBound)
            {
                int middleIndex = (leftBound + rightBound) / 2;
                MergeSort(array, leftBound, middleIndex);
                MergeSort(array, middleIndex + 1, rightBound);
                MergeArrays(array, leftBound, middleIndex, rightBound);
            }
        }

        public static void QuickSort(int[] array, int leftBound, int rightBound)
        {
            if (leftBound < rightBound)
            {
                var sortedIndex = Partition(array, leftBound, rightBound);
                QuickSort(array, leftBound, sortedIndex - 1);
                QuickSort(array, sortedIndex + 1,rightBound);

            }
        }

        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length;i++)
            {
                for (int j = 0; j <= array.Length - 2; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        ArrayHelperMethods.SwapTwoIndexes(array, j, j+1);
                    }                     
                }
            }
        }

        private static int Partition(int[] array, int leftBound, int rightBound)
        {
            int pivotElementValue = array[rightBound];
            int ltePivotCounter = leftBound;
            for (int gtPivotCounter = leftBound; gtPivotCounter <= rightBound - 1; gtPivotCounter++)
            {
                if (array[gtPivotCounter] <= pivotElementValue)
                {
                    ArrayHelperMethods.SwapTwoIndexes(array, ltePivotCounter, gtPivotCounter);
                    ltePivotCounter++;
                }
            }
            ArrayHelperMethods.SwapTwoIndexes(array, ltePivotCounter, rightBound);
            return ltePivotCounter;
        }

        public static void MergeArrays(double[] array, int leftBound, int middleIndex, int rightBound)
        {
            var leftSubArrayLength = middleIndex - leftBound + 1;
            var rightSubArrayLength = rightBound - middleIndex;
            double[] leftArray = new double[leftSubArrayLength+1];
            double[] rightArray = new double[rightSubArrayLength+1];
            Array.Copy(array, leftBound, leftArray, 0, leftSubArrayLength);
            Array.Copy(array, middleIndex+1, rightArray, 0, rightSubArrayLength);
            leftArray[leftArray.Length - 1] = double.PositiveInfinity;
            rightArray[rightArray.Length - 1] = double.PositiveInfinity;


            int leftCounter = 0;
            int rightCounter = 0;

            for (int k = leftBound; k <= rightBound; k++)
            {
                if (leftArray[leftCounter] <= rightArray[rightCounter])
                {
                    array[k] = leftArray[leftCounter];
                    leftCounter++;
                }
                else
                {
                    array[k] = rightArray[rightCounter];
                    rightCounter++;
                }
            }
        }
    }
}
