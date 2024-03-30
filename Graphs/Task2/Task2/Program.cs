using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nn = Console.ReadLine().Split(' ');
            int vC = int.Parse(nn[0]);
            int edC = int.Parse(nn[1]);
            Graph gr = new Graph(vC);
            for (int i = 0; i < edC; i++)
            {
                string[] n1n2 = Console.ReadLine().Split(' ');
                int n1 = int.Parse(n1n2[0]);
                int n2 = int.Parse(n1n2[1]);
                gr.AddEdge(n1, n2);
            }
            int ans = gr.isCycle();
            Console.WriteLine(ans);
            Console.ReadLine();
        }

        public class Graph
        {
            List<List<int>> nodes { get; set; } = new List<List<int>>();

            public Graph(int N)
            {
                for (int i = 0; i <= N; i++)
                    nodes.Add(new List<int>());
            }

            public void AddEdge(int node1, int node2)
            {
                nodes[node1].Add(node2);
            }

            public int isCycle()
            {
                Dictionary<int, bool> isWatching = new Dictionary<int, bool>(); // false - watched, true - watching, if None - haven't cheeched yet
                for (int v = 1; v < nodes.Count; v++)
                {
                    if (isWatching.ContainsKey(v))
                    {
                        continue;
                    }

                    Stack<int> st = new Stack<int>();
                    st.Push(v);
                    while (st.Count > 0)
                    {
                        int cur = st.Pop();
                        if (!isWatching.ContainsKey(cur))
                        {
                            isWatching.Add(cur, true);
                        }
                        else if (isWatching[cur] == false)
                        {
                            continue;
                        }

                        bool flag = false; // if all children checken or there're no children = true
                        foreach (var neigh in nodes[cur])
                        {
                            if (!isWatching.ContainsKey(neigh))
                            {
                                st.Push(cur);
                                st.Push(neigh);
                                flag = true;
                            }
                            else if (isWatching[neigh] == true)
                            {
                                return 1;
                            }
                        }
                        if (!flag)
                        {
                            isWatching[cur] = false;
                        }
                    }
                    isWatching[v] = false;
                }
                return 0;
            }
        }
    }
}
