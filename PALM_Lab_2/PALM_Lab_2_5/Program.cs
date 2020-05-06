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
            List<Student> students = new List<Student>();
            for (int i = 0; i < inputLines.Length; i++)
            {
                if (!(string.IsNullOrEmpty(inputLines[i]) || string.IsNullOrWhiteSpace(inputLines[i])))
                {
                    students.Add(new Student(inputLines[i]));
                }
            }
            return students;
        }

        static void ShowStudents(ref List<Student> students)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Students with marks >=3 and without scholarship: ");
            bool showed = false;
            foreach (var student in students)
            {
                if (student.mathematicsMark >= '3' &&
                    student.physicsMark     >= '3' &&
                    student.informaticsMark >= '3' &&
                    student.scholarship == 0)
                {
                    Console.WriteLine(student.surName);
                    showed = true;
                }
            }
            if (!showed)
            {
                Console.WriteLine("None");
            }
        }

        static void Main(string[] args)
        {
            List<Student> students = ReadStudents("input.txt");

            ShowStudents(ref students);
        }
    }
}
