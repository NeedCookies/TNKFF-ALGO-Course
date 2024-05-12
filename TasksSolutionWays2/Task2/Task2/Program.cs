using System;
using System.Collections.Generic;

namespace Task2
{
    public static class ExtMethods
    {
        public static void resize(this List<List<int[]>> list, int n, int l = 0)
        {
            for (int i = 0; i <= n; i++)
            {
                list.Add(new List<int[]>());
                if (l == 0) { continue; }

                for (int j = 0; j <= l + 1; j++)
                {
                    list[i].Add(new int[2]);
                }
            }
        }

        public static void resize(this List<int[]> list, int n, int innerSize)
        {
            for (int i = 0; i <= n; i++)
            {
                list.Add(new int[innerSize]);
            }
        }

        public static void resize(this List<int> list, int n, int defNum = 0)
        {
            for (int i = 0; i < n; i++)
            {
                list.Add(defNum);
            }
        }
    }

    internal class Program
    {
        static List<List<int[]>> gr = new List<List<int[]>>();
        static List<int> tIn = new List<int>();
        static List<int> tOut = new List<int>();
        static int time = 0;
        static List<List<int[]>> up = new List<List<int[]>>();
        static int l = 0;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            gr.resize(n);
            tIn.resize(n);
            tOut.resize(n);
            
            while (Math.Pow(2, l) < n) { l++; }
            up.resize(n, l);

            for (int i = 1; i < n; i++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int x = int.Parse(nums[0]);
                int y = int.Parse(nums[1]);
                gr[x].Add(new int[2] { i, y });
            }
            DFS(0);

            /*for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    Console.Write(up[i][j][0] + " " + up[i][j][1] + "\t|\t");
                }
                Console.WriteLine();
            }*/
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] vv = Console.ReadLine().Split(' ');
                int v1 = int.Parse(vv[0]);
                int v2 = int.Parse(vv[1]);

                int ans = minLCA(v1, v2);
                Console.WriteLine(ans);
            }
        }

        public static int minLCA(int v1, int v2)
        {
            int res = int.MaxValue;
            for (int i = l; i >= 0; i--)
            {
                if (!isParent(up[v1][i][0], v2))
                {
                    res = Math.Min(res, up[v1][i][1]);
                    v1 = up[v1][i][0];
                }
            }
            if (!isParent(v1, v2))
            {
                res = Math.Min(res, up[v1][0][1]);
            }

            for (int i = l; i >= 0; i--)
            {
                if (!isParent(up[v2][i][0], v1))
                {
                    res = Math.Min(res, up[v2][i][1]);
                    v2 = up[v2][i][0];
                }
            }
            if (!isParent(v2, v1))
            {
                res = Math.Min(res, up[v2][0][1]);
            }
            return res;
        }

        public static bool isParent(int parent, int child)
        {
            return tIn[parent] <= tIn[child] && tOut[child] <= tOut[parent];
        }

        public static void DFS(int ind, int parent = 0, int path = int.MaxValue)
        {
            tIn[ind] = ++time;
            up[ind][0] = new int[2] { parent, path };
            for (int i = 1; i <= l; i++)
            {
                up[ind][i][0] = up[up[ind][i - 1][0]] [i - 1][0];
                up[ind][i][1] = Math.Min(up[ind][i - 1][1], up[up[ind][i - 1][0]] [i - 1][1]);
            }
            for (int i = 0; i < gr[ind].Count; i++)
            {
                int to = gr[ind][i][0];
                DFS(to, ind, gr[ind][i][1]);
            }
            tOut[ind] = ++time;
        }
    }
}