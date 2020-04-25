// Rostyslav L. PALM 2nd sem, 3rd lab, 1st variant
// Rights are not reserved.

using System;

namespace PALM_Lab_2_3
{

    struct MyTime
    {
        public int hour, minute, second;

        public MyTime(int h, int m, int s)
        {
            hour = h;
            minute = m;
            second = s;
            Normalize();
        }

        public override string ToString()
        {
            return $"{hour}:{minute:00}:{second:00}";
        }

        public void Normalize()
        {
            second += minute * 60 + hour * 60 * 60;
            second = second % (60 * 60 * 24);
            if (second < 0)
                second += 60 * 60 * 24;
            minute = (second / 60) % 60;
            hour = (second / (60 * 60)) % 24;
            second %= 60;
        }
    }

    class Program
    {
        static int TimeSinceMidnight(MyTime t)
        {
            return t.second + t.minute * 60 + t.hour * 60 * 60;
        }

        static MyTime TimeSinceMidnight(int s)
        {
            MyTime res = new MyTime(0, 0, s);
            res.Normalize();
            return res;
        }

        static MyTime AddOneSecond(MyTime t)
        {
            t.second += 1;
            t.Normalize();
            return t;
        }

        static MyTime AddOneMinute(MyTime t)
        {
            t.minute += 1;
            t.Normalize();
            return t;
        }

        static MyTime AddOneHour(MyTime t)
        {
            t.hour += 1;
            t.Normalize();
            return t;
        }

        static MyTime AddSeconds(MyTime t, int s)
        {
            t.second += s;
            t.Normalize();
            return t;
        }

        static int Difference(MyTime t1, MyTime t2)
        {
            return TimeSinceMidnight(t1) - TimeSinceMidnight(t2);
        }

        static string WhatLesson(MyTime t)
        {
            if (Difference(t, new MyTime(8, 0, 0)) < 0)
            {
                return "пари ще не почались";
            }
            else
            {
                t = AddSeconds(t, -8 * 60 * 60);
                int les_num = 1;
                while (les_num < 5 && (Difference(t, new MyTime(1, 40, 0)) >= 0)) // Counting lessons and breaks 1 through 4
                {
                    les_num++;
                    t = AddSeconds(t, -1 * 60 * 60 - 40 * 60); // Minus 1h 40m
                }
                if (les_num == 5 && Difference(t, new MyTime(1, 30, 0)) >= 0) // after 5th lesson break is 10mins long
                {
                    les_num++;
                    t = AddSeconds(t, -1 * 60 * 60 - 30 * 60);
                }

                if (Difference(t, new MyTime(1, 20, 0)) < 0)
                {
                    return $"{les_num}-{(les_num == 3 ? "я" : "а")} пара";
                }
                else if (les_num < 6)
                {
                    return $"перерва між {les_num}-ю та {les_num + 1}-ю парами";
                }
                else
                {
                    return "пари вже скінчились";
                }
            }
        }

        static void Main(string[] args)
        {
            MyTime t = new MyTime(9, 2, 30);
            Console.WriteLine(t);

            Console.WriteLine("TimeSinceMidnight:");
            Console.WriteLine(TimeSinceMidnight(t));
            Console.WriteLine(TimeSinceMidnight(24*60*60 - 1));

            Console.WriteLine("Add one (s/m/h):");
            t = AddOneSecond(t);
            Console.WriteLine(t);
            t = AddOneMinute(t);
            Console.WriteLine(t);
            t = AddOneHour(t);
            Console.WriteLine(t);

            Console.WriteLine("AddSeconds:");
            t = AddSeconds(t, -40000);
            Console.WriteLine(t);

            Console.WriteLine(AddSeconds(new MyTime(23, 59, 59), 2));

            Console.WriteLine("Difference:");
            Console.WriteLine(Difference(t, new MyTime(4, 20, 0)));

            MyTime t1 = new MyTime(7, 59, 59);
            Console.WriteLine($"What lesson {t1}: {WhatLesson(t1)}");
            MyTime t2 = new MyTime(8, 0, 0);
            Console.WriteLine($"What lesson {t2}: {WhatLesson(t2)}");
            MyTime t3 = new MyTime(17, 29, 59);
            Console.WriteLine($"What lesson {t3}: {WhatLesson(t3)}");
            MyTime t4 = new MyTime(17, 30, 0);
            Console.WriteLine($"What lesson {t4}: {WhatLesson(t4)}");
        }
    }
}
