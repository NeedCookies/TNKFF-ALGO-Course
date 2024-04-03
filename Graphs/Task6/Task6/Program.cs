using System;
using System.Collections.Generic;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Graph gr = new Graph();
            for (int i = 0; i < N; i++)
            {
                string[] ss = Console.ReadLine().Split(' ');
                string subst1 = ss[0]; //.Substring(0, ss.IndexOf('-') - 1)
                string subst2 = ss[2]; //.Substring(ss.IndexOf('>') + 2)
                gr.Add(subst1, subst2);
            }
            string begin = Console.ReadLine();
            string fin = Console.ReadLine();
            Console.WriteLine(gr.findWay(begin, fin));
            Console.ReadLine();
        }
    }

    public class Graph
    {
        Dictionary<long, List<Vertex>> substs = new Dictionary<long, List<Vertex>>();
        Dictionary<long, Vertex> vertexes = new Dictionary<long, Vertex>();
        
        public Graph()
        {

        }

        public void Add(string subst1, string subst2)
        {
            long h1 = subst1.GetHashCode();
            long h2 = subst2.GetHashCode();
            Vertex v1 = vertexes.ContainsKey(h1) ? vertexes[h1] : new Vertex(h1);
            Vertex v2 = vertexes.ContainsKey(h2) ? vertexes[h2] : new Vertex(h2);
            if (!vertexes.ContainsKey(h1))
            {
                vertexes.Add(h1, v1);
            }
            if (!vertexes.ContainsKey(h2))
            {
                vertexes.Add(h2, v2);
            }
            if (!substs.ContainsKey(h1))
            {
                substs.Add(h1, new List<Vertex> { v2 });
            }
            else
            {
                substs[h1].Add( v2 );
            }
        }

        public int findWay(string start, string end)
        {

            int res = -1;
            long hash1 = start.GetHashCode();
            long hash2 = end.GetHashCode();
            if ((!vertexes.ContainsKey(hash1)) || (!vertexes.ContainsKey(hash2)))
            {
                return res;
            }
            Vertex st = vertexes[hash1];
            Dictionary<long, bool> visited = new Dictionary<long, bool>();
            Dictionary<long, bool> inQu = new Dictionary<long, bool>();
            Queue<Vertex> q = new Queue<Vertex>();
            
            st.Level = 0;
            q.Enqueue(st);
            
            while (q.Count > 0)
            {
                Vertex cur = q.Dequeue();
                if (visited.ContainsKey(cur.Data))
                {
                    continue;
                }
                visited.Add(cur.Data, true);
                if (!substs.ContainsKey(cur.Data))
                {
                    continue;
                }
                foreach (var nextSub in substs[cur.Data])
                {
                    if (nextSub.Data == hash2)
                    {
                        return cur.Level + 1;
                    }
                    if (visited.ContainsKey(nextSub.Data) || inQu.ContainsKey(nextSub.Data))
                    {
                        continue;
                    }
                    nextSub.Level = cur.Level + 1;
                    q.Enqueue(nextSub);
                    inQu.Add(nextSub.Data, true);
                }
            }

            return res;
        }
    }

    public class Vertex
    { 
        public long Data { get; set; }
        public int Level { get; set; }
        public Vertex(long data)
        {
            Data = data;
        }
    }
}
