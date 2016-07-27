using System;

namespace StudentsStruct.UniversityModel
{
    public struct SubjectJornal
    {
        private Subjects _subjectName;
        private byte[] _markList;
        public Subjects SubjectName { get { return _subjectName;} }
        public byte[] MarkList { get { return _markList; } }

        public SubjectJornal(Subjects subjectName, byte[] marksList)
        {
            _subjectName = subjectName;
            _markList = marksList;
        }

        public void AddMark(byte mark)
        {
            if (MarkList == null)
            {
                _markList = new[] { mark };
            }
            else
            {
                byte[] updatedGroup = new byte[MarkList.Length + 1];
                Array.Copy(MarkList, 0, updatedGroup, 0, MarkList.Length);
                updatedGroup[updatedGroup.Length - 1] = mark;
                _markList = updatedGroup;
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
