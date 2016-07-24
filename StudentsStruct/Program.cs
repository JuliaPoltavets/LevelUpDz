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
            StudentsStruct.UniversityEntities.StudentsGroup group101 = default(UniversityEntities.StudentsGroup);
            Random mark = new Random();
            for (int i = 0; i < 5; i++)
            {
                StudentsStruct.UniversityEntities.Student st = new UniversityEntities.Student((short) i, "Name" + i,
                    "Last" + i);
                group101.AddStudent(st);

            }
            foreach (var st in group101.GroupList)
            {
                for (int i = 0; i < Enum.GetNames(typeof(UniversityEntities.Subjects)).Length; i++)
                {
                    st.TrySetNewMark((UniversityEntities.Subjects)i, mark.Next(1, 12));
                }
            }
            foreach (var st in group101.GroupList)
            {
                Console.WriteLine(st.StudentId +": "+st.AverageGrade);
            }
            Console.ReadLine();
        }
    }
}
