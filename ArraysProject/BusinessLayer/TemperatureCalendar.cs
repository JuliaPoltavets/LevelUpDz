using System;

namespace ArraysProject.BusinessLayer
{
    public class TemperatureCalendar
    {
        public enum Month
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        public static int GetDays(Month month, bool leapYear)
        {
            if ((month == Month.April) ||
                (month == Month.June) ||
                (month == Month.September) ||
                (month == Month.November))
            {
                return 30;
            }
            if (month == Month.February && leapYear)
            {
                return 29;
            }
            if (month == Month.February && !leapYear)
            {
                return 28;
            }
            return 31;
        }

        public static int[][] GenerateTemperatureCalendar(int daysInMonth, int maxMeasurementCount, int minMonthTemperature, int maxMonthTemperature, int currentDate = 0)
        {
            int[][] tempCalendar = new int[daysInMonth][];

            if (currentDate == 0)
            {
                JaggedArrays.InitNElementsWithRndLength(tempCalendar, daysInMonth, 1, maxMeasurementCount);
                JaggedArrays.SetRndValuesForNSubArrays(tempCalendar, daysInMonth, minMonthTemperature, maxMonthTemperature);
            }
            else
            {
                JaggedArrays.InitNElementsWithRndLength(tempCalendar, currentDate-1, 1, maxMeasurementCount);
                JaggedArrays.SetRndValuesForNSubArrays(tempCalendar, currentDate-1, minMonthTemperature, maxMonthTemperature);
            }

            return tempCalendar;
        }

    }
}