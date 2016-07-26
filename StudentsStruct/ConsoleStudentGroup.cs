using System;
using System.Reflection;

namespace StudentsStruct
{
    public class ConsoleStudentGroup
    {
        public static bool TryReadStudentId(out short? studentId)
        {
            short result;
            Console.WriteLine("Please enter student's Id");
            if (short.TryParse(Console.ReadLine(), out result))
            {
                studentId = result;
                return true;
            }
            studentId = null;
            return false;
        }

        public static bool TryReadStudentStringPersonalData(string consoleMessage, out string stringData)
        {
            Console.WriteLine(consoleMessage);
            string consoleInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(consoleInput))
            {
                stringData = consoleInput;
                return true;
            }
            stringData = null;
            return false;
        }

        public static bool TryReadIntArray(string consoleMessage, char[] allowedSeparators, out int[] intArrayData)
        {
            intArrayData = null;
            Console.WriteLine(consoleMessage);
            string[] consoleInput = Console.ReadLine().Split(allowedSeparators);
            int[] tempArray = new int[consoleInput.Length];
            int actualIntsInParsedString = 0;
            for (int i = 0; i < consoleInput.Length; i++)
            {
                int arrayElement;
                if (int.TryParse(consoleInput[i], out arrayElement))
                {
                    tempArray[actualIntsInParsedString] = arrayElement;
                    actualIntsInParsedString++;
                }
            }
            if (actualIntsInParsedString == 0)
            {
                return false;
            }
            intArrayData = new int[actualIntsInParsedString];
            Array.Copy(tempArray, 0, intArrayData, 0, actualIntsInParsedString);
            return true;
        }

        public static UniversityEntities.Subjects GetSubject()
        {
            string inputString = string.Empty;
            UniversityEntities.Subjects subject;
            bool isValidSubject = false;
            do
            {
                Console.WriteLine("Please enter the subject title: ");
                inputString = Console.ReadLine();
                isValidSubject = Enum.TryParse(inputString, true, out subject);

            } while (isValidSubject == false);

            return subject;
        }

        public static void PrintStudentsGroup(UniversityEntities.StudentsGroup group)
        {
            foreach (var student in group.GroupList)
            {
                PrintStudentData(student);
            }
        }

        public static void PrintStudentData(UniversityEntities.Student student)
        {
            Console.WriteLine("Student {0}: {1} {2}", student.StudentId, student.StudentFirstName, student.StudentLastName);
            for (int i = 0; i < Enum.GetNames(typeof(UniversityEntities.Subjects)).Length; i++)
            {
                UniversityEntities.Subjects sbj = (UniversityEntities.Subjects)i;
                byte[] marksForSbj = student.GetMarksBySubject(sbj);
                if (marksForSbj != null)
                {
                    Console.WriteLine(sbj + ": " + string.Join(", ", marksForSbj));
                    Console.WriteLine("Average grade for subject {0}: equals to: {1}", sbj, student.AverageGradeForSubject(sbj));
                }
            }
            Console.WriteLine("Average grade for student {0}: equals to: {1}", student.StudentId, student.AverageGrade);
        }

    }
}