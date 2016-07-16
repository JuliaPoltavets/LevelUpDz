using System;
using ArraysProject.BusinessLayer;

namespace ArraysProject.PresentationLayer
{
    public class TemperatureCalendarProgram
    {
        public static void RunTemperatureCalendar()
        {
            DateTime currentDate = DateTime.UtcNow;
            bool leapYear;
            int[][] temperatureCalendar = null;
            int year = GetYear(out leapYear);

            TemperatureCalendar.Month month = GetMonth();
            int daysCount = TemperatureCalendar.GetDays(month, leapYear);

            if (currentDate.Year == year && currentDate.Month == (int)month)
            {
                bool isCopy;
                string inputData;
                temperatureCalendar = TemperatureCalendar.GenerateTemperatureCalendar(daysCount, 10, -10, 10, currentDate.Day);
                PrintArray.PrintJaggedArray(temperatureCalendar);
                AddOrCopy(out inputData, out isCopy);
                if (!isCopy)
                {
                    TemperatureCalendar.AddNewMeasurementToTheDay(temperatureCalendar, currentDate.Day-1, inputData);
                    PrintArray.PrintJaggedArray(temperatureCalendar);
                }
                else
                {
                    TemperatureCalendar.CopyMeasurementFromAnotherDay(temperatureCalendar, int.Parse(inputData), currentDate.Day - 1);
                    PrintArray.PrintJaggedArray(temperatureCalendar);
                }
            }
            else
            { 
                temperatureCalendar = TemperatureCalendar.GenerateTemperatureCalendar(daysCount, 10, -10, 10);
                PrintArray.PrintJaggedArray(temperatureCalendar);
            }

        }


        #region Private
        private static int GetYear(out bool leapYear)
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

            if (year%4 == 0)
            {
                leapYear = true;
            }
            return year;
        }

        private static TemperatureCalendar.Month GetMonth()
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

        private static void AddOrCopy(out string inputData, out bool isCopy)
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

        #endregion
    }
}