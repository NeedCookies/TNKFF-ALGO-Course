using System;
using System.Collections.Generic;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] mm = Console.ReadLine().Split(' ');
            int len = int.Parse(mm[0]);
            int N = int.Parse(mm[1]);

            string[] masStr = Console.ReadLine().Split(' ');
            int[] mas = new int[N + 2];
            for (int i = 0; i < N; i++)
            {
                mas[i + 1] = int.Parse(masStr[i]);
            }
            mas[0] = 0;
            mas[N + 1] = len;
            int ans = DP(mas, N);
            Console.WriteLine(ans);
        }

        public static int DP(int[] mas, int N)
        {
            int[,] dp = new int[N + 2, N + 2];

            for (int d = 2; d < N + 2; d++)
            {
                for (int i = 0; i < N + 2 - d; i++)
                {
                    int locMin = int.MaxValue;
                    for (int k = i + 1; k < i + d; k++)
                    {
                        if (dp[i, k] + dp[k, i + d] < locMin) { locMin = dp[i, k] + dp[k, i + d]; }
                    }
                    dp[i, i + d] = mas[i + d] - mas[i] + locMin;
                }
            }

            return dp[0, N + 1];
        }
    }
}