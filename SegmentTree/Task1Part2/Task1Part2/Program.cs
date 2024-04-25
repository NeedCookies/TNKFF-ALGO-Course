using System;
using System.Collections.Generic;

namespace Task1Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            SegmentTree tr = new SegmentTree(n);
            for (int i = 0; i < m; i++)
            {
                string[] coms = Console.ReadLine().Split(' ');
                if (coms[0] == "1")
                {
                    tr.update(int.Parse(coms[1]), int.Parse(coms[2]), int.Parse(coms[3]));
                }
                else
                {
                    Console.WriteLine(tr.getMin(int.Parse(coms[1]), int.Parse(coms[2])));
                }
            }
        }
    }

    public class SegmentTree
    {
        private int _len { get; set; }
        public long[] Tree;

        private Dictionary<int, long> promises = new Dictionary<int, long>();

        public SegmentTree(int n)
        {
            _len = n;
            Tree = new long[4*n];
            build(n);
        }

        public void update(int l, int r, long val)
        {
            update(l, r, val, 0, _len, 0);
        }

        private void update(int l, int r, long val, int tl, int tr, int ind)
        {
            up(ind, tl, tr);
            if (tl >= l && tr <= r)
            {
                Tree[ind] += val;
                if (tr - tl > 1)
                {
                    promises[ind * 2 + 1] += val;
                    promises[ind * 2 + 2] += val;
                }
                return;
            }
            if (tl >= r || tr <= l)
            {
                return;
            }
            int tm = (tl + tr) / 2;
            update(l, r, val, tl, tm, ind * 2 + 1);
            update(l, r, val, tm, tr, ind * 2 + 2);
            Tree[ind] = Math.Min(Tree[ind*2 + 1], Tree[ind*2 + 2]);
            
        }

        public long getMin(int l, int r)
        {
            return getMin(l, r, 0, _len, 0);
        }

        private long getMin(int l, int r, int tl, int tr, int ind)
        {
            up(ind, tl, tr);
            if (tl >= l && tr <= r)
            {
                return Tree[ind];
            }
            if (tl >= r || tr <= l)
            {
                return long.MaxValue;
            }
            int tm = (tl + tr) / 2;
            var min1 = getMin(l, r, tl, tm, ind * 2 + 1);
            var min2 = getMin(l, r, tm, tr, ind * 2 + 2);
            return Math.Min(min1, min2);
        }

        private void up(int Ind, int l, int r)
        {
            Tree[Ind] += promises[Ind];
            if (r - l > 1)
            {
                promises[Ind * 2 + 1] += promises[Ind];
                promises[Ind * 2 + 2] += promises[Ind];
            }
            promises[Ind] = 0;
        }

        private void build(int n)
        {
            for (int i = 0; i < 4 * n; i++)
            {
                promises.Add(i, 0);
            }
        }
    }
}



/*Stack<int[]> way = new Stack<int[]>();
way.Push(new int[] {0, 0, _len});
while (way.Count > 0)
{
    int[] cur = way.Pop();  // cur - Ind, left, right
    up(cur[0], cur[1], cur[2]);
    if (cur[1] >= l && cur[2] < r)
    {
        return cur[0];
    }
    if (cur[1] >= r || cur[2] < l)
    {
        continue;
    }
    int tm = (l + r) / 2;
    way.Push(new int[] { cur[0] * 2 + 2, tm, r });
    way.Push(new int[] { cur[0] * 2 + 1, l, tm });
}
return -1;*/

/*Stack<int[]> way = new Stack<int[]>();
            way.Push(new int[] { 0, 0, n });
            while (way.Count > 0)
            {
                var cur = way.Peek();
                up(cur);
                if (cur[1] >= l && cur[2] < r)
                {
                    Tree[cur[0]] = val * (r - l + 1);
                    if (cur[2] - cur[1] > 1)
                    {
                        promises[cur[0] * 2 + 1] = promises[cur[0]];
                        promises[cur[0] * 2 + 1] = promises[cur[0]];
                    }
                    way.Pop();
                }
                if (cur[1] >= r && cur[2] < l)
                {
                    way.Pop();
                    continue;
                }
                int tm = (l + r) / 2;
                way.Push(new int[] { cur[0] * 2 + 1, tm, r });
                way.Push(new int[] { cur[0] * 2 + 2, l, tm });
            }*/
