using System;

namespace SimpleFraction
{
    public struct SimpleFraction
    {
        private int _numerator;
        private int _denominator;
        private int _sign;

        public int Numerator
        {
            get { return _numerator; }
        }

        public int Denominator
        {
            get { return _denominator; }
        }

        public int Sign
        {
            get { return _sign; }
        }

        /// <summary>
        /// Construct new SimpleFraction struct
        /// </summary>
        /// <param name="num">numerator value</param>
        /// <param name="denom">denominator value</param>
        public SimpleFraction(int num, int denom)
        {
            _sign = 1;
            if (num*denom < 0)
            {
                _sign = -1;
            }
            _numerator = num;
            _denominator = denom;
        }

        /// <summary>
        /// Multiplies current instance of SimpleFraction
        /// </summary>
        /// <param name="multiplier"></param>
        public void MultiplyFraction(int multiplier)
        {
            _denominator *= multiplier;
            _numerator *= multiplier;
        }

        /// <summary>
        /// Multiplies particular fraction on the value
        /// </summary>
        /// <param name="fraction">fraction to be multiplied</param>
        /// <param name="multiplier">multiplier value</param>
        /// <returns>returns new fraction</returns>
        public static SimpleFraction MultiplyFraction(SimpleFraction fraction, int multiplier)
        {
            int newNumerator = fraction.Numerator*multiplier;
            int newDenominator = fraction.Denominator*multiplier;
            return new SimpleFraction(fraction.Sign*newNumerator, newDenominator);
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
            return numberA*numberB/gcdAb;
        }

        /// <summary>
        /// Adds two simple fractions 
        /// </summary>
        /// <param name="fractionA">first argument</param>
        /// <param name="fractionB">second argument</param>
        /// <returns>new simple fraction</returns>
        public static SimpleFraction Add(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            int lcmDenominators = GetLeastCommonMultiple(fractionA.Denominator, fractionB.Denominator);
            int increaseA = lcmDenominators/fractionA.Denominator;
            int increaseB = lcmDenominators/fractionB.Denominator;

            fractionA.MultiplyFraction(increaseA);
            fractionB.MultiplyFraction(increaseB);

            int newNumerator = fractionA.Numerator + fractionB.Numerator;
            int newDenominator = lcmDenominators;
            int newSign = fractionA.Sign*fractionB.Sign;

            return new SimpleFraction(newSign*newNumerator, newDenominator);
        }
        
        /// <summary>
        /// Add new fraction to the current entity of simple fraction
        /// </summary>
        /// <param name="fractionN">fraction to be added to the current</param>
        public void Add(SimpleFraction fractionN)
        {
            int lcmDenominators = GetLeastCommonMultiple(_denominator, fractionN.Denominator);
            int increaseThis = lcmDenominators / _denominator;
            int increaseN = lcmDenominators / fractionN.Denominator;

            fractionN.MultiplyFraction(increaseN);

            _numerator = _numerator*increaseThis + fractionN.Numerator;
            _denominator = lcmDenominators;
            _sign = _sign*fractionN.Sign;
        }
    }
}