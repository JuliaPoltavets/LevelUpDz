using System;

namespace SimpleFraction
{
    public struct SimpleFraction
    {
        private int _numerator;
        private int _denominator;
        private int _sign;

        #region InsteadOfProperties

        /// <summary>
        /// Returns value of the numerator for the current fraction
        /// </summary>
        /// <returns>value of the numerator</returns>
        public int GetNumerator()
        {
            return _sign*_numerator;
        }

        /// <summary>
        /// Returns value of the denominator for the current fraction
        /// </summary>
        /// <returns>value of the denominator</returns>
        public int GetDenominator()
        {
            return _denominator;
        }

        #endregion

        /// <summary>
        /// Construct new SimpleFraction struct
        /// </summary>
        /// <param name="num">_numerator value</param>
        /// <param name="denom">denominator value</param>
        public SimpleFraction(int num, int denom)
        {
            if (denom == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(denom), "_denominator can not be equal to zero");
            }
            _sign = 1;
            if (num*denom < 0)
            {
                _sign = -1;
            }
            _numerator = Math.Abs(num);
            _denominator = Math.Abs(denom);
        }

        public void SetOppositeFraction_sign()
        {
            _sign *= (-1);
        }

        /// <summary>
        /// Multiplies current instance of SimpleFraction
        /// </summary>
        /// <param name="multiplier"></param>
        public void MultiplyFraction(int multiplier)
        {
            int absMultoplier = Math.Abs(multiplier);
            if (multiplier < 0)
            {
                _sign *= -1;
            }
            _numerator *= absMultoplier;
        }

        /// <summary>
        /// Multiplies particular fraction on the value
        /// </summary>
        /// <param name="fraction">fraction to be multiplied</param>
        /// <param name="multiplier">multiplier value</param>
        /// <returns>returns new fraction</returns>
        public static SimpleFraction MultiplyFraction(SimpleFraction fraction, int multiplier)
        {
            int new_numerator = fraction._sign*fraction._numerator* multiplier;
            return new SimpleFraction(new_numerator, fraction._denominator);
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
            int lcm_denominators = GetLeastCommonMultiple(fractionA._denominator, fractionB._denominator);
            int increaseA = lcm_denominators/fractionA._denominator;
            int increaseB = lcm_denominators/fractionB._denominator;

            fractionA.MultiplyFraction(increaseA);
            fractionB.MultiplyFraction(increaseB);

            int new_numerator = fractionA._sign * fractionA._numerator + fractionB._sign * fractionB._numerator;
            int new_denominator = lcm_denominators;

            return new SimpleFraction(new_numerator, new_denominator);
        }
        
        /// <summary>
        /// Add new fraction to the current entity of simple fraction
        /// </summary>
        /// <param name="fractionN">fraction to be added to the current</param>
        public void Add(SimpleFraction fractionN)
        {
            int lcm_denominators = GetLeastCommonMultiple(_denominator, fractionN._denominator);
            int increaseThis = lcm_denominators / _denominator;
            int increaseN = lcm_denominators / fractionN._denominator;

            fractionN.MultiplyFraction(increaseN);

            _numerator = _sign *_numerator*increaseThis + fractionN._sign * fractionN._numerator;
            _denominator = lcm_denominators;
        }

        /// <summary>
        /// Adds two simple fractions 
        /// </summary>
        /// <param name="fractionA">first argument</param>
        /// <param name="fractionB">second argument</param>
        /// <returns>new simple fraction</returns>
        public static SimpleFraction Subtract(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            fractionB.SetOppositeFraction_sign();
            return SimpleFraction.Add(fractionA, fractionB);
        }

        /// <summary>
        /// Subtract fraction from the current instance of simple fraction
        /// </summary>
        /// <param name="fractionN">fraction to be added to the current</param>
        public void Subtract(SimpleFraction fractionN)
        {
            fractionN.SetOppositeFraction_sign();
            this.Add(fractionN);
        }

        /// <summary>
        /// Multiply one fraction on another
        /// </summary>
        /// <param name="fractionA">first argument</param>
        /// <param name="fractionB">second argument</param>
        /// <returns>new instance of SimpleFraction type</returns>
        public static SimpleFraction Multiply(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            int new_numerator = fractionA._sign * fractionA._numerator * fractionB._sign * fractionB._numerator;
            int new_denominator = fractionA._denominator * fractionB._denominator;
            return new SimpleFraction(new_numerator,new_denominator);
        }

        /// <summary>
        /// Multiply current instance of fraction on another fraction
        /// </summary>
        /// <param name="fractionN"></param>
        public void Multiply(SimpleFraction fractionN)
        {
            _sign *= fractionN._sign;
            _numerator *= fractionN._numerator;
            _denominator *= fractionN._denominator;
        }

        /// <summary>
        /// Divide one fraction on another
        /// </summary>
        /// <param name="fractionA">first argument</param>
        /// <param name="fractionB">second argument</param>
        /// <returns>new instance of SimpleFraction type</returns>
        public static SimpleFraction Divide(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            int new_numerator = fractionA._sign * fractionA._numerator * fractionB._denominator;
            int new_denominator = fractionA._denominator * fractionB._sign*fractionB._numerator;
            return new SimpleFraction(new_numerator, new_denominator);
        }

        /// <summary>
        /// Multiply current instance of fraction on another fraction
        /// </summary>
        /// <param name="fractionN"></param>
        public void Divide(SimpleFraction fractionN)
        {
            _sign *= fractionN._sign;
            _numerator *= fractionN._denominator;
            _denominator *= fractionN._numerator;
        }

        /// <summary>
        /// Reduce fraction if it is possible using greatest common divisor
        /// </summary>
        /// <param name="fraction"></param>
        /// <returns></returns>
        public static bool TryReduce(SimpleFraction fraction, out SimpleFraction reducedFraction)
        {
            bool wasReduced = false;
            reducedFraction = fraction;
            int gcd = FindGreatestCommonDivisor(fraction._numerator, fraction._denominator);
            if (gcd != 1)
            {
                int new_numerator = fraction._numerator/gcd;
                int new_denominator = fraction._denominator/gcd;
                reducedFraction = new SimpleFraction(fraction._sign*new_numerator, new_denominator);
                wasReduced = true;
            }
            return wasReduced;
        }
    }
}