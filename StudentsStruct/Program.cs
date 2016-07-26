using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random group
            UniversityEntities.StudentsGroup group = GenerateDemoGroupOfStudents(0, 2, 2, 8);
            ConsoleStudentGroup.PrintStudentsGroup(group);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            // Add new student
            int newStIndex = group.GroupList.Length;
            UniversityEntities.Student student = new UniversityEntities.Student((short)newStIndex, "FirstName" + newStIndex, "LastName" + newStIndex);
            group.AddStudent(student);
            // Add mark to subject 
            student.AddNewMarkToStudentProgress(UniversityEntities.Subjects.Art, 10);
            // Add mark to subject 
            student.AddNewMarkToStudentProgress(UniversityEntities.Subjects.Art, 2);
            // Add array of marks to subject
            student.ReplaceJornalInStudentProgress(UniversityEntities.Subjects.Geography, new byte[] { 10, 10, 10 });
            //Replace whole array of marks for subject
            student.ReplaceJornalInStudentProgress(UniversityEntities.Subjects.Art, new byte[] { 5, 5, 5, 5, 5, 5 });
            //Change student's personal info
            student.ChangeFirstName("NewFirstName");
            student.ChangeLastName("NewLastName");
            //Delete student by studentId
            group.DeleteStudentFromGroup(0);
            //Best student
            UniversityEntities.Student bestStudent = group.GetStudentWithHighestAvgGrade();
            //Worst student
            UniversityEntities.Student worstStudent = group.GetStudentWithLowestAvgGrade();
            // AverageGrade by student's Id
            double avgStudentGrade;
            group.TryGetAverageStudentGrade(bestStudent.StudentId, out avgStudentGrade);

            ConsoleStudentGroup.PrintStudentsGroup(group);
            Console.ReadLine();
        }

        #region DemoData
        static UniversityEntities.StudentsGroup GenerateDemoGroupOfStudents(short groupId, int studentsCount, int minMarksCount, int maxMarksCount)
        {
            Random rnd = new Random();
            UniversityEntities.StudentsGroup group = new UniversityEntities.StudentsGroup(groupId);
            for (int i = 0; i < studentsCount; i++)
            {
                UniversityEntities.Student student = new UniversityEntities.Student((short)i, "FirstName" + i, "LastName" + i);
                for (int j = 0; j < Enum.GetNames(typeof(UniversityEntities.Subjects)).Length; j++)
                {
                    byte[] marksArray = new byte[rnd.Next(minMarksCount, maxMarksCount)];
                    for (int k = 0; k < marksArray.Length; k++)
                    {
                        marksArray[k] = (byte)rnd.Next(1, 12);
                    }
                    student.ReplaceJornalInStudentProgress((UniversityEntities.Subjects)j, marksArray);
                }
                group.AddStudent(student);
            }

            return group;
        }
        #endregion
    }
}
