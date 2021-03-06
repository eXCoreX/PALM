﻿using System;
using System.Text;

namespace struct_lab_student
{
    struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char sex;
        public string dateOfBirth;
        public char mathematicsMark;
        public char physicsMark;
        public char informaticsMark;
        public int scholarship;

        // Aaa Bbb Ccc M 01.02.2003 5 - 4 0
        public Student(string lineWithAllData)
        {
            StringBuilder sb = new StringBuilder(lineWithAllData);
            // Removing excess whitespaces
            for (int i = 0; i < sb.Length - 1;)
            {
                if (sb[i] == ' ' && sb[i + 1] == ' ')
                {
                    sb = sb.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }

            string[] splittedLine = sb.ToString().Split();

            if (splittedLine.Length != 9)
            {
                throw new ArgumentException("Bad student line");
            }

            surName = splittedLine[0];
            firstName = splittedLine[1];
            patronymic = splittedLine[2];
            sex = splittedLine[3][0];
            dateOfBirth = splittedLine[4];
            mathematicsMark = splittedLine[5][0];
            physicsMark = splittedLine[6][0];
            informaticsMark = splittedLine[7][0];
            if(!int.TryParse(splittedLine[8], out scholarship))
            {
                throw new Exception("Scholarship must be an integer");
            }
        }
    }
}