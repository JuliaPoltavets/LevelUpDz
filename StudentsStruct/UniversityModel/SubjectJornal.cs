using System;

namespace StudentsStruct.UniversityModel
{
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
}