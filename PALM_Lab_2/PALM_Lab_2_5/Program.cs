// Rostyslav L. Lab 5 Var 10

using System;
using System.IO;
using System.Collections.Generic;

namespace struct_lab_student
{
    class Program
    {
        static List<Student> ReadStudents(string filepath)
        {
            string input = File.ReadAllText(filepath);
            string[] inputLines = input.Split('\r', '\n');
            List<Student> students = new List<Student>(inputLines.Length);
            for (int i = 0; i < inputLines.Length; i++)
            {
                students[i] = new Student(inputLines[i]);
            }
            return students;
        }

        static void Main(string[] args)
        {
            List<Student> students = ReadStudents("input.txt");


        }
    }
}
