using System;
using System.Diagnostics;
using ArraysProject.BusinessLayer;

namespace ArraysProject.PresentationLayer
{
    public class PrintArray
    {
        public static void ReverseArrayPrint(string[] array)
        {
            Console.Write("Task to revers the array ");
            PrintArrayOnConsole(array);
            Console.Write("Reversed array is ");
            var reversedArray = ArrayHelperMethods.Reverse(array);
            PrintArrayOnConsole(reversedArray);
            Console.ReadLine();
        }

        public static void SwapOddEvenArrayPrint(string[] array)
        {
            Console.Write("Task to swap odd with even element of the array ");
            PrintArrayOnConsole(array);
            Console.Write("Swapped array is ");
            ArrayHelperMethods.SwapOddEven(array);
            PrintArrayOnConsole(array);
            Console.ReadLine();
        }

        public static void ReflectArrayItemsPrint(string[] array)
        {
            Console.Write("Task to reflect all elementes in the array ");
            PrintArrayOnConsole(array);
            Console.Write("Array with reflected items is ");
            var reflectedArray = ArrayHelperMethods.ReflectArrayItems(array);
            PrintArrayOnConsole(reflectedArray);
            Console.ReadLine();
        }

        public static void SwapMinMaxPrint(int[] array)
        {
            Console.Write("Task to swap min and max in the array ");
            PrintArrayOnConsole(array);
            Console.Write("Array with swapped min and max is ");
            ArrayHelperMethods.SwapMinMax(array);
            PrintArrayOnConsole(array);
            Console.ReadLine();
        }

        public static void FindNMaxElementsPrint(int[] array, int count)
        {
            Console.Write("Task find " + count +" Max elements in the array ");
            PrintArrayOnConsole(array);
            Console.Write("Max " + count + " elements in array are ");
            var maxResult = ArrayHelperMethods.FindMinOrMax(array,false,count);
            PrintArrayOnConsole(maxResult);
            Console.ReadLine();
        }

        public static void FindNMinElementsPrint(int[] array, int count)
        {
            Console.Write("Task find " + count + " Min elements in the array ");
            PrintArrayOnConsole(array);
            Console.Write("Min " + count + " elements in array are ");
            var minResult = ArrayHelperMethods.FindMinOrMax(array, true, count);
            PrintArrayOnConsole(minResult);
            Console.ReadLine();
        }

        public static void SetEachNElementToValuePrint(int[] array, int index, int value)
        {
            Console.Write("Task set each " + index + " element " + " equal to "+ value + " in array ");
            PrintArrayOnConsole(array);
            Console.Write("New array is ");
            ArrayHelperMethods.ChangeValueOfGivenElement(array, index, value);
            PrintArrayOnConsole(array);
            Console.ReadLine();
        }

        public static void InsertionSortPrint(int[] array)
        {
            Console.Write("Task sort the array ");
            PrintArrayOnConsole(array);
            Console.Write("Using Insertion Sort algorithm sorted array is ");
            Stopwatch watch = Stopwatch.StartNew();
            SortingAlgorithms.InsertionSort(array);
            watch.Stop();
            PrintArrayOnConsole(array);
            Console.WriteLine("Sorting took " + watch.ElapsedMilliseconds + " ms");
            Console.ReadLine();
        }

        public static void MergeSortPrint(double[] array, int leftBound, int rightBound)
        {
            Console.Write("Task sort the array ");
            PrintArrayOnConsole(array);
            Console.Write("Using Merge Sort algorithm sorted array is ");
            Stopwatch watch = Stopwatch.StartNew();
            SortingAlgorithms.MergeSort(array,0,array.Length-1);
            watch.Stop();
            PrintArrayOnConsole(array);
            Console.WriteLine("Sorting took " + watch.ElapsedMilliseconds + " ms");
            Console.ReadLine();
        }

        public static void QuickSortPrint(int[] array, int leftBound, int rightBound)
        {
            Console.Write("Task sort the array ");
            PrintArrayOnConsole(array);
            Console.Write("Using Quick Sort algorithm sorted array is ");
            Stopwatch watch = Stopwatch.StartNew();
            SortingAlgorithms.QuickSort(array, leftBound, rightBound);
            watch.Stop();
            PrintArrayOnConsole(array);
            Console.WriteLine("Sorting took " + watch.ElapsedMilliseconds + " ms");
            Console.ReadLine();
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