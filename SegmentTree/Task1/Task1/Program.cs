using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);

            int pow = 0;
            while (Math.Pow(2, pow) <= n)
            {
                pow++;
            }
            int len = int.Parse(Math.Pow(2, pow).ToString());

            List<Vertex> segmTr = new List<Vertex>();
            for (int i = 0; i < len * 2; i++)
            {
                segmTr.Add(new Vertex(i));
            }

            string[] numsStr = Console.ReadLine().Split(' ');

            // fill in the tree
            for (int i = 0; i < len; i++)
            {
                if (i < numsStr.Length)
                {
                    segmTr[len - 1 + i].Data = int.Parse(numsStr[i]);
                }
                segmTr[len - 1 + i].L = i;
                segmTr[len - 1 + i].R = i;
            }
            for (int i = len - 2; i >= 0; i--)
            {
                segmTr[i].Data = segmTr[i*2 + 1].Data + segmTr[i*2 + 2].Data;
                segmTr[i].L = segmTr[i * 2 + 1].L;
                segmTr[i].R = segmTr[i * 2 + 2].R;
            }
            for (int i = 0; i < m; i++)
            {
                string[] coms = Console.ReadLine().Split(' ');

                if (coms[0] == "1")
                {
                    Update(segmTr, int.Parse(coms[1]), int.Parse(coms[2]));
                }
                else
                {
                    Console.WriteLine(GetSum(int.Parse(coms[1]), int.Parse(coms[2]), segmTr));
                }
            }
        }

        private static void Update(List<Vertex> segmTree, int ind, int newVal)
        {
            Vertex cur = segmTree[0];

            Stack<Vertex> way = new Stack<Vertex>();
            while (cur.Ind * 2 + 2 < segmTree.Count)
            {
                way.Push(cur);
                long mid = (cur.L + cur.R) / 2;
                if (ind <= mid)
                {
                    cur = segmTree[cur.Ind * 2 + 1];
                }
                else
                {
                    cur = segmTree[cur.Ind * 2 + 2];
                }
            }
            cur.Data = newVal;

            while (way.Count > 0)
            {
                Vertex prev = way.Pop();
                prev.Data = segmTree[prev.Ind * 2 + 1].Data + segmTree[prev.Ind * 2 + 2].Data;
            }
        }

        private static long GetSum(int l, int r, List<Vertex> SegmTree)
        {
            Stack<Vertex> st = new Stack<Vertex>();
            long sum = 0;
            st.Push(SegmTree[0]);

            while (st.Count > 0)
            {
                Vertex cur = st.Pop();
                if (cur.L >= l && cur.R < r)
                {
                    sum += cur.Data;
                    continue;
                }

                long mid = (cur.L + cur.R) / 2;
                if (l <= mid)
                {
                    if (cur.Ind * 2 + 1 < SegmTree.Count)
                    {
                        st.Push(SegmTree[cur.Ind * 2 + 1]);
                    }
                    else
                    {
                        sum += cur.Data;
                    }
                }
                if (r - 1 > mid)
                {
                    if (cur.Ind * 2 + 2 < SegmTree.Count)
                    {
                        st.Push(SegmTree[cur.Ind * 2 + 2]);
                    }
                    else
                    {
                        sum += cur.Data;
                    }
                }
            }

            return sum;
        }
    }

    public class Vertex
    {
        public int L { get; set; }
        public int R { get; set; }
        public long Data { get; set; }
        public int Ind { get; set; }

        public Vertex(int ind)
        {
            Ind = ind;
        }
    }
}
