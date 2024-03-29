using System;
using System.Collections.Generic;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] N_M = Console.ReadLine().Split(' ');
            int N = int.Parse(N_M[0]);
            int M = int.Parse(N_M[1]);

            Graph gr = new Graph(N);

            for (int i = 0; i < M; i++)
            {
                string[] nn = Console.ReadLine().Split(' ');
                int n1 = int.Parse(nn[0]);
                int n2 = int.Parse(nn[1]);
                gr.AddEdge(n1, n2);
            }
            var ans = gr.calcComp();
            Console.WriteLine(ans.Count);
            for (int i = 0; i < ans.Count; i++)
            {
                Console.WriteLine(ans[i].Count);
                ans[i].Sort();
                foreach (var item in ans[i])
                {
                    Console.Write($"{item} ");
                }
                Console.Write("\n");
            }
            Console.ReadLine();
        }
    }

    public class Graph
    {
        List<List<int>> nodes { get; set; } = new List<List<int>>();

        public Graph(int N)
        {
            for (int i = 0; i <= N; i++)
            {
                nodes.Add(new List<int>());
            }
        }

        public void AddEdge(int Node1, int Node2)
        {
            nodes[Node1].Add(Node2);
            nodes[Node2].Add(Node1);
        }

        public List<List<int>> getAll()
        {
            return nodes;
        }

        public List<List<int>> calcComp()
        {
            List<List<int>> comps = new List<List<int>>();

            Queue<int> q = new Queue<int>();

            Dictionary<int, bool> visited = new Dictionary<int, bool>();

            for (int i = 1; i < nodes.Count; i++) 
            {
                int st = i;
                if (visited.ContainsKey(st))
                {
                    continue;
                }
                q.Enqueue(st);
                comps.Add(new List<int>());
                while (q.Count > 0)
                {
                    int cur = q.Dequeue();
                    if (visited.ContainsKey(cur))
                    {
                        continue;
                    }
                    comps[comps.Count - 1].Add(cur);
                    visited.Add(cur, true);
                    foreach (var node in nodes[cur])
                    {
                        if (!visited.ContainsKey(node))
                        {
                            q.Enqueue(node);
                        }
                    }
                }
            }

            return comps;
        }
    }
}
