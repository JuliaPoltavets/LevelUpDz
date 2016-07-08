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
            PrintArray.ReverseArrayPrint(arrayToReverse);
            Console.ReadLine();
            PrintArray.SwapOddEvenArrayPrint(arrayToSwap);
            Console.ReadLine();
            PrintArray.ReflectArrayItemsPrint(arrayToReflect);
            Console.ReadLine();
            PrintArray.SwapMinMaxPrint(arrayToSwapMinMax);
            Console.ReadLine();
            PrintArray.FindNMaxElementsPrint(arrayToSwapMinMax, 2);
            Console.ReadLine();
            PrintArray.FindNMinElementsPrint(arrayToSwapMinMax,2);
            Console.ReadLine();
            PrintArray.SetEachNElementToValuePrint(arrayToSwapMinMax,2,0);
            Console.ReadLine();
        }
    }
}
