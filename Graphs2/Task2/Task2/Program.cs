using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        static long[] parents;
        static long[] size;
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            List<Node> set = new List<Node>();
            for (int i = 0; i < m; i++)
            {
                string[] nodeData = Console.ReadLine().Split(' ');
                int st = int.Parse(nodeData[0]);
                int end = int.Parse(nodeData[1]);
                int val = int.Parse(nodeData[2]);
                set.Add(new Node(st, end, val));
            }

            set.Sort();

            parents = new long[n+1];
            size = new long[n+1];
            for (int i = 1; i <= n; i++)
            {
                parents[i] = i;
                size[i] = 1;
            }
            long sum = 0;

            foreach (var item in set)
            {
                if (findSet(item.Start) != findSet(item.End))
                {
                    unionSets(item.Start, item.End);
                    sum += item.Val;
                }
            }
            Console.WriteLine(sum);
            //Console.ReadLine();
        }

        private static long findSet(long x)
        {
            if (parents[x] == x)
            {
                return x;
            }
            return parents[x] = findSet(parents[x]);
        }

        private static void unionSets(long a, long b)
        {
            a = findSet(a);
            b = findSet(b);
            if (a != b)
            {
                if (size[a] < size[b])
                {
                    joinSets(b, a);
                }
                else
                {
                    joinSets(a, b);
                }
            }
        }

        private static void joinSets(long big, long small)
        {
            parents[small] = big;
            size[big] += size[small];
        }
    }

    public class Node : IComparable<Node>
    {
        public long Val { get; set; }
        public long Start { get; set; }
        public long End { get; set; }

        public Node(int start, int end, int val)
        {
            Val = val;
            Start = start;
            End = end;
        }

        int IComparable<Node>.CompareTo(Node other)
        {
            if (other == null) return -1;
            else
            {
                return Val.CompareTo(other.Val);
            }
        }
    }
}
