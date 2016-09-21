using System;

namespace StudentsStruct.UniversityModel
{
    public class SubjectJornal
    {
        private Subjects _subjectName;
        private byte[] _markList;

        public Subjects SubjectName
        {
            get
            {
                return _subjectName;
            }
            private set
            {
                _subjectName = value;
            }
        }

        public byte[] MarkList
        {
            get
            {
                return _markList;
            }
            private set
            {
                _markList = value;
            }
        }

        public SubjectJornal(Subjects subjectName, byte[] marksList)
        {
            SubjectName = subjectName;
            MarkList = marksList;
        }

        public SubjectJornal(SubjectJornal baseJornal)
        {
            SubjectName = baseJornal.SubjectName;
            if (baseJornal.MarkList == null)
            {
                MarkList = null;
            }
            else
            {
                MarkList = new byte[baseJornal.MarkList.Length];
                for (int i = 0; i < MarkList.Length; i++)
                {
                    MarkList[i] = baseJornal.MarkList[i];
                }
            }
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
}
