using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFraction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Addition
            var a1 = new SimpleFraction(2,3);
            var b1 = new SimpleFraction(-4,7);
            var gcd = SimpleFraction.FindGreatestCommonDivisor(3, 7);
            var lcm = SimpleFraction.GetLeastCommonMultiple(3, 7);
            var c1 = SimpleFraction.Add(a1,b1);
            a1.Add(b1);

            // Subtract
            var a2 = new SimpleFraction(2, 3);
            var b2 = new SimpleFraction(-4, 7);
            var c2 = SimpleFraction.Subtract(a2,b2);
            a2.Subtract(b2);

            // Multiply
            var a3 = new SimpleFraction(2, 3);
            var b3 = new SimpleFraction(-4, 7);
            var c3 = SimpleFraction.Multiply(a3, b3);
            a3.Multiply(b3);

            // Divide
            var a4 = new SimpleFraction(2, 3);
            var b4 = new SimpleFraction(-4, 7);
            var c4 = SimpleFraction.Divide(a4, b4);
            a4.Divide(b4);
        }
    }
}
