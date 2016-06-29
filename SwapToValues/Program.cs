using System.Runtime.CompilerServices;

namespace SwapToValues
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            // using ref keyword and buffer
            int valueRef1 = 5;
            int valueRef2 = 10;

            Console.WriteLine("First value: " + valueRef1 + " Second value: " + valueRef2);
            Console.WriteLine("Swap values!");
            SwapTempRef(ref valueRef1, ref valueRef2);
            Console.WriteLine("First value: " + valueRef1 + " Second value: " + valueRef2);

            Console.WriteLine(@"\---------Second option-------\");

            //using class and build-in method
            TwoDigits digitsPair = new TwoDigits(9,10);
            Console.WriteLine("First value: " + digitsPair.Digit1 + " Second value: " + digitsPair.Digit2);
            Console.WriteLine("Swap values!");
            digitsPair.Swap();
            Console.WriteLine("First value: " + digitsPair.Digit1 + " Second value: " + digitsPair.Digit2);

            Console.WriteLine(@"\---------Third option-------\");
            
            // using XOR algorithm
            int valueToSwap1 = 10;
            int valueToSwap2 = 4;
            Console.WriteLine("First value: " + valueToSwap1 + " Second value: " + valueToSwap2);
            Console.WriteLine("Swap values!");
            SwapXorRef(ref valueToSwap1,ref valueToSwap2);
            Console.WriteLine("First value: " + valueToSwap1 + " Second value: " + valueToSwap2);

            Console.WriteLine(@"\---------Fourth option-------\");

            // using Sum algorithm
            int valueSwap1 = 10;
            int valueSwap2 = 4;
            Console.WriteLine("First value: " + valueSwap1 + " Second value: " + valueSwap2);
            Console.WriteLine("Swap values!");
            SwapSumRef(ref valueSwap1, ref valueSwap2);
            Console.WriteLine("First value: " + valueSwap1 + " Second value: " + valueSwap2);


            Console.ReadLine();

        }

        private static void SwapSumRef(ref int valueSwap1, ref int valueSwap2)
        {
            valueSwap1 = valueSwap1 + valueSwap2;
            valueSwap2 = valueSwap1 - valueSwap2;
            valueSwap1 = valueSwap1 - valueSwap2;
        }

        private static void SwapXorRef(ref int value1, ref int value2)
        {
            value1 = value1 ^ value2;
            value2 = value2 ^ value1;
            value1 = value1 ^ value2;
        }

        private static void SwapTempRef(ref int value1, ref int value2)
        {
            int temp = value1;
            value1 = value2;
            value2 = temp;
        }
    }

    public class TwoDigits
    {
        public int Digit1 { get; private set; }
        public int Digit2 { get; private set; }

        public TwoDigits(int value1, int value2)
        {
            Digit1 = value1;
            Digit2 = value2;
        }

        public void Swap()
        {
            int temp = this.Digit1;
            this.Digit1 = this.Digit2;
            this.Digit2 = temp;
        }
    }
}
