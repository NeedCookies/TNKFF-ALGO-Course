using System;
using System.Collections.Generic;
using System.Text;

namespace Task6
{
    internal class Program
    {
        static List<long> cur = new List<long>();
        static List<long> res = new List<long>();
        static long[] coins;
        public static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            coins = new long[10];
            string[] coinsStr = Console.ReadLine().Split(' ');
            long sum = 0;
            for (int i = 0; i < m; i++)
            {
                coins[i] = (int.Parse(coinsStr[i]));
                sum += coins[i]*2;
            }
            if (sum < n)
            {
                Console.WriteLine(-1);
                return;
            }
            calc(n, m);
            if (res.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            Console.WriteLine(res.Count);
            foreach (var coin in res)
            {
                Console.Write(coin + " ");
            }
        }

        public static void calc(int n, int m, int pos = 0, long sum = 0)
        {
            if (pos == m)
            {
                if (sum == n)
                {
                    if (res.Count == 0 || cur.Count < res.Count)
                    {
                        while (res.Count > 0) { res.RemoveAt(0); }
                        for (int i = 0; i < cur.Count; i++) { res.Add(cur[i]); }
                    }
                    return;
                }
                return;
            }

            calc(n, m, pos + 1, sum);

            cur.Add(coins[pos]);
            calc(n, m, pos + 1, sum + coins[pos]);

            cur.Add(coins[pos]);
            calc(n, m, pos + 1, sum + coins[pos] * 2);

            cur.RemoveAt(cur.Count - 1);
            cur.RemoveAt(cur.Count - 1);
        }

        /*public static void calcByMasc(int n, int m)
        {
            for (int i = 0; i < Math.Pow(2, coins.Length); i++)
            {
                List<int> b = new List<int>();
                for (int j = 0; j < coins.Length; j++)
                {
                    string bin = toBinString(i);
                    if (binAnd(Math.Pow(2, j).ToString(), i.ToString()))
                    {
                        int sum = 0;

                    }
                }
            }
        }

        static bool binAnd(string v1, string v2)
        {
            StringBuilder res = new StringBuilder();
            int len = v1.Length;
            if (v2.Length < v1.Length) { len = v2.Length; }
            for (int i = 1; i <= len; i++)
            {
                if (v1[v1.Length - i] == v2[v2.Length - i] && v1[v1.Length - i] == '1')
                {
                    return true;
                }
            }
            return false;
        }

        static String toBinString(int n)
        {
            String res = "";
            for (; n > 0; n >>= 1)
            {
                res = n % 2 + res;
            }
            return res;
        }*/
    }
}