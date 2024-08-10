using System;
using System.Collections.Generic;

namespace Task5
{
    internal class Program
    {
        static long[,] dp;
        static long mod = 1_000_000_007;
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            long n = long.Parse(nm[0]);            
            long m = long.Parse(nm[1]);
            long res = Cnk(n, m, mod);
            Console.WriteLine(res);
        }

        public static long Cnk(long n, long k, long p)
        {
            long res = 1;
            if (k > n - k) k = n - k;
            for (int i = 1; i <= k; i++)
            {
                long inv = inverse(i, p);
                long newVal = (n - i + 1);
                res = ((res * newVal) % p * inv) % p;
            }
            return res;
        }

        public static long inverse(long x, long p)
        {
            return pow(x, p - 2, p);
        }

        public static long pow(long x, long n, long p)
        {
            if (n == 0) return 1;
            if (n % 2 == 0) return pow((x * x) % p, n / 2, p);
            return x*pow(x, n-1, p) % p;
        }
    }
}
