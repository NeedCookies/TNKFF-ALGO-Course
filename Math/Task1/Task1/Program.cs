using System;
using System.Collections.Generic;

namespace Task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            long n = int.Parse(nm[0]);
            long m = int.Parse(nm[1]);
            long gcd = GCD(n, m);
            Console.WriteLine(n*m/gcd);
        }

        public static long GCD(long n, long m)
        {
            while (m != 1 || n != 1)
            {
                if (m > n)
                {
                    long temp = m;   m = n;  n = temp;
                }
                n = n % m;
                if (n == 0) { return m; }
            }
            return m;
        }
    }
}