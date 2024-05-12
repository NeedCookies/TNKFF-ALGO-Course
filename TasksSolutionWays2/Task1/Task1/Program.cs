using System;
using System.Collections.Generic;

namespace Task1
{
    public static class ExtMethods
    {
        public static void resize(this List<int> l, int n, int defaultNum = 0)
        {
            for (int i = 0; i < n; i++)
            {
                l.Add(defaultNum);
            }
        }

        public static void resize(this List<List<int>> list, int n, int l = 0,  int defaultNum = 0)
        {
            for (int i = 0; i < n; i++)
            {
                list.Add(new List<int>());
                if (l == 0)
                {
                    continue;
                }
                for (int j = 0; j <= l + 1; j++)
                {
                    list[i].Add(defaultNum);
                }
            }
        }
    }

    internal class Program
    {
        private static int n, l;
        static List<List<int>> gr = new List<List<int>>();
        static List<int> tIn = new List<int>(), tOut = new List<int>();
        static int timer = 0;
        static List<List<int>> up = new List<List<int>>();
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] ns = Console.ReadLine().Split(' ');
            tIn.resize(n);
            tOut.resize(n);
            
            gr.resize(n);
            while(Math.Pow(2, l) < n) { l++; }
            up.resize(n, l);
            for (int i = 1; i < n; i++)
            {
                gr[int.Parse(ns[i - 1])].Add(i);
            }
            DFS(0);

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] vv = Console.ReadLine().Split(' ');
                int v1 = int.Parse(vv[0]);
                int v2 = int.Parse(vv[1]);

                int res = LCA(v1, v2);
                Console.WriteLine(res);
            }
            Console.ReadLine();
        }

        public static bool upper(int v1, int v2)
        {
            return (tIn[v1] <= tIn[v2] && tOut[v2] <= tOut[v1]);
        }

        public static int LCA(int v1, int v2)
        {
            if (upper(v1, v2)) { return v1; }
            if (upper(v2, v1)) {  return v2; }

            for (int i = l; i >= 0; i--)
            {
                if (!upper(up[v1][i], v2))
                {
                    v1 = up[v1][i];
                }
            }

            return up[v1][0];
        }

        public static void DFS(int v, int p = 0)
        {
            tIn[v] = ++timer;
            up[v][0] = p;
            for (int i = 1; i <= l; i++)
            {
                up[v][i] = up[up[v][i - 1]][i - 1];
            }
            for (int i = 0; i < gr[v].Count; i++)
            {
                int to = gr[v][i];
                DFS(to, v);
            }
            tOut[v] = ++timer;
        }
    }
}