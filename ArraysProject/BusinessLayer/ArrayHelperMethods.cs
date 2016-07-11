using System;
using System.Linq;

namespace ArraysProject.BusinessLayer
{
    //0.Вывести элементы массива в обратном порядке
    //1.Поменять местами четные и нечетные элементы массива
    //2.Выполнить зеркальное отображение всех элементов массива
    //3.Найти минимальный и максимальный элементы массива и поменять их местами
    //4.Найти 3 максимальных(минимальных) элементов массива
    //5.Обнулить каждый k-й элемент массива(k задаёт пользователь)
    public class ArrayHelperMethods
    {
        public static string[] Reverse(string[] array)
        {
            string[] result = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[array.Length - 1 - i];
            }
            return result;
        }

        public static void SwapOddEven(string[] array)
        {
            for (int i = 0; i < array.Length; i = i + 2)
            {
                if ((i + 1) <= array.Length - 1)
                {
                    string temp = string.Empty;
                    temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }
            }
        }

        public static string[] ReflectArrayItems(string[] array)
        {
            string[] result = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = StringHelperMethods.Reverse(array[i]);
            }
            return result;
        }

        public static void SwapMinMax(int[] array)
        {
            var maxValueIndex = GetIndexOfMaxElement(array);
            var minValueIndex = GetIndexOfMinElement(array);
            int temp = array[maxValueIndex];
            array[maxValueIndex] = array[minValueIndex];
            array[minValueIndex] = temp;
        }

        public static int[] FindMinOrMax(int[] array, bool findMin, int count)
        {
            int[] result = new int[count];
            if (count >= array.Length)
            {
                return array;
            }
            var arrayToProcess = CopyArray(array);
            for (int i = 0; i < count; i++)
            {
                int itemToAddIndex;
                if (findMin)
                {
                    itemToAddIndex = GetIndexOfMinElement(arrayToProcess);
                    ChangeValueOfGivenElement(arrayToProcess, itemToAddIndex+1, int.MaxValue);
                }
                else
                {
                    itemToAddIndex = GetIndexOfMaxElement(arrayToProcess);
                    ChangeValueOfGivenElement(arrayToProcess, itemToAddIndex+1, int.MinValue);
                }
                result[i] = array[itemToAddIndex];
            }
            return result;
        }

        public static void ChangeValueOfGivenElement(int[] array, int index, int value = 0)
        {
            if (index == 0)
            {
                return;
            } 
            for (int i = index-1; i < array.Length; i = i + index)
            {
                array[i] = value;
            }
        }

        public static int GetIndexOfMaxElement(int[] array)
        {
            int maxValue = array[0];
            int index = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (maxValue < array[i])
                {
                    maxValue = array[i];
                    index = i;
                }
            }
            return index;
        }
        public static int GetIndexOfMinElement(int[] array)
        {
            int minValue = array[0];
            int index = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (minValue > array[i])
                {
                    minValue = array[i];
                    index = i;
                }
            }
            return index;
        }

        public static int[] CopyArray(int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i];
            }
            return result;
        }

        public static void SwapTwoIndexes(int[] array, int leftIndex, int rightIndex)
        {
            var temp = array[leftIndex];
            array[leftIndex] = array[rightIndex];
            array[rightIndex] = temp;
        }
    }
}