using System;

namespace SimpleFraction
{
    public class SimpleFraction
    {
        private int _numerator;
        private int _denominator;
        private int _sign;
        private FractionExceptions _fractionExceptions;

        #region FractionProperties

        /// <summary>
        /// Gets and sets value of the numerator for the current fraction
        /// </summary>
        /// <returns>value of the numerator</returns>
        public int Numerator
        {
            get
            {
                return _numerator;
            }
            private set
            {
                _numerator = Math.Abs(value);
            }
        }

        /// <summary>
        /// Gets and sets value value of the denominator for the current fraction
        /// </summary>
        /// <returns>value of the denominator</returns>
        public int Denominator
        {
            get
            {
                return _denominator;
            }
            private set
            {
                _denominator = Math.Abs(value);
            }
        }

        /// <summary>
        /// Gets and sets value value of the sign for the current fraction
        /// </summary>
        /// <returns>value of the denominator</returns>
        public int Sign
        {
            get
            {
                return _sign;
            }
            private set
            {
                _sign = value;
            }
        }

        /// <summary>
        /// Gets and sets value value of the sign for the current fraction
        /// </summary>
        /// <returns>value of the denominator</returns>
        public FractionExceptions FractionExceptions
        {
            get
            {
                return _fractionExceptions;
            }
            private set
            {
                _fractionExceptions = value;
            }
        }

        #endregion

        /// <summary>
        /// Construct new SimpleFraction struct
        /// </summary>
        /// <param name="num">_numerator value</param>
        /// <param name="denom">denominator value</param>
        /// <param name="sign">represents the sign of the current fraction</param>
        public SimpleFraction(int num, int denom)
        {
            if (denom == 0)
            {
                _fractionExceptions  = FractionExceptions.DivisionByZero;
            }
            else
            {
                Sign = 1;
                if (num*denom < 0)
                {
                    Sign = -1;
                }
                Numerator = num;
                Denominator = denom;
            }
        }

        #region FractionOperators

        public static SimpleFraction operator /(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            return Divide(fractionA, fractionB);
        }
        public static SimpleFraction operator +(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            return Add(fractionA, fractionB);
        }
        public static SimpleFraction operator -(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            return Subtract(fractionA, fractionB);
        }
        public static SimpleFraction operator *(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            return Multiply(fractionA, fractionB);
        }

        #endregion

        #region FractionClassMethods
        /// <summary>
        /// Multiplies current instance of SimpleFraction
        /// </summary>
        /// <param name="multiplier"></param>
        public void MultiplyFraction(int multiplier)
        {
            int absMultoplier = Math.Abs(multiplier);
            if (multiplier < 0)
            {
                Sign *= -1;
            }
            Numerator *= absMultoplier;
        }
        
        /// <summary>
        /// Add new fraction to the current entity of simple fraction
        /// </summary>
        /// <param name="fractionN">fraction to be added to the current</param>
        public void Add(SimpleFraction fractionN)
        {
            int lcm_denominators = GetLeastCommonMultiple(Denominator, fractionN.Denominator);
            int increaseThis = lcm_denominators / Denominator;
            int increaseN = lcm_denominators / fractionN.Denominator;

            SimpleFraction multipliedFractionN = MultiplyFraction(fractionN, increaseN);

            Numerator = Sign * Numerator * increaseThis + multipliedFractionN.Sign * multipliedFractionN.Numerator;
            Denominator = lcm_denominators;
        }

        /// <summary>
        /// Subtract fraction from the current instance of simple fraction
        /// </summary>
        /// <param name="fractionN">fraction to be added to the current</param>
        public void Subtract(SimpleFraction fractionN)
        {
            SimpleFraction changedSignN = ChangeFractionSign(fractionN);
            this.Add(changedSignN);
        }

        /// <summary>
        /// Multiply current instance of fraction on another fraction
        /// </summary>
        /// <param name="fractionN"></param>
        public void Multiply(SimpleFraction fractionN)
        {
            Sign *= fractionN.Sign;
            Numerator *= fractionN.Numerator;
            Denominator *= fractionN.Denominator;
        }

        /// <summary>
        /// Multiply current instance of fraction on another fraction
        /// </summary>
        /// <param name="fractionN"></param>
        public void Divide(SimpleFraction fractionN)
        {
            Sign *= fractionN.Sign;
            Numerator *= fractionN.Denominator;
            Denominator *= fractionN.Numerator;
        }
        
