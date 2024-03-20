using System;
using System.Collections.Generic;
using System.Text;

namespace Task5
{
    public class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Heap heap = new Heap();
            string[] numsStr = Console.ReadLine().Split(' ');
            for (int i = 0; i < N; i++)
            {
                heap.Add(int.Parse(numsStr[i]));
            }
            var ans = heap.Sort();
            Console.WriteLine(ans);
        }
    }

    public class Heap
    {
        List<int> nodes = new List<int>();

        public void Add(int node)
        {
            nodes.Add(node);

            int currInd = nodes.Count - 1;
            int parInd = (currInd - 1) / 2;

            while (nodes[currInd] < nodes[parInd])
            {
                var temp = nodes[currInd];
                nodes[currInd] = nodes[parInd];
                nodes[parInd] = temp;

                currInd = parInd;
                parInd = (currInd - 1) / 2;
            }
        }

        public int GetMin()
        {
            int minNum = nodes[0];

            nodes[0] = nodes[nodes.Count - 1];
            var curInd = 0;
            nodes.RemoveAt(nodes.Count - 1);

            while (nodes.Count > curInd * 2 + 2 && (nodes[curInd] > nodes[curInd*2 + 1] || nodes[curInd] > nodes[curInd*2 + 2]))
            {
                if (nodes[curInd*2 + 1] < nodes[curInd*2 + 2])
                {
                    var temp = nodes[curInd];
                    nodes[curInd] = nodes[curInd * 2 + 1];
                    nodes[curInd * 2 + 1] = temp;

                    curInd = curInd * 2 + 1;
                }
                else
                {
                    var temp = nodes[curInd];
                    nodes[curInd] = nodes[curInd * 2 + 2];
                    nodes[curInd * 2 + 2] = temp;

                    curInd = curInd * 2 + 2;
                }
            }
            if (nodes.Count > curInd*2 + 1 && nodes[curInd] > nodes[curInd*2 + 1])
            {
                var temp = nodes[curInd];
                nodes[curInd] = nodes[curInd * 2 + 1];
                nodes[curInd * 2 + 1] = temp;
            }

            return minNum;
        }

        public string Sort()
        {
            StringBuilder ans = new StringBuilder();

            while (nodes.Count > 0)
            {
                ans.Append(GetMin() + " ");
            }

            return ans.ToString();
        }
    }
}
