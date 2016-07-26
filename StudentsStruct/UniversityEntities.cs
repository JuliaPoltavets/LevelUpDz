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

        public struct SubjectJornal
        {
            public Subjects SubjectName { get; private set; }
            public byte[] MarkList { get; private set; }

            public SubjectJornal(Subjects subjectName, byte[] marksList)
            {
                SubjectName = subjectName;
                MarkList = marksList;
            }

            public void AddMark(byte mark)
            {
                if (MarkList == null)
                {
                    MarkList = new[] { mark };
                }
                else
                {
                    byte[] updatedGroup = new byte[MarkList.Length + 1];
                    Array.Copy(MarkList, 0, updatedGroup, 0, MarkList.Length);
                    updatedGroup[updatedGroup.Length - 1] = mark;
                    MarkList = updatedGroup;
                }
            }

            public double GetAverageGrade()
            {
                int totalScore = 0;
                double avgResult = 0;
                if (MarkList != null)
                {
                    foreach (byte mark in MarkList)
                    {
                        totalScore += mark;
                    }
                    avgResult = totalScore / MarkList.Length;
                }
                return avgResult;
            }
        }

        public struct Student
        {
            private SubjectJornal[] _studentProgress;

            public short StudentId { get; private set; }

            public string StudentFirstName { get; private set; }

            public string StudentLastName { get; private set; }

            public double AverageGrade
            {
                get
                {
                    return GetStudentAverageGrade();
                }
            }

            public Student(short studentId, string studentFirstName, string studentLastName)
            {
                var subjectsCount = Enum.GetNames(typeof(Subjects)).Length;
                StudentId = studentId;
                StudentFirstName = studentFirstName;
                StudentLastName = studentLastName;
                _studentProgress = new SubjectJornal[0];
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

            public bool TryGetJornalIndexBySubject(Subjects subjectName, out int? jornalIndex)
            {
                bool isSucceeded = false;
                jornalIndex = null;
                for (int index = 0; index < _studentProgress.Length; index++)
                {
                    SubjectJornal jornal = _studentProgress[index];
                    if (jornal.SubjectName == subjectName)
                    {
                        isSucceeded = true;
                        jornalIndex = index;
                    }
                }
                return isSucceeded;
            }

            public void AddNewMarkToStudentProgress(Subjects subject, byte mark)
            {
                int? actualJornalIndex;
                if (!TryGetJornalIndexBySubject(subject, out actualJornalIndex))
                {
                    SubjectJornal[] updatedStudentProgress = new SubjectJornal[_studentProgress.Length + 1];
                    Array.Copy(_studentProgress, 0, updatedStudentProgress, 0, _studentProgress.Length);
                    updatedStudentProgress[updatedStudentProgress.Length - 1] = new SubjectJornal(subject, new[] { mark });
                    _studentProgress = updatedStudentProgress;
                }
                else
                {
                    _studentProgress[actualJornalIndex.Value].AddMark(mark);
                }
            }

            public void ReplaceJornalInStudentProgress(Subjects subject, byte[] marksList)
            {
                int? actualJornalIndex;
                SubjectJornal newJornal = new SubjectJornal(subject, marksList);
                if (!TryGetJornalIndexBySubject(subject, out actualJornalIndex))
                {
                    SubjectJornal[] updatedStudentProgress = new SubjectJornal[_studentProgress.Length + 1];
                    Array.Copy(_studentProgress, 0, updatedStudentProgress, 0, _studentProgress.Length);
                    updatedStudentProgress[updatedStudentProgress.Length - 1] = newJornal;
                    _studentProgress = updatedStudentProgress;
                }
                else
                {
                    _studentProgress[actualJornalIndex.Value] = newJornal;
                }
            }

            public void ChangeMarkByIndex(Subjects subject, int markIndexToChange, byte newMarkValue)
            {
                int? actualJornalIndex;
                if (!TryGetJornalIndexBySubject(subject, out actualJornalIndex))
                {
                    _studentProgress = new SubjectJornal[]
                    {
                        new SubjectJornal(subject, new []{ newMarkValue } )
                    };
                }
                if (_studentProgress[actualJornalIndex.Value].MarkList.Length - 1 < markIndexToChange)
                {
                    markIndexToChange = _studentProgress[actualJornalIndex.Value].MarkList.Length - 1;
                }
                _studentProgress[actualJornalIndex.Value].MarkList[markIndexToChange] = newMarkValue;
            }

            public double AverageGradeForSubject(Subjects subject)
            {
                int? actualJornalIndex;
                double avgGrade = 0;
                if (TryGetJornalIndexBySubject(subject, out actualJornalIndex))
                {
                    avgGrade = _studentProgress[actualJornalIndex.Value].GetAverageGrade();
                }
                return avgGrade;
            }

            public double GetStudentAverageGrade()
            {
                var subjectsCount = Enum.GetNames(typeof(Subjects)).Length;
                double[] tempAvgMarks = new double[subjectsCount];
                for (int i = 0; i < subjectsCount; i++)
                {
                    tempAvgMarks[i] = AverageGradeForSubject((Subjects)i);
                }
                return tempAvgMarks.Average();
            }

            public byte[] GetMarksBySubject(Subjects subject)
            {
                int? actualJornalIndex;
                byte[] marksForSubject = null;
                if (TryGetJornalIndexBySubject(subject, out actualJornalIndex))
                {
                    marksForSubject = _studentProgress[actualJornalIndex.Value].MarkList;
                }
                return marksForSubject;
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