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

        static void Main(string[] args)
        {
            MyTime t = new MyTime(9, 2, 30);
            Console.WriteLine(t);
        }
    }
}
