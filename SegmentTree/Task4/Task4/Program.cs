using System;
using System.Collections.Generic;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            input = Console.ReadLine().Split();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(input[i]);
            }

            SegmentTree st = new SegmentTree(arr);

            for (int i = 0; i < m; i++)
            {
                input = Console.ReadLine().Split();
                if (input[0] == "1")
                {
                    st.Update(int.Parse(input[1]), int.Parse(input[2]));
                }
                else
                {
                    Console.WriteLine(st.Query(int.Parse(input[1]), int.Parse(input[2])));
                }
            }
        }
    }

    class SegmentTree
    {
        private List<long> tree = new List<long>();
        private int[] array;

        public SegmentTree(int[] arr)
        {
            array = arr;
            for (int i = 0; i < arr.Length * 4; i++)
            {
                tree.Add(0);
            }
            Build(0, 0, array.Length);
        }

        private void Build(int v, int tl, int tr)
        {
            if (tr - tl == 1)
            {
                tree[v] = array[tl];
            }
            else
            {
                int tm = (tl + tr) / 2;
                Build(v * 2 + 1, tl, tm);
                Build(v * 2 + 2, tm, tr);
                tree[v] = Math.Max(tree[v*2 + 1], tree[v*2 + 2]);
            }
        }

        public void Update(int i, int v)
        {
            array[i] = v;
            Update(0, 0, array.Length, v, i);
        }

        private void Update(int v, int tl, int tr, long newVal, int ind)
        {
            if (tr < ind)
            {
                return;
            }
            if (tr - tl == 1)
            {
                tree[v] = newVal;
                return;
            }
            int tm = (tl + tr) / 2;
            if (ind < tm)
            {
                Update(v * 2 + 1, tl, tm, newVal, ind);
            }
            else
            {
                Update(v * 2 + 2, tm, tr, newVal, ind);
            }
            //tree[v].Min = min(tree[v * 2 + 1].Min, tree[2 * v + 2].Min);
            tree[v] = Math.Max(tree[v * 2 + 1], tree[2 * v + 2]);
        }

        public long Query(int x, int l)
        {
            return Query(0, 0, array.Length, x, l);
        }

        private long Query(int v, int tl, int tr, int x, int j)
        {
            if (tree[v] < x || j >= tr)
            {
                return -1;
            }
            if (tr - tl == 1)
            {
                return tl;
            }
            int tm = (tl + tr) / 2;
            long res = Query(v * 2 + 1, tl, tm, x, j);
            if (res == -1)
            {
                res = Query(v * 2 + 2, tm, tr, x, j);
            }
            return res;
        }
    }
}
