
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
    }
}