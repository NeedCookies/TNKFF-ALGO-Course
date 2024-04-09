using System;
using System.Collections.Generic;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            int[,] mas = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] numsStr = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = int.Parse(numsStr[j]);
                }
            }
            var ans = FindMaxSq(mas, n, m);
            Console.WriteLine(ans[0]);
            Console.WriteLine(ans[1] + " " + ans[2]);
        }

        private static List<int> FindMaxSq(int[,] nums, int n, int m)
        {
            List<List<int>> dp = new List<List<int>>();
            List<int> ans = new List<int>() { 0, 0, 0 };
            for (int i = 0; i < n; i++)
            {
                dp.Add(new List<int>(new int[m]));
                dp[i][m - 1] = nums[i, m - 1];
                if (dp[i][m - 1] == 1)
                {
                    ans[0] = 1;
                    ans[1] = i + 1;
                    ans[2] = m;
                }
            }
            for (int k = 0; k < m; k++)
            {
                dp[n - 1][k] = nums[n - 1, k];
                if (dp[n - 1][k] == 1)
                {
                    ans[0] = 1;
                    ans[1] = n;
                    ans[2] = k + 1;
                }
            }

            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = m - 2; j >= 0; j--)
                {
                    if (nums[i, j] == 0)
                    {
                        dp[i][j] = 0;
                        continue;
                    }
                    dp[i][j] = Math.Min(Math.Min(dp[i + 1][j], dp[i][j + 1]), dp[i + 1][j + 1]) + 1;
                    if (dp[i][j] > ans[0])
                    {
                        ans[0] = dp[i][j];
                        ans[1] = i + 1;
                        ans[2] = j + 1;
                    }
                }
            }


            /*
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(dp[i][j]);
                }
                Console.WriteLine();
            }*/
            return ans;
        }
    }
}
