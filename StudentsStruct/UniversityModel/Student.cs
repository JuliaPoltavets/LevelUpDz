// © 2015 Sitecore Corporation A/S. All rights reserved.

using System;
using System.Linq;

namespace StudentsStruct.UniversityModel
{
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
}