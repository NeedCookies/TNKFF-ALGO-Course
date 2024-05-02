using System;
namespace Task2Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            SegmentTree sgt = new SegmentTree(n);
            for (int i = 0; i < m; i++)
            {
                string[] coms = Console.ReadLine().Split(' ');
                if (coms[0] == "1")
                {
                    sgt.assignUpd(long.Parse(coms[1]), long.Parse(coms[2]), long.Parse(coms[3]));
                }
                else if (coms[0] == "2")
                {
                    sgt.sumUpd(long.Parse(coms[1]), long.Parse(coms[2]), long.Parse(coms[3]));
                }
                else
                {
                    Console.WriteLine(sgt.getSum(long.Parse(coms[1]), long.Parse(coms[2])));
                }
            }
        }
    }

    public class SegmentTree
    {
        public int len { get; private set; }
        public long[] Tree { get; set; }
        public long[] SumProm { get; set; }
        public long[] AssignProm { get; set; }

        public SegmentTree(int n)
        {
            len = n;
            Tree = new long[len*4];
            SumProm = new long[len*4];
            AssignProm = new long[len*4];
            for (long i = 0; i < len * 4; i++)
            {
                AssignProm[i] = -1;
            }
        }

        public void sumUpd(long l, long r, long val)
        {
            sumUpd(l, r, 0, len, 0, val);
        }

        private void sumUpd(long l, long r, long tl, long tr, long ind, long val)
        {
            up(tl, tr, ind);
            if (tl >= l && tr <= r)
            {
                Tree[ind] += val * (tr - tl);
                if (tr - tl > 1)
                {
                    SumProm[ind * 2 + 1] += val;
                    SumProm[ind * 2 + 2] += val;
                }
                return;
            }
            if (tl >= r || tr <= l)
            {
                return;
            }
            long tm = (tr + tl) / 2;
            sumUpd(l, r, tl, tm, ind * 2 + 1, val);
            sumUpd(l, r, tm, tr, ind * 2 + 2, val);
            Tree[ind] = Tree[ind * 2 + 1] + Tree[ind * 2 + 2];
        }

        public void assignUpd(long l, long r, long val)
        {
            assignUpd(l, r, 0, len, val, 0);
        }

        private void assignUpd(long l, long r, long tl, long tr, long val, long ind)
        {
            up(tl, tr, ind);
            if (tl >= l && tr <= r)
            {
                Tree[ind] = val * (tr - tl);
                if (tr - tl > 1)
                {
                    SumProm[ind * 2 + 1] = 0;
                    SumProm[ind * 2 + 2] = 0;
                    AssignProm[ind * 2 + 1] = val;
                    AssignProm[ind * 2 + 2] = val;
                }
                return;
            }
            if (tl >= r || tr <= l)
            {
                return;
            }
            long tm = (tr + tl) / 2;
            assignUpd(l, r, tl, tm, val, ind * 2 + 1);
            assignUpd(l, r, tm, tr, val, ind * 2 + 2);
            Tree[ind] = Tree[ind * 2 + 1] + Tree[ind * 2 + 2];
        }

        private void up(long l, long r, long ind)
        {
            if (AssignProm[ind] != -1)
            {
                Tree[ind] = AssignProm[ind] * (r - l);
                if (r - l > 1)
                {
                    AssignProm[ind * 2 + 1] = AssignProm[ind];
                    AssignProm[ind * 2 + 2] = AssignProm[ind];
                    SumProm[ind * 2 + 1] = 0;
                    SumProm[ind * 2 + 2] = 0;
                }
                AssignProm[ind] = -1;
            }
            if (SumProm[ind] == 0)
            {
                return;
            }
            Tree[ind] += SumProm[ind] * (r - l);
            if (r - l > 1)
            {
                SumProm[ind * 2 + 1] += SumProm[ind];
                SumProm[ind * 2 + 2] += SumProm[ind];
            }
            SumProm[ind] = 0;
        }

        public long getSum(long l, long r)
        {
            return getSum(l, r, 0, len, 0);
        }

        private long getSum(long l, long r, long tl, long tr, long ind)
        {
            up(tl, tr, ind);
            if (tl >= l && tr <= r)
            {
                return Tree[ind];
            }
            if (tl >= r || tr <= l)
            {
                return 0;
            }
            long tm = (tr + tl) / 2;
            long sum1 = getSum(l, r, tl, tm, ind * 2 + 1);
            long sum2 = getSum(l, r, tm, tr, ind * 2 + 2);
            return sum1 + sum2;
        }
    }
}
