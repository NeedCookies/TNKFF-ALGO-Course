using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nk = Console.ReadLine().Split(' ');
            int n = int.Parse(nk[0]);
            int k = int.Parse(nk[1]);
            string[] numsStr = Console.ReadLine().Split(' ');

            List<int> qu = new List<int>
            {
                1
            };
            int[] dp = new int[n + 1];
            dp[1] = 0;
            int[] prev = new int[n + 1];
            for (int i = 2; i <= n; i++)
            {
                while (qu.Count > 0 && qu[0] < i - k)
                {
                    qu.RemoveAt(0);
                }

                dp[i] = dp[qu[0]] + (i != n ? int.Parse(numsStr[i - 2]) : 0);
                prev[i] = qu[0];

                while (qu.Count > 0 && dp[i] >= dp[qu[qu.Count - 1]])
                {
                    qu.RemoveAt(qu.Count - 1);
                }
                qu.Add(i);
            }

            var restPath = new List<int>();
            var cur = n;

            while (cur != 0)
            {
                restPath.Add(cur);
                cur = prev[cur];
            }

            restPath.Reverse();
            Console.WriteLine(dp[n]);
            Console.WriteLine(restPath.Count - 1);
            foreach (int i in restPath)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
