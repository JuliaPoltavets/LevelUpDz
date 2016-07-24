using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace StudentsStruct
{
    public class UniversityEntities
    {
        public enum Subjects
        {
            Math = 0,
            Geography = 1,
            Physics,
            Art,
            Politology
        }

        public struct Student
        {
            private readonly int[][] _studentMarks;

            public short StudentId { get; private set; }

            public string StudentFirstName { get; private set; }

            public string StudentLastName { get; private set; }

            public double AverageGrade => GetAverageGrade();

            public Student(short studentId, string studentFirstName, string studentLastName)
            {
                var subjectsCount = Enum.GetNames(typeof(Subjects)).Length;
                StudentId = studentId;
                StudentFirstName = studentFirstName;
                StudentLastName = studentLastName;
                _studentMarks = new int[subjectsCount][];
            }

            public bool ChangeFirstName(string newFirstName)
            {
                bool wasSuccessfullyChanged = false;
                if (!string.IsNullOrEmpty(newFirstName))
                {
                    this.StudentFirstName = newFirstName;
                    wasSuccessfullyChanged = true;
                }
                return wasSuccessfullyChanged;
            }

            public bool ChangeLastName(string newLastName)
            {
                bool wasSuccessfullyChanged = false;
                if (!string.IsNullOrEmpty(newLastName))
                {
                    this.StudentLastName = newLastName;
                    wasSuccessfullyChanged = true;
                }
                return wasSuccessfullyChanged;
            }

            public void TrySetNewMark(Subjects subject, int mark)
            {
                int[] actualMarksForSubject = _studentMarks[(int)subject];
                if (actualMarksForSubject == null)
                {
                    _studentMarks[(int) subject] = new[] {mark};
                }
                else
                {
                    int[] updatedMarks = new int[actualMarksForSubject.Length + 1];
                    Array.Copy(actualMarksForSubject, 0, updatedMarks, 0, actualMarksForSubject.Length);
                    updatedMarks[updatedMarks.Length - 1] = mark;
                    _studentMarks[(int) subject] = updatedMarks;
                }
            }

            public void TryChangeMarkByIndex(Subjects subject,int markToChange, int newMarkValue)
            {
                int[] actualMarksForSubject = _studentMarks[(int)subject];
                if (actualMarksForSubject == null)
                {
                    _studentMarks[(int)subject] = new[] { newMarkValue };
                }
                else
                {
                    _studentMarks[(int)subject][markToChange] = newMarkValue;
                }
            }

            public void ReplaceMarks(Subjects subject, int[] marks)
            {
                _studentMarks[(int)subject] = marks;
            }

            public double AverageGradeForSubject(Subjects subject)
            {
                if (_studentMarks[(int) subject] != null)
                {
                    return _studentMarks[(int) subject].Average();
                }
                return 0;
            }

            public double GetAverageGrade()
            {
                var subjectsCount = Enum.GetNames(typeof(Subjects)).Length;
                double[] tempAvgMarks = new double[subjectsCount];
                for (int i = 0; i < subjectsCount; i++)
                {
                    tempAvgMarks[i] = AverageGradeForSubject((Subjects)i);
                }
                return tempAvgMarks.Average();
            }

            public int[] GetMarksBySubject(Subjects subject)
            {
                if (_studentMarks[(int)subject] != null)
                {
                    return _studentMarks[(int)subject];
                }
                return null;
            }
        }

        public struct StudentsGroup
        {
            private short _groupId;
            private Student[] _students;
            public StudentsGroup(short groupId)
            {
                _groupId = groupId;
                _students = null;
            }

            public Student[] GroupList => _students;

            public void AddStudent(Student student)
            {
                if (_students == null)
                {
                    _students = new[] { student };
                }
                else
                {
                    Student[] updatedGroup = new Student[_students.Length + 1];
                    Array.Copy(_students, 0, updatedGroup, 0, _students.Length);
                    updatedGroup[updatedGroup.Length - 1] = student;
                    _students = updatedGroup;
                }
            }

            public bool UpdateStudentPersonalData(short studentId, string firstName, string lastName)
            {
                bool wasSuccessfullyChanged = false;
                int stIndex;
                if (TryGetStudentIndexById(studentId, out stIndex))
                {
                    _students[stIndex].ChangeFirstName(firstName);
                    _students[stIndex].ChangeLastName(lastName);
                    wasSuccessfullyChanged = true;
                }
                return wasSuccessfullyChanged;
            }

            public bool DeleteStudentFromGroup(short studentId)
            {
                bool wasSuccessfullyDeleted = false;
                int stIndex;
                if (TryGetStudentIndexById(studentId, out stIndex))
                {
                    if ((_students.Length - 1) > 0)
                    {
                        Student[] updatedGroup = new Student[_students.Length - 1];
                        Array.Copy(_students, 0, updatedGroup, 0, stIndex);
                        Array.Copy(_students, stIndex + 1, updatedGroup, stIndex, (_students.Length - 1) - stIndex);
                        _students = updatedGroup;
                    }
                    else
                    {
                        _students = null;
                    }
                    wasSuccessfullyDeleted = true;
                }
                return wasSuccessfullyDeleted;
            }

            public bool TryGetAverageStudentGrade(short studentId, out double avgGrade)
            {
                int stIndex;
                avgGrade = double.NegativeInfinity;
                if (TryGetStudentIndexById(studentId, out stIndex))
                {
                    avgGrade = _students[stIndex].AverageGrade;
                    return true;
                }
                return false;
            }

            public Student GetStudentWithHighestAvgGrade()
            {
                Student[] tempGroup = _students.OrderByDescending(st => st.AverageGrade).ToArray();
                return tempGroup.FirstOrDefault();
            }

            public Student GetStudentWithLowestAvgGrade()
            {
                Student[] tempGroup = _students.OrderByDescending(st => st.AverageGrade).ToArray();
                return tempGroup.LastOrDefault();
            }

            private bool TryGetStudentIndexById(short studentId, out int studentIndex)
            {
                bool studentWasFound = false;
                studentIndex = int.MinValue;
                for (int i = 0; i < _students.Length; i++)
                {
                    if (_students[i].StudentId == studentId)
                    {
                        studentIndex = i;
                        studentWasFound = true;
                    }
                }
                return studentWasFound;
            }
        }
    }
}