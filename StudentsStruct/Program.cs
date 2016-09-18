using System;
using System.Reflection;
using StudentsStruct.UniversityModel;

namespace StudentsStruct
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Random group
            StudentsGroup group = GenerateDemoGroupOfStudents(0, 2, 2, 8);
            ConsoleStudentGroup.PrintStudentsGroup(group);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            // new student
            int newStIndex = group.Students.Length;
            Student student = new Student((short) newStIndex, "FirstName" + newStIndex, "LastName" + newStIndex);
            // Add mark to subject 
            student.AddNewMarkToStudentProgress(Subjects.Art, 10);
            // Add mark to subject 
            student.AddNewMarkToStudentProgress(Subjects.Art, 2);
            // Add array of marks to subject
            student.ReplaceJornalInStudentProgress(Subjects.Geography, new byte[] {10, 10, 10});
            //Replace whole array of marks for subject
            student.ReplaceJornalInStudentProgress(Subjects.Art, new byte[] {5, 5, 5, 5, 5, 5});
            //Change student's personal info
            student.ChangeFirstName("NewFirstName");
            student.ChangeLastName("NewLastName");
            //Add new student
            group.AddStudent(student);
            //Delete student by studentId
            group.DeleteStudentFromGroup(0);
            //Best student
            Student bestStudent = group.GetStudentWithHighestAvgGrade();
            //Worst student
            Student worstStudent = group.GetStudentWithLowestAvgGrade();
            // AverageGrade by student's Id
            double avgStudentGrade;
            group.TryGetAverageStudentGrade(bestStudent.StudentId, out avgStudentGrade);

            ConsoleStudentGroup.PrintStudentsGroup(group);

            Console.ReadLine();
        }

        #region DemoData

        static StudentsGroup GenerateDemoGroupOfStudents(short groupId, int studentsCount, int minMarksCount,
            int maxMarksCount)
        {
            Random rnd = new Random();
            StudentsGroup group = new StudentsGroup(groupId);
            for (int i = 0; i < studentsCount; i++)
            {
                Student student = new Student((short) i, "FirstName" + i, "LastName" + i);
                for (int j = 0; j < Enum.GetNames(typeof(Subjects)).Length; j++)
                {
                    byte[] marksArray = new byte[rnd.Next(minMarksCount, maxMarksCount)];
                    for (int k = 0; k < marksArray.Length; k++)
                    {
                        marksArray[k] = (byte) rnd.Next(1, 12);
                    }
                    student.ReplaceJornalInStudentProgress((Subjects) j, marksArray);
                }
                group.AddStudent(student);
            }

            return group;
        }

        #endregion
    }
}