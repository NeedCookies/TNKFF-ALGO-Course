using System;

namespace Task7
{
    internal class Program
    {
        private static int[,] dp;
        private static int[,] pos;
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            maxBrackets(s);
        }

        private static string maxBrackets(string s)
        {
            int n = s.Length;
            dp = new int[n, n];
            pos = new int[n, n];

            for (int r = 0; r < n; r++)
            {
                for (int l = r; l >= 0; l--)
                {
                    if (l == r)
                    {
                        dp[l, r] = 1;
                        continue;
                    }


                    int min = int.MaxValue;
                    int mink = -1;

                    if (s[l] == '(' && s[r] == ')' ||
                        s[l] == '[' && s[r] == ']' ||
                        s[l] == '{' && s[r] == '}')
                    {
                        min = dp[l + 1, r - 1];
                    }

                    for (int k = l; k < r; k++)
                    {
                        if (min > dp[l, k] + dp[k + 1, r])
                        {
                            min = dp[l, k] + dp[k + 1, r];
                            mink = k;
                        }
                    }

                    dp[l, r] = min;
                    pos[l, r] = mink;
                }
            }
            var ans = build(0, n - 1, s);
            return ans;
        }

        private static string build(int l, int r, string s)
        {
            int temp = r - l + 1;
            if (dp[l, r] == temp)
            {
                return "";
            }
            if (dp[l, r] == 0)
            {
                Console.Write(s.Substring(l, r - l + 1));
                return "";
            }
            if (pos[l, r] == -1)
            {
                Console.Write(s[l]);
                build(l + 1, r - 1, s);
                Console.Write(s[r]);
                return "";
            }
            build(l, pos[l, r], s);
            build(pos[l, r] + 1, r, s);
            return "";
        }
    }
}
