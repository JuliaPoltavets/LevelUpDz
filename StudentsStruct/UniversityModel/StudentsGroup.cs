using System;
using System.Linq;

namespace StudentsStruct.UniversityModel
{
    public struct StudentsGroup
    {
        private short _groupId;
        private Student[] _students;
        public StudentsGroup(short groupId)
        {
            _groupId = groupId;
            _students = null;
        }

        public Student[] GroupList {
            get
            {
                return _students;
            }
        }

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