
using System;

namespace ArraysProject.BusinessLayer
{
    public class StringHelperMethods
    {
        public static string Reverse(string input)
        {
            string result = String.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                result += input[input.Length - 1 - i];
            }
            return result;
        }

        public static int[] StringToIntArray(string inputString, char separator)
        {
            string[] stringToArray = inputString.Split(separator);
            int[] tempArray = new int[stringToArray.Length];
            int valuesToSetIndex = 0;
            foreach (string str in stringToArray)
            {
                int value;
                if (int.TryParse(str, out value))
                {
                    tempArray[valuesToSetIndex] = value;
                    valuesToSetIndex++;
                }
            }
            int[] resultArray = new int[valuesToSetIndex];
            Array.Copy(tempArray, 0, resultArray, 0, valuesToSetIndex);
            return resultArray;
        }
    }
}