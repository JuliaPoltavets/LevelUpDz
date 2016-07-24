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
            
        }

        static UniversityEntities.StudentsGroup GenerateDemoGroupOfStudents(short groupId, int studentsCount, int minMarksCount, int maxMarksCount)
        {
            Random rnd = new Random();
            UniversityEntities.StudentsGroup group = new UniversityEntities.StudentsGroup(groupId);
            for (int i = 0; i < studentsCount; i++)
            {
                UniversityEntities.Student student = new UniversityEntities.Student((short)i, "FirstName"+i, "LastName"+i);
                for (int j = 0; j < Enum.GetNames(typeof(UniversityEntities.Subjects)).Length; j++)
                {
                    int[] marksArray = new int[rnd.Next(minMarksCount, maxMarksCount)];
                    for (int k = 0; k < marksArray.Length; k++)
                    {
                        marksArray[k] = rnd.Next(1, 12);
                    }
                    student.ReplaceMarks((UniversityEntities.Subjects)j, marksArray);
                }
                group.AddStudent(student);
            }

            return group;
        }
    }
}
