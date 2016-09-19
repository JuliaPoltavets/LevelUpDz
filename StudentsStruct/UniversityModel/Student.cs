using System;
using System.Linq;

namespace StudentsStruct.UniversityModel
{
    public class Student
    {
        private SubjectJornal[] _studentProgress;
        private string _studentId;
        private string _studentFirstName;
        private string _studentLastName;

        public double AverageGrade
        {
            get
            {
                return GetStudentAverageGrade();
            }
        }

        public string StudentId
        {
            get
            {
                return _studentId;
            }
            private set
            {
                _studentId = value;
            }
        }

        public string StudentFirstName
        {
            get
            {
                return _studentFirstName;
            }
            private set
            {
                _studentFirstName = value;
            }
        }

        public string StudentLastName
        {
            get
            {
                return _studentLastName;
            }
            private set
            {
                _studentLastName = value;
            }
        }

        public SubjectJornal[] StudentProgress
        {
            get
            {
                return (SubjectJornal[])_studentProgress.Clone();
            }
            private set
            {
                _studentProgress = value;
            }
        }

        public Student(string studentId, string studentFirstName, string studentLastName)
        {
            var subjectsCount = Enum.GetNames(typeof(Subjects)).Length;
            StudentFirstName = studentFirstName;
            StudentLastName = studentLastName;
            StudentId = studentId;
            StudentProgress = new SubjectJornal[0];
        }

        /// <summary>
        /// Method is used to update value of the StudentFirstName property
        /// </summary>
        /// <param name="newFirstName">value that will be set if it is not null or empty</param>
        /// <returns>flag if operation was successful or not</returns>
        public bool TryChangeFirstName(string newFirstName)
        {
            bool wasSuccessfullyChanged = false;
            if (!string.IsNullOrEmpty(newFirstName))
            {
                StudentFirstName = newFirstName;
                wasSuccessfullyChanged = true;
            }
            return wasSuccessfullyChanged;
        }

        /// <summary>
        /// Method is used to update value of the StudentLastName property
        /// </summary>
        /// <param name="newLastName">value that will be set if it is not null or empty</param>
        /// <returns>flag if operation was successful or not</returns>
        public bool TryChangeLastName(string newLastName)
        {
            bool wasSuccessfullyChanged = false;
            if (!string.IsNullOrEmpty(newLastName))
            {
                StudentLastName = newLastName;
                wasSuccessfullyChanged = true;
            }
            return wasSuccessfullyChanged;
        }

        /// <summary>
        /// Get index of the required jornal with marks of the current student
        /// </summary>
        /// <param name="subjectName">Subject name</param>
        /// <param name="jornalIndex">Index of the particular jornal that belongs to student</param>
        /// <returns>if operation was successful returns flag and index, otherwise returns false and null for the index value</returns>
        public bool TryGetJornalIndexBySubject(Subjects subjectName, out int? jornalIndex)
        {
            bool isSucceeded = false;
            jornalIndex = null;
            for (int index = 0; index < StudentProgress.Length; index++)
            {
                SubjectJornal jornal = StudentProgress[index];
                if (jornal.SubjectName == subjectName)
                {
                    isSucceeded = true;
                    jornalIndex = index;
                }
            }
            return isSucceeded;
        }

        /// <summary>
        /// Adds new mark into the particular student's jornal. If Jornal does not exists for this Subject will create it and add new mark
        /// </summary>
        /// <param name="subjectName">Subject name</param>
        /// <param name="mark">value of the mark to be added to the students jornal</param>
        public void AddNewMarkToStudentProgress(Subjects subjectName, byte mark)
        {
            int? actualJornalIndex;
            SubjectJornal newJornal = new SubjectJornal(subjectName, new[] { mark });
            if (!TryGetJornalIndexBySubject(subjectName, out actualJornalIndex))
            {
                StudentProgress = AddNewJornalToProgress(StudentProgress, newJornal);
            }
            else
            {
                StudentProgress[actualJornalIndex.Value].AddMark(mark);
            }
        }