        #endregion

        #region StaticFractionOperations

        /// <summary>
        /// Divide one fraction on another
        /// </summary>
        /// <param name="fractionA">first argument</param>
        /// <param name="fractionB">second argument</param>
        /// <returns>new instance of SimpleFraction type</returns>
        public static SimpleFraction Divide(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            int new_numerator = fractionA.Sign * fractionA.Numerator * fractionB.Denominator;
            int new_denominator = fractionA.Denominator * fractionB.Sign * fractionB.Numerator;
            return new SimpleFraction(new_numerator, new_denominator);
        }

        /// <summary>
        /// Multiply one fraction on another
        /// </summary>
        /// <param name="fractionA">first argument</param>
        /// <param name="fractionB">second argument</param>
        /// <returns>new instance of SimpleFraction type</returns>
        public static SimpleFraction Multiply(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            int new_numerator = fractionA.Sign * fractionA.Numerator * fractionB.Sign * fractionB.Numerator;
            int new_denominator = fractionA.Denominator * fractionB.Denominator;
            return new SimpleFraction(new_numerator, new_denominator);
        }

        /// <summary>
        /// Adds two simple fractions 
        /// </summary>
        /// <param name="fractionA">first argument</param>
        /// <param name="fractionB">second argument</param>
        /// <returns>new simple fraction</returns>
        public static SimpleFraction Subtract(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            SimpleFraction changedSignB = ChangeFractionSign(fractionB);
            return SimpleFraction.Add(fractionA, changedSignB);
        }

        /// <summary>
        /// Adds two simple fractions 
        /// </summary>
        /// <param name="fractionA">first argument</param>
        /// <param name="fractionB">second argument</param>
        /// <returns>new simple fraction</returns>
        public static SimpleFraction Add(SimpleFraction fractionA, SimpleFraction fractionB)
        {
            int lcm_denominators = GetLeastCommonMultiple(fractionA.Denominator, fractionB.Denominator);
            int increaseA = lcm_denominators / fractionA.Denominator;
            int increaseB = lcm_denominators / fractionB.Denominator;

            SimpleFraction multipliedFractionA = MultiplyFraction(fractionA, increaseA);
            SimpleFraction multipliedFractionB = MultiplyFraction(fractionB, increaseB);

            int new_numerator = multipliedFractionA.Sign * multipliedFractionA.Numerator + multipliedFractionB.Sign * multipliedFractionB.Numerator;
            int new_denominator = lcm_denominators;

            return new SimpleFraction(new_numerator, new_denominator);
        }

        /// <summary>
        /// Multiplies particular fraction on the value
        /// </summary>
        /// <param name="fraction">fraction to be multiplied</param>
        /// <param name="multiplier">multiplier value</param>
        /// <returns>returns new fraction</returns>
        public static SimpleFraction MultiplyFraction(SimpleFraction fraction, int multiplier)
        {
            int new_numerator = fraction.Sign * fraction.Numerator * multiplier;
            return new SimpleFraction(new_numerator, fraction.Denominator);
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
            int gcd = FindGreatestCommonDivisor(fraction.Numerator, fraction.Denominator);
            if (gcd != 1)
            {
                int new_numerator = fraction.Numerator / gcd;
                int new_denominator = fraction.Denominator / gcd;
                reducedFraction = new SimpleFraction(fraction.Sign * new_numerator, new_denominator);
                wasReduced = true;
            }
            return wasReduced;
        }
        
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Calculates greatest common divisor of two numbers
        /// </summary>
        /// <param name="numberA">first number</param>
        /// <param name="numberB">second number</param>
        /// <returns></returns>
        private static int FindGreatestCommonDivisor(int numberA, int numberB)
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
        private static int GetLeastCommonMultiple(int numberA, int numberB)
        {
            int absA = Math.Abs(numberA);
            int absB = Math.Abs(numberB);
            int gcdAb = FindGreatestCommonDivisor(absA, absB);
            return absA * absB / gcdAb;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ChangeFractionSign()
        {
            Sign *= (-1);
        }

        public static SimpleFraction ChangeFractionSign(SimpleFraction currentFraction)
        {
            return new SimpleFraction(currentFraction.Numerator * currentFraction.Sign * (-1), currentFraction.Denominator);
        }

        #endregion
    }
}