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
            _numerator = Math.Abs(num);
            _denominator = Math.Abs(denom);
        }

        public void SetOppositeFractionSign()
        {
            _sign *= (-1);
        }

        /// <summary>
        /// Multiplies current instance of SimpleFraction
        /// </summary>
        /// <param name="multiplier"></param>
        public void MultiplyFraction(int multiplier)
        {
            if (multiplier < 0)
            {
                _sign *= -1;
            }
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
            int newNumerator = fraction.Numerator* multiplier;
            int newDenominator = fraction.Denominator* multiplier;
            return new SimpleFraction(newNumerator, newDenominator);
        }

        /// <summary>
        /// Calculates greatest common divisor of two numbers
        /// </summary>
        /// <param name="numberA">first number</param>
        /// <param name="numberB">second number</param>
        /// <returns></returns>
        public static int FindGreatestCommonDivisor(int numberA, int numberB)
        {
            int absA = Math.Abs(numberA);
            int absB = Math.Abs(numberB);
            while (absA != absB)
            {
                if (absA > absB)
                {
                    absA = absA - absB;
                }
                else
                {
                    absB = absB - absA;
                }
            }
            return absA;
        }

        /// <summary>
        /// Calculates least common multiple of two numbers
        /// </summary>
        /// <param name="numberA">first number</param>
        /// <param name="numberB">second number</param>
        /// <returns></returns>
        public static int GetLeastCommonMultiple(int numberA, int numberB)
        {
            int absA = Math.Abs(numberA);
            int absB = Math.Abs(numberB);
            int gcdAb = FindGreatestCommonDivisor(absA, absB);
            return absA * absB / gcdAb;
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

            int newNumerator = fractionA.Sign * fractionA.Numerator + fractionB.Sign * fractionB.Numerator;
            int newDenominator = lcmDenominators;

            return new SimpleFraction(newNumerator, newDenominator);
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

            _numerator = _sign *_numerator*increaseThis + fractionN.Sign * fractionN.Numerator;
            _denominator = lcmDenominators;
        }

        /// <summary>
        /// Adds two simple fractions 
        /// </summary>
        /// <param name="fractionA">first argument</param>
        /// <param name="fractionB">second argument</param>
        /// <returns>new simple fraction</returns>
        public static SimpleFraction Subtract(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            fractionB.SetOppositeFractionSign();
            return SimpleFraction.Add(fractionA, fractionB);
        }

        /// <summary>
        /// Subtract fraction from the current entity of simple fraction
        /// </summary>
        /// <param name="fractionN">fraction to be added to the current</param>
        public void Subtract(SimpleFraction fractionN)
        {
            fractionN.SetOppositeFractionSign();
            this.Add(fractionN);
        }
    }
}