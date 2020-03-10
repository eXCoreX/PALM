using System;

namespace PALM_Lab_2_2
{
    // VAR 13

    class Helper
    {
        public static int[][] InputArrayInt(int n, int m)
        {
            int[][] a = new int[n][];
            for (int i = 0; i < n; i++)
            {
                a[i] = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            }
            return a;
        }

        public static double[][] InputArrayDouble(int n, int m)
        {
            double[][] a = new double[n][];
            for (int i = 0; i < n; i++)
            {
                a[i] = Array.ConvertAll(Console.ReadLine().Trim().Split(), double.Parse);
            }
            return a;
        }


        public static void PrintArray<T>(T[][] a)
        {
            foreach (var i in a)
            {
                foreach (var j in i)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }
        }
    }

    class Main_Class
    {
        static void Task_A()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("M = ");
            int m = int.Parse(Console.ReadLine());

            int[][] a = Helper.InputArrayInt(n, m);

            bool containsNeg = false;

            for (int i = 0; i < n; i++)
            {
                containsNeg = false;
                foreach (var j in a[i])
                {
                    containsNeg |= j < 0;
                }
                if (!containsNeg)
                {
                    Console.WriteLine($"First without negatives {i + 1}");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("Each row contains negative");
        }

        static void Task_B()
        {
            Console.WriteLine("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("M = ");
            int m = int.Parse(Console.ReadLine());

            int[][] a = Helper.InputArrayInt(n, m);

            bool containsNeg = false;

            for (int i = 0; i < n; i++)
            {
                containsNeg = false;
                foreach (var j in a[i])
                {
                    containsNeg |= j < 0;
                }
                if (!containsNeg)
                {
                    Console.WriteLine($"First without negatives {i + 1}");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("Each row contains negative");
        }

        static void Task_C()
        {
            Console.WriteLine("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("M = ");
            int m = int.Parse(Console.ReadLine());

            int[][] a = Helper.InputArrayInt(n, m);

            bool containsNeg = false;

            for (int i = 0; i < n; i++)
            {
                containsNeg = false;
                foreach (var j in a[i])
                {
                    containsNeg |= j < 0;
                }
                if (!containsNeg)
                {
                    Console.WriteLine($"First without negatives {i + 1}");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("Each row contains negative");
        }

        static void Task_D()
        {
            Console.WriteLine("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("M = ");
            int m = int.Parse(Console.ReadLine());

            int[][] a = Helper.InputArrayInt(n, m);

            bool containsNeg = false;

            for (int i = 0; i < n; i++)
            {
                containsNeg = false;
                foreach (var j in a[i])
                {
                    containsNeg |= j < 0;
                }
                if (!containsNeg)
                {
                    Console.WriteLine($"First without negatives {i + 1}");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("Each row contains negative");
        }

        static void Main()
        {
            Console.Write("Choose task (A/B/C/D): ");
            string ans;
            ans = Console.ReadLine();
            switch (ans)
            {
                case "A":
                    {
                        Task_A();
                        break;
                    }
                case "B":
                    {
                        Task_B();
                        break;
                    }
                case "C":
                    {
                        Task_C();
                        break;
                    }
                case "D":
                    {
                        Task_D();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Error, wrong input");
                        break;
                    }
            }
        }
    }
}
