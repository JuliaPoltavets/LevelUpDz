using System;

namespace ArraysProject.BusinessLayer
{
    public class JaggedArrays
    {
        public static void SetRndValuesForNSubArrays(int[][] jaggedArray, int elementCount, int minValue, int maxValue)
        {
            Random rndValues = new Random();
            for (int i = 0; i < elementCount; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    jaggedArray[i][j] = rndValues.Next(minValue, maxValue);
                }
            }
        }

        public static void InitNElementsWithRndLength(int[][] jaggedArray, int elementCount, int minValue, int maxValue)
        {
            Random rndValues = new Random();
            for (int i = 0; i < elementCount; i++)
            {
                int elementsCount = rndValues.Next(minValue, maxValue);
                jaggedArray[i] = new int[elementsCount];
            }
        }

        public static void InitJaggedSubArrayByIndex(int[][] jaggedArray, int elementIndex, int minValue, int maxValue)
        {
            Random rndValues = new Random();
            int elementsCount = rndValues.Next(minValue, maxValue);
            jaggedArray[elementIndex] = new int[elementsCount];
        }

        public static void SetSubArrayByIndex(int[][] jaggedArray, int elementIndex, int[] valueToSet)
        { 
            if (elementIndex < jaggedArray.Length)
            {
                jaggedArray[elementIndex] = valueToSet;
            }
        }
    }
}