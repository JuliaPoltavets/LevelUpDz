using System;

namespace SimpleFraction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Addition
            SimpleFraction a1 = new SimpleFraction(2,3);
            SimpleFraction b1 = new SimpleFraction(-4,7);
            SimpleFraction c1 = SimpleFraction.Add(a1,b1);
            SimpleFraction d1 = a1 + b1;
            a1.Add(b1);

            // Subtract
            SimpleFraction a2 = new SimpleFraction(2, 3);
            SimpleFraction b2 = new SimpleFraction(-4, 7);
            SimpleFraction c2 = SimpleFraction.Subtract(a2, b2);
            SimpleFraction d2 = a2 - b2;
            a2.Subtract(b2);

            // Multiply
            SimpleFraction a3 = new SimpleFraction(2, 3);
            SimpleFraction b3 = new SimpleFraction(-4, 7);
            SimpleFraction c3 = SimpleFraction.Multiply(a3, b3);
            SimpleFraction d3 = a3 * b3;
            a3.Multiply(b3);

            // Divide
            SimpleFraction a4 = new SimpleFraction(2, 3);
            SimpleFraction b4 = new SimpleFraction(-4, 7);
            SimpleFraction c4 = SimpleFraction.Divide(a4, b4);
            SimpleFraction d4 = a4 / b4;
            a4.Divide(b4);

            //Reduce fraction
            SimpleFraction c5;
            SimpleFraction a5 = new SimpleFraction(20, 40);
            bool flag = SimpleFraction.TryReduce(a5, out c5);
            Console.ReadLine();
        }
    }
}
