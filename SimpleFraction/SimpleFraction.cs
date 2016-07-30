using System;

namespace SimpleFraction
{
    public struct SimpleFraction
    {
        private int _numerator;
        private int _denominator;
        private int _sign;

        /// <summary>
        /// Construct new SimpleFraction struct
        /// </summary>
        /// <param name="num">numerator value</param>
        /// <param name="denom">denominator value</param>
        public SimpleFraction(int num, int denom)
        {
            _sign = 1;
            if (num * denom < 0)
            {
                _sign = -1;
            }
            _numerator = num;
            _denominator = denom;
        }


        /// <summary>
        /// Calculates greatest common divisor of two numbers
        /// </summary>
        /// <param name="numberA">first number</param>
        /// <param name="numberB">second number</param>
        /// <returns></returns>
        public static int FindGreatestCommonDivisor(int numberA, int numberB)
        {
            while (numberA != numberB)
            {
                if (numberA > numberB)
                {
                    numberA = numberA - numberB;
                }
                else
                {
                    numberB = numberB - numberA;
                }
            }
            return numberA;
        }

        /// <summary>
        /// Calculates least common multiple of two numbers
        /// </summary>
        /// <param name="numberA">first number</param>
        /// <param name="numberB">second number</param>
        /// <returns></returns>
        public static int GetLeastCommonMultiple(int numberA, int numberB)
        {
            int gcdAb = FindGreatestCommonDivisor(numberA, numberB);
            return numberA * numberB / gcdAb;
        }


    }
}