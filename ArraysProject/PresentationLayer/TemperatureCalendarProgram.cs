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
                temperatureCalendar = TemperatureCalendar.GenerateTemperatureCalendar(daysCount, 10, -10, 10, currentDate.Day);
                PrintArray.PrintJaggedArray(temperatureCalendar);
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

        #endregion
    }
}