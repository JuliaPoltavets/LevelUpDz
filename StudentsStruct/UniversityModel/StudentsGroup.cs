using System;
using System.Linq;

namespace StudentsStruct.UniversityModel
{
    public class StudentsGroup
    {

        #region Fields

        private short _groupId;
        private Student[] _students;

        #endregion

        #region Properties

        public short GroupId
        {
            get
            {
                return _groupId;
            }
            private set
            {
                _groupId = value;
            }
        }

        public int StudentsCount
        {
            get
            {
                int count = 0;
                if (_students != null)
                {
                    count = _students.Length;
                }

                return count;
            }
        }

        public Student[] Students
        {
            get
            {
                Student[] safeStudentsList = null;
                if (_students != null)
                {
                    safeStudentsList = new Student[_students.Length];
                    for (int i = 0; i < safeStudentsList.Length; i++)
                    {
                        safeStudentsList[i] = new Student(_students[i],false);
                    }
                }
                return safeStudentsList;
            }
            private set
            {
                _students = value;
            }
        }

        #endregion

        public StudentsGroup(short groupId, int groupSize = 0)
        {
            GroupId = groupId;
            Students = new Student[groupSize];
        }

        public StudentsGroup(short groupId, Student[] studentsList)
        {
            GroupId = groupId;
            Students = studentsList;
        }

        public StudentsGroup(short groupId, StudentsGroup baseGroup, bool removeMarks = true)
        {
            GroupId = groupId;
            Students = MakeMemberwiseCopy(baseGroup.Students, removeMarks);
        }

        #region IndexerOverload

        /// <summary>
        /// Returns student by its order in the group
        /// </summary>
        /// <param name="key">Student's index in the current group</param>
        /// <returns>Student's data</returns>
        public Student this[int key]
        {
            get
            {
                return _students[key];
            }
            set
            {
                _students[key] = value;
            }
        }

        /// <summary>
        /// Get student info by unique identifier
        /// Set new value if identifier was found, add new student to the group if student with such identifier is not present in the group
        /// </summary>
        /// <param name="studentId">unique identifier for the student</param>
        /// <returns>student entity with all public properties</returns>
        public Student this[string studentId]
        {
            get
            {
                Student foundStudent = null;
                int stIndex;
                if (TryGetStudentIndexById(studentId, out stIndex))
                {
                    foundStudent = this[stIndex];
                }
                return foundStudent;
            }
            set
            {
                int stIndex;
                if (TryGetStudentIndexById(studentId, out stIndex))
                {
                    this[stIndex] = value;
                }
                else
                {
                    AddStudent(value);
                }
            }
        }

        #endregion

        /// <summary>
        /// If students array is null - creates new array and add student
        /// If Student with such identifier is already defined in the group nothing will be added
        /// If student with such identifier is not present in the group it will be added
        /// </summary>
        /// <param name="student">student to be added</param>
        /// <returns>was add operation successful or not</returns>
        public bool AddStudent(Student student)
        {
            bool wasSuccessfullyAdded = false;
            if (_students == null)
            {
                Students = new[] { student };
                wasSuccessfullyAdded = true;
            }
            else
            {
                int stIndex;
                if (!TryGetStudentIndexById(student.StudentId, out stIndex))
                {
                    Student[] updatedGroup = new Student[_students.Length + 1];
                    Array.Copy(Students, 0, updatedGroup, 0, Students.Length);
                    updatedGroup[updatedGroup.Length - 1] = student;
                    Students = updatedGroup;
                    wasSuccessfullyAdded = true;
                }
            }
            return wasSuccessfullyAdded;
        }

