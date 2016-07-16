using System;
using ArraysProject.BusinessLayer;
using ArraysProject.PresentationLayer;

namespace ArraysProject
{
    public class TemperatureCalendarProgram
    {
        public static void RunTemperatureCalendar()
        {
            DateTime currentDate = DateTime.UtcNow;
            bool leapYear;
            int[][] temperatureCalendar = null;
            int year = ConsoleTemperatureUi.GetYear(out leapYear);

            TemperatureCalendar.Month month = ConsoleTemperatureUi.GetMonth();
            int daysCount = TemperatureCalendar.GetDays(month, leapYear);

            if (currentDate.Year == year && currentDate.Month == (int)month)
            {
                bool isCopy;
                string inputData;
                temperatureCalendar = TemperatureCalendar.GenerateTemperatureCalendar(daysCount, 10, -10, 10, currentDate.Day);
                ConsoleTemperatureUi.SetManuallyOrCopy(out inputData, out isCopy);
                if (!isCopy)
                {
                    TemperatureCalendar.AddNewMeasurementToTheDay(temperatureCalendar, currentDate.Day - 1, inputData);
                }
                else
                {
                    TemperatureCalendar.CopyMeasurementFromAnotherDay(temperatureCalendar, int.Parse(inputData), currentDate.Day - 1);
                }
            }
            else
            {
                temperatureCalendar = TemperatureCalendar.GenerateTemperatureCalendar(daysCount, 10, -10, 10);
            }
            PrintArray.PrintJaggedArray(temperatureCalendar);

            // change particular date measurements
            int dateToEdit = ConsoleTemperatureUi.GetIntFromConsole("Please select date to edit ");
            string newMeasurement = ConsoleTemperatureUi.GetStringFromConsole("Please add new temperature values separated by coma ");
            TemperatureCalendar.AddNewMeasurementToTheDay(temperatureCalendar, dateToEdit, newMeasurement);
            PrintArray.PrintJaggedArray(temperatureCalendar);

            //Average temperature for day 
            int focusDate = ConsoleTemperatureUi.GetIntFromConsole("Please select date to calculate average temperature ");
            double avgDateTemp = TemperatureCalendar.GetAverageTemperatureForDay(temperatureCalendar, focusDate);
            ConsoleTemperatureUi.PrintStringOnConsole("Average temperature for date " + focusDate +" equals to " + avgDateTemp);

            // Average temperature for month
            double avgMonthTemp = TemperatureCalendar.GetAverageTemperatureForMonth(temperatureCalendar);
            ConsoleTemperatureUi.PrintStringOnConsole("Average temperature for month " + month + " equals to " + avgMonthTemp);
            Console.ReadLine();
        }
    }
}