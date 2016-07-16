using System;
using ArraysProject.BusinessLayer;
using ArraysProject.PresentationLayer;

namespace ArraysProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Multiplex two matrices
            //int[,] mA = new int[2, 3];
            //int[,] mB = new int[3, 5];
            //MultidimensionalArrays.SetRandomValues(mA, -10, 10);
            //MultidimensionalArrays.SetRandomValues(mB, -10, 10);
            //PrintArray.PrintMultidimensionalArray(mA);
            //PrintArray.PrintMultidimensionalArray(mB);
            //int[,] mR = MultidimensionalArrays.MultiplexTwoMatrices(mA, mB);
            //PrintArray.PrintMultidimensionalArray(mR);
            //Console.ReadLine();

            ////Snake setup
            //var initArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            //var snakeArray = MultidimensionalArrays.SnakeMatrixInit(initArray, 3, 4);
            //PrintArray.PrintMultidimensionalArray(snakeArray);
            //Console.ReadLine();

            //Teamperature calendar
            TemperatureCalendarProgram.RunTemperatureCalendar();
            Console.ReadLine();
        }
        
    }
}