        /// <summary>
        /// Replace whole progress of the student for particula subject with new value
        /// </summary>
        /// <param name="subjectName">Subject name</param>
        /// <param name="marksList">New set of marks for the particular subject</param>
        public void ReplaceJornalInStudentProgress(Subjects subjectName, byte[] marksList)
        {
            int? actualJornalIndex;
            SubjectJornal newJornal = new SubjectJornal(subjectName, marksList);
            if (!TryGetJornalIndexBySubject(subjectName, out actualJornalIndex))
            {
                StudentProgress = AddNewJornalToProgress(StudentProgress, newJornal);
            }
            else
            {
                StudentProgress[actualJornalIndex.Value] = newJornal;
            }
        }

        /// <summary>
        /// Change value of the particular mark in the spesific jornal
        /// If jornal for the subject does not exists will create it
        /// If index of the mark does not belongs to the progress array mark will be added as a last one into the progress
        /// </summary>
        /// <param name="subjectName">Subject name</param>
        /// <param name="markIndexToChange">index of the mark you want to change</param>
        /// <param name="newMarkValue">New set of marks for the particular subject</param>
        public void ChangeMarkByIndex(Subjects subjectName, int markIndexToChange, byte newMarkValue)
        {
            int? actualJornalIndex;
            if (!TryGetJornalIndexBySubject(subjectName, out actualJornalIndex))
            {
                StudentProgress = new SubjectJornal[]
                {
                        new SubjectJornal(subjectName, new []{ newMarkValue } )
                };
            }
            if (StudentProgress[actualJornalIndex.Value].MarkList.Length - 1 < markIndexToChange)
            {
                markIndexToChange = StudentProgress[actualJornalIndex.Value].MarkList.Length - 1;
            }
            StudentProgress[actualJornalIndex.Value].MarkList[markIndexToChange] = newMarkValue;
        }

        /// <summary>
        /// Calculates average grade for the student accross all his jornals with progress
        /// </summary>
        /// <param name="subjectName">Subject name</param>
        /// <returns>average mark of the student</returns>
        public double AverageGradeForSubject(Subjects subjectName)
        {
            int? actualJornalIndex;
            double avgGrade = 0;
            if (TryGetJornalIndexBySubject(subjectName, out actualJornalIndex))
            {
                avgGrade = StudentProgress[actualJornalIndex.Value].GetAverageGrade();
            }
            return avgGrade;
        }
        /// <summary>
        /// Gets the whole progress jornal for the spesific subject 
        /// </summary>
        /// <param name="subjectName">Subject name</param>
        /// <returns>array of marks for the selected subject</returns>
        public byte[] GetMarksBySubject(Subjects subjectName)
        {
            int? actualJornalIndex;
            byte[] marksForSubject = null;
            if (TryGetJornalIndexBySubject(subjectName, out actualJornalIndex))
            {
                marksForSubject = StudentProgress[actualJornalIndex.Value].MarkList;
            }
            return marksForSubject;
        }

        private double GetStudentAverageGrade()
        {
            var subjectsCount = Enum.GetNames(typeof(Subjects)).Length;
            double[] tempAvgMarks = new double[subjectsCount];
            for (int i = 0; i < subjectsCount; i++)
            {
                tempAvgMarks[i] = AverageGradeForSubject((Subjects)i);
            }
            return tempAvgMarks.Average();
        }

        private static SubjectJornal[] AddNewJornalToProgress(SubjectJornal[] initialArray, SubjectJornal newJornal) 
        {
            SubjectJornal[] updatedStudentProgress = new SubjectJornal[initialArray.Length + 1];
            Array.Copy(initialArray, 0, updatedStudentProgress, 0, initialArray.Length);
            updatedStudentProgress[updatedStudentProgress.Length - 1] = newJornal;
            return updatedStudentProgress;
        }

    }
}
