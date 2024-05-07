using System;

namespace Task1
{
    internal class Program
    {
        static int[] parents;
        static int[] mins;
        static int[] maxs;
        static int[] size;
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            parents = new int[n + 1];
            mins = new int[n + 1];
            maxs = new int[n + 1];
            size = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                parents[i] = i;
                maxs[i] = i;
                mins[i] = i;
                size[i] = 1;
            }

            for (int i = 0; i < m; i++)
            {
                string[] com = Console.ReadLine().Split();
                if (com[0][0] == 'u')
                {
                    unionSets(int.Parse(com[1]), int.Parse(com[2]));
                }
                else
                {
                    int root = findSet(int.Parse(com[1]));
                    Console.WriteLine($"{mins[root]} {maxs[root]} {size[root]}");
                }
            }
            //Console.ReadLine();
        }

        private static int findSet(int x)
        {
            if (parents[x] == x)
            {
                return x;
            }
            return parents[x] = findSet(parents[x]);
        }
        private static void unionSets(int x, int y)
        {
            x = findSet(x);
            y = findSet(y);
            if (x != y)
            {
                if (size[x] < size[y])
                {
                    joinSets(y, x);
                }
                else
                {
                    joinSets(x, y);
                }
            }
        }

        private static void joinSets(int big, int small)
        {
            parents[small] = big;
            maxs[big] = Math.Max(maxs[big], maxs[small]);
            mins[big] = Math.Min(mins[big], mins[small]);
            size[big] += size[small];
        }
    }
}
