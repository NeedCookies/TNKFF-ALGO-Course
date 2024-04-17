using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            List<Vertex> SegmTree = new List<Vertex>();

            int pow = 0;
            while (Math.Pow(2, pow) < n)
            {
                pow++;
            }
            int len = int.Parse(Math.Pow(2, pow).ToString());
            string[] numsStr = Console.ReadLine().Split(' ');
            // fill in the part in the lowest level and indexes
            for (int i = 0; i < len * 2; i++)
            {
                SegmTree.Add(new Vertex(int.MaxValue));
                if (i > len - 2 && i < len + n - 1)
                {
                    SegmTree[i].Min = int.Parse(numsStr[i - len + 1]);
                    SegmTree[i].MinCount = 1;
                }
                // add borders
                if (i > len - 2)
                {
                    SegmTree[i].L = i - len + 1;
                    SegmTree[i].R = i - len + 1;
                }
                SegmTree[i].Ind = i;
            }

            for (int i = len - 2; i >= 0; i--)
            {
                DetMin(SegmTree, i);
            }

            for (int i = 0; i < m; i++)
            {
                string[] coms = Console.ReadLine().Split(' ');
                if (coms[0] == "1")
                {
                    Update(SegmTree, int.Parse(coms[1]), int.Parse(coms[2]), len);
                }
                else
                {
                    var ans = (GetMin(SegmTree, int.Parse(coms[1]), int.Parse(coms[2])));
                    Console.WriteLine(ans[0] + " " + ans[1]);
                }
            }
            /*foreach (var item in SegmTree)
            {
                Console.Write(item.Min + "\t\t");
            }
            Console.WriteLine();
            foreach (var item in SegmTree)
            {
                Console.Write(item.MinCount + "\t\t");
            }
            Console.WriteLine();
            foreach (var item in SegmTree)
            {
                Console.Write(item.L +" " + item.R + "\t\t");
            }
            Console.ReadLine();*/
        }

        private static void DetMin(List<Vertex> SegmTree, int i)
        {
            if (SegmTree[i * 2 + 1].Min < SegmTree[i * 2 + 2].Min)
            {
                SegmTree[i].Min = SegmTree[i * 2 + 1].Min;
                SegmTree[i].MinCount = SegmTree[i * 2 + 1].MinCount;
            }
            else if (SegmTree[i * 2 + 2].Min < SegmTree[i * 2 + 1].Min)
            {
                SegmTree[i].Min = SegmTree[i * 2 + 2].Min;
                SegmTree[i].MinCount = SegmTree[i * 2 + 2].MinCount;
            }
            else
            {
                SegmTree[i].Min = SegmTree[i * 2 + 1].Min;
                SegmTree[i].MinCount = SegmTree[i * 2 + 1].MinCount + SegmTree[i * 2 + 2].MinCount;
            }
            SegmTree[i].L = SegmTree[i * 2 + 1].L;
            SegmTree[i].R = SegmTree[i * 2 + 2].R;
        }

        public static void Update(List<Vertex> SegmTree, int ind, int newVal, int len)
        {
            var cur = SegmTree[0];
            Stack<Vertex> way = new Stack<Vertex>();
            while (cur.L != cur.R)
            {
                int mid = (cur.L + cur.R)/2;
                way.Push(cur);
                if (ind <= mid)
                {
                    cur = SegmTree[cur.Ind * 2 + 1];
                }
                else
                {
                    cur = SegmTree[cur.Ind * 2 + 2];
                }
            }

            cur.Min = newVal;

            while (way.Count > 0)
            {
                cur = way.Pop();
                DetMin(SegmTree, cur.Ind);
            }
        }

        public static List<long> GetMin(List<Vertex> SegmTree, int l, int r)
        {
            long min = int.MaxValue;
            long minCount = 0;

            Stack<Vertex> st = new Stack<Vertex>();
            st.Push(SegmTree[0]);
            while (st.Count > 0)
            {
                var cur = st.Pop();
                if (cur.L >= l && cur.R <= r - 1)
                {
                    if (cur.Min == min)
                    {
                        minCount += cur.MinCount;
                    }
                    else if (cur.Min < min)
                    {
                        min = cur.Min;
                        minCount = cur.MinCount;
                    }
                    continue;
                }

                // if it's the latest level
                if (cur.R == cur.L)
                {
                    continue;
                }

                int mid = (cur.L + cur.R) / 2;
                if (l <= mid)
                {
                    st.Push(SegmTree[cur.Ind * 2 + 1]);
                }
                if (r > mid)
                {
                    st.Push(SegmTree[cur.Ind * 2 + 2]);
                }
            }

            return (new List<long>() { min, minCount });
        }
    }

    public class Vertex
    {
        public int L { get; set; }
        public int R { get; set; }
        public long Min { get; set; }
        public long MinCount { get; set; }
        public int Ind { get; set; }
        public Vertex(long min)
        {
            Min = min;
        }
    }
}
