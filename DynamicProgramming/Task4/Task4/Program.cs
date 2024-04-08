using System;
using System.Collections.Generic;

namespace Task4
{
    internal class Program
    {
        static int[,] dp;
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            Console.WriteLine(wayCount(n, m));
        }

        private static int wayCount(int n, int m)
        {
            int[,] dp = new int[n, m];
            int[,] module = new int[n, m];
            List<int> curPos = new List<int>() { 0, 0 };
            List<List<int>> qu = new List<List<int>>() { curPos };
            module[0, 0] = 1;
            dp[0, 0] = 1;
            while (qu.Count > 0)
            {
                curPos = qu[0];
                var nexts = nextSteps(curPos, n, m);
                
                foreach (var next in nexts)
                {
                    if (module[next[0], next[1]] == 0)
                    {
                        qu.Add(next);
                    }
                    module[next[0], next[1]] += module[curPos[0], curPos[1]];
                    dp[next[0], next[1]] += module[curPos[0], curPos[1]];
                }
                
                module[curPos[0], curPos[1]] = 0;
                qu.RemoveAt(0);
            }
            
            return dp[n - 1, m - 1];
        }

        private static List<List<int>> nextSteps(List<int> curPos, int n, int m)
        {
            List<List<int>> coords = new List<List<int>>();
            int[] xChange = new int[4] { 2, 2, 1, -1 };
            int[] yChange = new int[4] { -1, 1, 2, 2 };

            for (int com = 0; com < 4; com++)
            {
                if (curPos[0] + xChange[com] < n && curPos[0] + xChange[com] >= 0 && curPos[1] + yChange[com] < m && curPos[1] + yChange[com] >= 0)
                {
                    coords.Add(new List<int>() { curPos[0] + xChange[com], curPos[1] + yChange[com] });
                }
            }

            return coords;
        }
    }
}
