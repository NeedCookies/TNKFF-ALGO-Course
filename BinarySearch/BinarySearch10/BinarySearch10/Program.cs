using System;
using System.Collections.Generic;

namespace BinarySearch10
{
    internal class Program
    {
        private static long vMid = 0;
        private static long hMid = 0;
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            List<string> masDataStr = new List<string>();
            for (int i = 0; i < t; i++)
            {
                masDataStr.Add(Console.ReadLine());
            }

            foreach (var masData in masDataStr)
            {
                int n = int.Parse(masData.Split(' ')[0]);
                int m = int.Parse(masData.Split(' ')[1]);
                /*long[] rowSum = new long[n];
                long[] colSum = new long[m];

                for (long i = 1; i <= n * m; i++)
                {
                    colSum[(i - 1) % m] += i;
                    rowSum[(i - 1) / m] += i;
                }*/

                long minDifV = findMinVDif(n, m);
                long minDifH = findMinHDif(n, m);
                if (minDifV <= minDifH)
                {
                    vMid += 1; // т.к. нужно вывести номер столбца, а у нас индекс = номер - 1
                    Console.WriteLine("V " + vMid);
                }
                else
                {
                    hMid += 1;
                    Console.WriteLine("H " + hMid);
                }
            }
            Console.ReadLine();
        }

        private static long findMinVDif(int n, int m)
        {
            long sum1 = 0; long sum2 = 0;
            long minVDif = long.MaxValue;
            long allSum = (1 + n * m) / 2 * (m * n);

            long vL = 0; long vR = m - 1;

            while (vR > vL + 1)
            {
                vMid = (vL + vR) / 2;
                sum1 = (((1 + 1 + m * (n - 1)) / 2 * n) + ((vMid) + (vMid) * m * (n - 1)) / 2 * n) / 2 * vMid;
                sum2 = allSum - sum1;

                if (sum1 - sum2 < 0)
                {
                    vL = vMid;
                    minVDif = Math.Abs(sum2 - sum1);
                }
                else
                {
                    vR = vMid;
                }
            }

            vMid = vL;

            if (vR - vL == 1)
            {
                vMid = (vL + vR) / 2;
                sum1 = (((1 + 1 + m * (n - 1)) / 2 * n) + ((vR) + (vR) * m * (n - 1)) / 2 * n) / 2 * (vR);
                sum2 = allSum - sum1;
                if (Math.Abs(sum2 - sum1) < minVDif)
                {
                    minVDif = Math.Abs(sum2 - sum1);
                    vMid = vR;
                }
            }
            return minVDif;
        }

        private static long findMinHDif(int n, int m)
        {
            long sum1; long sum2;
            long minHDif = long.MaxValue;
            long allSum = (1 + (n * m)) / 2 * (n * m);

            long hL = 0;
            long hR = n - 1;
            while (hR > hL + 1)
            {
                long hMid = (hL + hR) / 2;
                sum1 = (1 + m * (hMid)) / 2 * m * (hMid);
                sum2 = allSum - sum1;
                if (sum1 - sum2 < 0)
                {
                    hL = hMid;
                    minHDif = Math.Abs(sum2 - sum1);
                }
                else
                {
                    hR = hMid;
                }
            }

            hMid = hL;

            if (hR - hL == 1)
            {
                sum1 = (1 + m * (hR)) / 2 * m * (hR);
                sum2 = allSum - sum1;
                if (Math.Abs(sum2 - sum1) < minHDif)
                {
                    minHDif = Math.Abs(sum2 - sum1);
                    hMid = hR;
                }
            }
            return minHDif;
        }
    }
}
