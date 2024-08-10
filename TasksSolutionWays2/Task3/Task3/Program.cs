using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string x = Console.ReadLine();
            StringBuilder rev = new StringBuilder();
            for (int i = x.Length - 1; i >= 0; i--)
            {
                rev.Append(x[i]);
            }
            
            int len = x.Length;

            x = " " + x;
            string y = " " + rev.ToString();

            int[,] dp = new int[len + 1, len + 1];
             
            for (int i = 1; i <= len; i++)
            {
                for (int j = 1; j <= len; j++)
                {
                    if (x[i] == y[j])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            int f = len;
            int s = len;
            StringBuilder res = new StringBuilder();
            while (dp[f, s] > 0)
            {
                if (x[f] == y[s])
                {
                    res.Append(x[f]);
                    f--;
                    s--;
                }
                else if (dp[f - 1, s] > dp[f, s - 1])
                {
                    f--;
                }
                else
                {
                    s--;
                }
            }
            Console.WriteLine(res.Length);
            Console.WriteLine(res.ToString());
        }
    }
}