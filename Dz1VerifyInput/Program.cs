namespace Dz1VerifyInput
{
    using System;

    public enum DeniedDecimalAsciiKeys
    {
        Dash = 45,
        Comma = 44
    }

    [Flags]
    public enum ProgramMode
    {
        Integer = 0x1,
        Real = 0x2
    }

    public struct InputRanges
    {
        public const int MaxIntegerValue = int.MaxValue;
        public const int MinIntegerValue = int.MinValue;
        public const double MaxDoubleValue = 10.100500;
        public const double MinDoubleValue = -10.100500;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Enum availableModes = ProgramMode.Integer | ProgramMode.Real;
            ProgramMode currentMode;
            bool modeSelected;
            bool inputIsSuccessfull = false;

            do
            {
                Console.WriteLine("Please select input mode. Available options are: " + availableModes);
                string modeName = Console.ReadLine();
                modeSelected = Enum.TryParse(modeName, out currentMode);
            } while (!modeSelected);

            switch (currentMode)
            {
                case ProgramMode.Integer:
                    Console.WriteLine("Integer mode restrictions are " +"("+InputRanges.MinIntegerValue+";" + InputRanges.MaxIntegerValue+")");
                    while (!inputIsSuccessfull)
                    {
                        ConsoleKey lastPressedKey;
                        var inputString = CollectStringToParse(out lastPressedKey);
                        if (lastPressedKey == ConsoleKey.Escape)
                        {
                            break;
                        }
                        if (!IsInputStringValid(inputString))
                        {
                            ConsoleMessageForInvalidInput(inputString);
                            continue;
                        }
                        int integerValue;
                        if (!int.TryParse(inputString, out integerValue))
                        {
                            Console.WriteLine("Input value is not a valid Integer");
                            continue;
                        }
                        if (!BelongsToIntegerRange(integerValue))
                        {
                            Console.WriteLine("Input value is out of expected range");

                        }
                        else
                        {
                            inputIsSuccessfull = true;
                            Console.WriteLine("Congratulations! You managed to enter correct value: " + integerValue);
                        }
                    } 
                    break;
                case ProgramMode.Real:
                    Console.WriteLine("Real mode restrictions are " +"("+InputRanges.MinDoubleValue+";" + InputRanges.MaxDoubleValue+")");
                    while (!inputIsSuccessfull)
                    {
                        ConsoleKey lastPressedKey;
                        var inputString = CollectStringToParse(out lastPressedKey);
                        if (lastPressedKey == ConsoleKey.Escape)
                        {
                            break;
                        }
                        if (!IsInputStringValid(inputString))
                        {
                            ConsoleMessageForInvalidInput(inputString);
                            continue;
                        }
                        double doubleValue;
                        if (!double.TryParse(inputString, out doubleValue))
                        {
                            Console.WriteLine("Input value is not a valid Real");
                            continue;
                        }
                        if (!BelongsToRealRange(doubleValue))
                        {
                            Console.WriteLine("Input value is out of expected range");
                        }
                        else
                        {
                            inputIsSuccessfull = true;
                            Console.WriteLine("Congratulations! You managed to enter correct value: " + doubleValue);
                        }
                    } 
                    break;
                default:
                    throw new NotImplementedException("ProgramMode enum was extended with new value, but handler is not available for it");
            }
        }

        public static string CollectStringToParse(out ConsoleKey lastConsoleKey)
        {
            Console.WriteLine("Please enter the value: ");
            ConsoleKeyInfo consoleKeyInfo;
            string inputString = string.Empty;
            do
            {
                consoleKeyInfo = Console.ReadKey();
                if (Enum.IsDefined(typeof (DeniedDecimalAsciiKeys), (int) consoleKeyInfo.KeyChar))
                {
                    Console.Beep();
                }
                if ((consoleKeyInfo.Key != ConsoleKey.Escape) && (consoleKeyInfo.Key != ConsoleKey.Enter))
                {
                    inputString += consoleKeyInfo.KeyChar;
                }

            } while ((consoleKeyInfo.Key != ConsoleKey.Escape) && (consoleKeyInfo.Key != ConsoleKey.Enter));
            lastConsoleKey = consoleKeyInfo.Key;
            return consoleKeyInfo.Key == ConsoleKey.Escape ? string.Empty : inputString;
        }

        public static bool BelongsToIntegerRange(int value)
        {
            return (value < InputRanges.MaxIntegerValue)
                   && (value > InputRanges.MinIntegerValue);
        }

        public static bool BelongsToRealRange(double value)
        {
            return (value < InputRanges.MaxDoubleValue)
                   && (value > InputRanges.MinDoubleValue);
        }

        public static bool IsInputStringValid(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return false;
            }
            for (int i = 0; i < inputString.Length; i++)
            {
                if (Enum.IsDefined(typeof (DeniedDecimalAsciiKeys), (int)inputString[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static void ConsoleMessageForInvalidInput(string inputString)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (string.IsNullOrEmpty(inputString))
            {
                Console.WriteLine("Empty string is not a valid value");
                return;
            }
            Console.WriteLine("Your input number contains symbols that not allowed: ");
            for (int i = 0; i < inputString.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (Enum.IsDefined(typeof (DeniedDecimalAsciiKeys), (int)inputString[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(inputString[i]);
            }
            Console.WriteLine();
        }

    }
}
