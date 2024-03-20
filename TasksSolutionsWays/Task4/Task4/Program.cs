using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] n_k = Console.ReadLine().Split(' ');
            long n = int.Parse(n_k[0]);
            long k = long.Parse(n_k[1]);

            long l = 1;
            long r = n * n;
            long mid = 0;
            while (l < r)
            {
                long count = 0;
                mid = (l + r) / 2;
                for (int i = 1; i <= n; i++)
                {
                    count += Math.Min(mid / i, n);
                }

                if (count >= k)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
            Console.WriteLine(l);
        }
    }
}