        /// <summary>
        /// Updates student's personal data if student with such id is in the group
        /// </summary>
        /// <param name="studentId">unique identifier to find student in the group</param>
        /// <param name="firstName">new value of the FirstName </param>
        /// <param name="lastName">ew value of the LastName </param>
        /// <returns>was update operation successful or not </returns>
        public bool UpdateStudentPersonalData(string studentId, string firstName, string lastName)
        {
            bool wasSuccessfullyChanged = false;
            int stIndex;
            if (TryGetStudentIndexById(studentId, out stIndex))
            {
                bool firstNameWasChanged = Students[stIndex].TryChangeFirstName(firstName);
                bool lastNameWasChanged = Students[stIndex].TryChangeLastName(lastName);
                wasSuccessfullyChanged = firstNameWasChanged && lastNameWasChanged;
            }
            return wasSuccessfullyChanged;
        }

        /// <summary>
        /// Delete student from the group if student with such Id was found
        /// </summary>
        /// <param name="studentId">unique identifier of the student in the group</param>
        /// <returns>was delete operation successful or not</returns>
        public bool DeleteStudentFromGroup(string studentId)
        {
            bool wasSuccessfullyDeleted = false;
            int stIndex;
            if (TryGetStudentIndexById(studentId, out stIndex))
            {
                if ((Students.Length - 1) > 0)
                {
                    Student[] updatedGroup = new Student[Students.Length - 1];
                    Array.Copy(Students, 0, updatedGroup, 0, stIndex);
                    Array.Copy(Students, stIndex + 1, updatedGroup, stIndex, (Students.Length - 1) - stIndex);
                    Students = updatedGroup;
                }
                else
                {
                    Students = null;
                }
                wasSuccessfullyDeleted = true;
            }
            return wasSuccessfullyDeleted;
        }

        /// <summary>
        /// Provide safe way of getting average grade of the student if it was found in the group by id
        /// </summary>
        /// <param name="studentId">unique identifier of the student</param>
        /// <param name="avgGrade">calculated value for the particular student</param>
        /// <returns>was calculation opration successful or not</returns>
        public bool TryGetAverageStudentGrade(string studentId, out double avgGrade)
        {
            int stIndex;
            avgGrade = double.NegativeInfinity;
            if (TryGetStudentIndexById(studentId, out stIndex))
            {
                avgGrade = this[stIndex].AverageGrade;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sorts descending student's list by average grade
        /// Gets the first entry in the array - the best result
        /// </summary>
        /// <returns>in case student was found returns it otherwise returns null</returns>
        public Student GetStudentWithHighestAvgGrade()
        {
            Student[] tempGroup = new Student[0];
            if (Students != null)
            {
                tempGroup = Students.OrderByDescending(st => st.AverageGrade).ToArray();
            }
            return tempGroup.FirstOrDefault();
        }

        /// <summary>
        /// Sorts descending student's list by average grade
        /// Gets the last entry in the array - the worst result
        /// </summary>
        /// <returns>in case student was found returns it otherwise returns null</returns>
        public Student GetStudentWithLowestAvgGrade()
        {
            Student[] tempGroup = new Student[0];
            if (Students != null)
            {
                tempGroup = Students.OrderByDescending(st => st.AverageGrade).ToArray();
            }
            return tempGroup.LastOrDefault();
        }

        /// <summary>
        /// Performs look up by student unique identifier in the group
        /// </summary>
        /// <param name="studentId">unique identifier of the student</param>
        /// <param name="studentIndex">student index in the group with such identifier</param>
        /// <returns>was Get operation successful or not</returns>
        private bool TryGetStudentIndexById(string studentId, out int studentIndex)
        {
            bool studentWasFound = false;
            studentIndex = int.MinValue;
            for (int i = 0; i < Students.Length; i++)
            {
                if (this[i].StudentId.Equals(studentId))
                {
                    studentIndex = i;
                    studentWasFound = true;
                }
            }
            return studentWasFound;
        }

        private Student[] MakeMemberwiseCopy(Student[] initialArray, bool removeStudentProgress)
        {
            Student[] newArray = null;
            if (initialArray != null)
            {
                newArray = new Student[initialArray.Length];
                for (int i = 0; i < newArray.Length; i++)
                    {
                        newArray[i] = new Student(initialArray[i], removeStudentProgress);
                    }
            }
            return newArray;
        }
    }
}
