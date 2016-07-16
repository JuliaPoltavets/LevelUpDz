using System;
using ArraysProject.BusinessLayer;

namespace ArraysProject.PresentationLayer
{
    public class ConsoleTemperatureUi
    {
        #region Private
        public static int GetYear(out bool leapYear)
        {
            string inputString = string.Empty;
            leapYear = false;
            bool isValidInt;
            int year = 0;
            do
            {
                Console.WriteLine("Please enter the year");
                inputString = Console.ReadLine();
                isValidInt = int.TryParse(inputString, out year);
            } while (inputString.Length != 4 || !isValidInt);

            if (year % 4 == 0)
            {
                leapYear = true;
            }
            return year;
        }

        public static TemperatureCalendar.Month GetMonth()
        {
            string inputString = string.Empty;
            TemperatureCalendar.Month month;
            bool isValidMonth = false;
            do
            {
                Console.WriteLine("Please enter the month: ");
                inputString = Console.ReadLine();
                isValidMonth = Enum.TryParse(inputString, true, out month);

            } while (isValidMonth == false);

            return month;
        }

        public static void SetManuallyOrCopy(out string inputData, out bool isCopy)
        {
            inputData = string.Empty;
            isCopy = false;
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Select an option: press A - add new measurements for today; press C - copy from particular day");
                consoleKeyInfo = Console.ReadKey();
                Console.WriteLine();
            } while ((consoleKeyInfo.Key != ConsoleKey.A) && (consoleKeyInfo.Key != ConsoleKey.C));
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.A:
                    {
                        Console.WriteLine("Please add temperature values separated by coma");
                        inputData = Console.ReadLine();
                        isCopy = false;
                        break;
                    }
                case ConsoleKey.C:
                    {
                        Console.WriteLine("Please specify day to make a copy");
                        inputData = Console.ReadLine();
                        isCopy = true;
                        break;
                    }
            }
        }

        public static int GetIntFromConsole(string message)
        {
            int result;
            string inputData;
            do
            {
                Console.WriteLine(message);
                inputData = Console.ReadLine();

            } while (!int.TryParse(inputData, out result));
            return result;
        }

        public static string GetStringFromConsole(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static void PrintStringOnConsole(string message)
        {
            Console.WriteLine(message);
        }

        #endregion
    }
}