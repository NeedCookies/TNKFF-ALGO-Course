using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(calc(n));
        }

        public static long calc(int n)
        {
            int A = 1;
            int BC = 2;

            int[,] count = new int[2, n];
            count[0, 0] = BC;
            count[1, 0] = A;

            for (int i = 1; i < n; i++)
            {
                count[0, i] = (count[0, i - 1] + count[1, i - 1]) * 2;
                count[1, i] = count[0, i - 1];
            }

            return count[0, n - 1] + count[1, n - 1];
        }
    }
}
