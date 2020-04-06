using System;

namespace PALM_Lab_2_3
{
    struct MyTime
    {
        int hour, minute, second;

        public MyTime(int h, int m, int s)
        {
            hour = h;
            minute = m;
            second = s;
        }

        public override string ToString()
        {
            return $"{hour}:{minute:00}:{second:00}";
        }
    }

    class Program
    {
        static int TimeSinceMidnight(MyTime t)
        {
            return 0;
        }

        static MyTime TimeSinceMidnight(int s)
        {
            return new MyTime();
        }

        static MyTime AddOneSecond(MyTime t)
        {
            return t;
        }

        static MyTime AddOneMinute(MyTime t)
        {
            return t;
        }

        static MyTime AddOneHour(MyTime t)
        {
            return t;
        }

        static MyTime AddSeconds(MyTime t, int s)
        {
            return t;
        }

        static int Difference(MyTime t1, MyTime t2)
        {
            return 0;
        }

        static string WhatLesson(MyTime t)
        {
            return "";
        }

        static void Main(string[] args)
        {
            MyTime t = new MyTime(9, 2, 30);
            Console.WriteLine(t);
        }
    }
}
