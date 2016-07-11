using System;
using ArraysProject.BusinessLayer;
using ArraysProject.PresentationLayer;

namespace ArraysProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayToReverse = new[]
            {
                "a",
                "b",
                "c",
                "d"
            };
            string[] arrayToSwap = new[]
            {
                "1",
                "2",
                "3",
                "4",
                "5"
            };
            string[] arrayToReflect = new[]
            {
                "hello world",
                "nice hat",
                "12345"
            };
            int[] arrayToSwapMinMax = new[]
            {
                45,
                10,
                5,
                87,
                17
            };
            //PrintArray.ReverseArrayPrint(arrayToReverse);
            //PrintArray.SwapOddEvenArrayPrint(arrayToSwap);
            //PrintArray.ReflectArrayItemsPrint(arrayToReflect);
            //PrintArray.SwapMinMaxPrint(arrayToSwapMinMax);
            //PrintArray.FindNMaxElementsPrint(arrayToSwapMinMax, 2);
            //PrintArray.FindNMinElementsPrint(arrayToSwapMinMax, 2);
            //PrintArray.SetEachNElementToValuePrint(arrayToSwapMinMax, 2, 0);
            int[] insertionSortArray = new[] { 2, 5, 4, 6, 1, 3};
            PrintArray.InsertionSortPrint(insertionSortArray);
            double[] mergeSortArray = new double[] { 2, 5, 4, 6, 1, 3 };
            PrintArray.MergeSortPrint(mergeSortArray, 0, 5);
            int[] quickSortArray = new [] { 2, 5, 4, 6, 1, 3 };
            PrintArray.QuickSortPrint(quickSortArray, 0, 5);
            int[] bubbleSortArray = new[] { 2, 5, 4, 6, 1, 3 };
            PrintArray.BubbleSortPrint(bubbleSortArray);
        }
    }
}
