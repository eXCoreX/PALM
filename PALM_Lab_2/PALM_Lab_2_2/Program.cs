using System;

namespace PALM_Lab_2_2
{
    // VAR 13

    class Helper
    {
        public static int[][] InputArray2DInt(int n, int m)
        {
            int[][] a = new int[n][];
            for (int i = 0; i < n; i++)
            {
                a[i] = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            }
            return a;
        }

        public static int[] InputArrayInt(int n)
        {
            int[] a = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            return a;
        }

        public static double[][] InputArray2DDouble(int n, int m)
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

        public static void PrintArray<T>(T[] a)
        {
            foreach (var i in a)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

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

            int[][] a = Helper.InputArray2DInt(n, m);

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
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            int[][] a = Helper.InputArray2DInt(n, n);

            int mx = int.MinValue, mxi = -1;

            for (int i = 0; i < n; i++)
            {
                foreach (var j in a[i])
                {
                    if (j > mx)
                    {
                        mx = j; mxi = i;
                    }
                }
            }

            for (int j = 0; j < n; j++)
            {
                int temp = a[mxi][j];
                a[mxi][j] = a[n - j - 1][j];
                a[n - j - 1][j] = temp;
            }

            Console.WriteLine("Result array:");

            Helper.PrintArray(a);
        }

        static void Task_C()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            int[] a = Helper.InputArrayInt(n);

            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());

            int[] a_add = Helper.InputArrayInt(k);

            Array.Resize(ref a, n + k);
            a_add.CopyTo(a, n);

            Console.WriteLine("Result array: ");

            Helper.PrintArray(a);
        }

        static void Task_D()
        {
            Console.WriteLine("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("M = ");
            int m = int.Parse(Console.ReadLine());

            int[][] a = Helper.InputArray2DInt(n, m);

            int mx = int.MinValue, mxi = -1;

            for (int i = 0; i < n; i++)
            {
                foreach (var j in a[i])
                {
                    if (j >= mx)
                    {
                        mx = j; mxi = i;
                    }
                }
            }

            Array.Resize(ref a, n + 1);

            Random rnd = new Random();
            int[] add = new int[m];
            for (int i = 0; i < m; i++)
            {
                add[i] = rnd.Next();
            }

            for (int i = n + 1 - 1; i > mxi; i--)
            {
                a[i] = a[i - 1];
            }
            Console.WriteLine("Result array: ");

            a[mxi] = add;

            Helper.PrintArray(a);
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
