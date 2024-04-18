using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            string[] aStr = Console.ReadLine().Split(' ');
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(aStr[i]);
            }
            SegmentTree tr = new SegmentTree(a);
            for (int i = 0; i < m; i++)
            {
                string[] coms = Console.ReadLine().Split(' ');
                if (coms[0] == "1")
                {
                    tr.update(int.Parse(coms[1]));
                }
                else
                {
                    Console.WriteLine(tr.findOne(int.Parse(coms[1])));
                }
            }
            //Console.ReadLine();
        }
    }

    public class SegmentTree
    {
        public List<Vertex> t = new List<Vertex>();
        int[] arr;
        public SegmentTree(int[] a)
        {
            arr = a;
            for (int i = 0; i < a.Length * 4; i++)
            {
                t.Add(new Vertex(i));
            }
            build(0, 0, a.Length);
        }

        public void update(int k)
        {
            update(k, 0, 0, arr.Length);
        }

        private void update(int k, int v, int l, int r)
        {
            if (r - l == 1)
            {
                arr[k] = 1 - arr[k];
                t[v].Data = arr[k];
            }
            else
            {
                int tm = (r + l) / 2;
                if (k < tm)
                {
                    update(k, v*2 +1, l, tm);
                }
                else
                {
                    update(k, v*2 + 2, tm, r);
                }
                t[v].Data = t[v*2 + 1].Data + t[v*2 + 2].Data; 
            }
        }

        private void build(int v, int l, int r)
        {
            if (r - l == 1)
            {
                t[v].Data = arr[l];
            }
            else
            {
                int tm = (r + l) / 2;
                build(v * 2 + 1, l, tm);
                build(v * 2 + 2, tm, r);
                t[v].Data = t[v*2 + 1].Data + t[v*2 + 2].Data;
            }
        }

        public int findOne(int k)
        {
            return findOne(0, 0, arr.Length, k + 1);
        }

        private int findOne(int v, int tl, int tr, int k)
        {
            if (tr - tl == 1)
                return tl;
            int tm = (tl + tr) / 2;
            if (t[v * 2 + 1].Data >= k)
            {
                return findOne(v * 2 + 1, tl, tm, k);
            }
            else
            {
                return findOne(v * 2 + 2, tm, tr, k - t[v*2 + 1].Data);
            }
        }
    }

    public class Vertex
    { 
        public int Data { get; set; }
        public int Ind { get; set; }
        public int L { get; set; }
        public int R { get; set; }

        public Vertex(int ind, int l, int r)
        {
            Ind = ind;
            L = l; R = r;
        }

        public Vertex(int data, int ind, int l, int r)
        {
            Data = data;
            Ind = ind;
            L = l;
            R = r;
        }

        public Vertex(int ind)
        {
            Ind = ind;
        }
    }
}
