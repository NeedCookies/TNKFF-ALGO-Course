using System;
using System.Collections.Generic;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] pows = new long[n + 2];
            long[] prot = new long[n + 2];
            long[] l = new long[n + 2]; //l[n + 1] = n;
            long[] r = new long[n + 2]; //r[0] = 1;
            //v - array of killed
            long[] v = new long[n + 2]; v[0] = 1; v[n + 1] = 1; // monstrs which indexes are out of array's bound are automatically killed
            List<long> q = new List<long>();
            long[] ans = new long[n];
            string[] powsStr = Console.ReadLine().Split(' ');
            string[] protStr = Console.ReadLine().Split(' ');

            for (int i = 1; i <= n; i++)
            {
                pows[i] = int.Parse(powsStr[i - 1]);
                prot[i] = int.Parse(protStr[i - 1]);
                l[i] = i - 1;
                r[i] = i + 1;
            }

            for (int i = 1; i < n + 1; i++)
            {
                if (pows[l[i]] + pows[r[i]] > prot[i])
                {
                    q.Add(i);
                }
            }


            int cur = 0;
            while (q.Count > 0)
            {
                ans[cur] = q.Count;
                foreach (var i in q)
                {
                    r[l[i]] = r[i];
                    l[r[i]] = l[i];
                    v[i] = 1;
                }
                List<long> nx = new List<long>();
                foreach (var i in q)
                {
                    if (v[l[i]] == 0)
                    {
                        var t = l[i];
                        if (pows[l[t]] + pows[r[t]] > prot[t])
                        {
                            nx.Add(t);
                            v[t] = 1;
                        }
                    }
                    if (v[r[i]] == 0)
                    {
                        var t = r[i];
                        if (pows[l[t]] + pows[r[t]] > prot[t])
                        {
                            nx.Add(t);
                            v[t] = 1;
                        }
                    }
                }
                q = nx;
                cur += 1;
            }
            foreach (var answer in ans)
            {
                Console.Write(answer + " ");
            }
            Console.ReadLine();
        }
    }
}
