using System;
using ArraysProject.BusinessLayer;
using ArraysProject.PresentationLayer;

namespace ArraysProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Multiplex two matrices
            int[,] mA = new int[2, 3];
            int[,] mB = new int[3, 5];
            MultidimensionalArrays.SetRandomValues(mA, -10,10);
            MultidimensionalArrays.SetRandomValues(mB,-10,10);
            PrintArray.PrintMultidimensionalArray(mA);
            PrintArray.PrintMultidimensionalArray(mB);
            int[,] mR = MultidimensionalArrays.MultiplexTwoMatrices(mA, mB);
            PrintArray.PrintMultidimensionalArray(mR);
            Console.ReadLine();


        }
        
    }
}
