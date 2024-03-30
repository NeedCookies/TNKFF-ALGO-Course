using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nn = Console.ReadLine().Split(' ');
            int n = int.Parse(nn[0]);
            int m = int.Parse(nn[1]);
            Graph gr = new Graph(n);

            for (int i = 0; i < m; i++)
            {
                string[] ss = Console.ReadLine().Split(' ');
                int node1 = int.Parse(ss[0]);
                int node2 = int.Parse(ss[1]);
                gr.Add(node1, node2);
            }

            string[] sorted = Console.ReadLine().Split(' ');
            var ans = gr.CheckTSort(sorted);
            if (ans)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }

        public class Graph
        {
            List<List<int>> nodes = new List<List<int>>();
            List<List<int>> comingNodes = new List<List<int>>();

            public Graph(int N)
            {
                for (int i = 0; i < N + 1; i++)
                {
                    nodes.Add(new List<int>());
                    comingNodes.Add(new List<int>());
                }
            }

            public void Add(int node1, int node2)
            {
                nodes[node1].Add(node2);
                comingNodes[node2].Add(node1);
            }

            public bool CheckTSort(string[] nums)
            {
                foreach (var numStr in nums)
                {
                    int num = int.Parse(numStr);
                    if (comingNodes[num].Count > 0)
                    {
                        return false;
                    }
                    foreach (var nodeTo in nodes[num])
                    {
                        comingNodes[nodeTo].Remove(num);
                    }
                }
                return true;
            }
        }
    }
}
