using System;
using System.Collections.Generic;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            Dictionary<int, List<int[]>> gr = new Dictionary<int, List<int[]>>();
            HeapMin minQu = new HeapMin();
            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            /*for (int i = 0; i <= n; i++)
            {
                gr.Add(i, new int[n + 1]);
                for (int j = 0; j <= n; j++)
                {
                    gr[i][j] = -1;
                }
            }*/
            for (int i = 0; i < m; i++)
            {
                string[] valStr = Console.ReadLine().Split(' ');
                int start = int.Parse(valStr[0]);
                int end = int.Parse(valStr[1]);
                int val = int.Parse(valStr[2]);

                if (!gr.ContainsKey(start))
                {
                    gr[start] = new List<int[]>();
                    
                }
                gr[start].Add(new int[2] { val, end });
                if (!gr.ContainsKey(end))
                {
                    gr[end] = new List<int[]>();
                }
                gr[end].Add(new int[2] { val, start });
            }

            int[] ans = new int[n + 1];
            for (int i = 2; i <= n; i++)
            {
                ans[i] = int.MaxValue;
            }
            minQu.Add(0, 1);
            while (minQu.Count() > 0)
            {
                var cur = minQu.PopMin();
                int v = cur[1];

                foreach (var node in gr[v])
                {
                    int to = node[1];
                    int len = node[0];
                    if (ans[v] + len < ans[to])
                    {
                        ans[to] = ans[v] + len;
                        minQu.Add(ans[to], to);
                    }
                }
                /*if (len > ans[cur[1]])
                {
                    continue;
                }
                for (var j = 1; j <= n; j++)
                {
                    int to = j;
                    int toLen = gr[cur[1]][to];
                    if (toLen >= 0 && ans[to] > ans[cur[1]] + toLen)
                    {
                        ans[to] = ans[cur[1]] + toLen;
                        minQu.Add(ans[to], to);
                    }
                }*/
            }

            for (int i = 1; i < ans.Length; i++)
            {
                Console.Write(ans[i] + " ");
            }
            Console.ReadLine();
        }
    }

    public class HeapMin
    {
        List<List<int>> heap = new List<List<int>>();

        public int Count()
        {
            return heap.Count;
        }

        public void Add(int val, int ind)
        {
            heap.Add(new List<int>() { val, ind});

            int curInd = heap.Count - 1;
            int parentInd = (curInd - 1) / 2;
            while (curInd > 0 && heap[curInd][0] < heap[parentInd][0])
            {
                Swap(curInd, parentInd);

                curInd = parentInd;
                parentInd = (parentInd - 1) / 2;
            }
        }

        public void Swap(int index1, int index2)
        {
            var tempVal = heap[index1][0];
            var tempInd = heap[index1][1];
            heap[index1][0] = heap[index2][0];
            heap[index1][1] = heap[index2][1];
            heap[index2][0] = tempVal;
            heap[index2][1] = tempInd;
        }

        public List<int> PopMin()
        {
            var result = new List<int>() { heap[0][0], heap[0][1] };
            heap[0][0] = heap[heap.Count - 1][0];
            heap[0][1] = heap[heap.Count - 1][1];
            heap.RemoveAt(heap.Count - 1);

            int curInd = 0;
            while (curInd * 2 + 2 < heap.Count)
            {
                if (heap[curInd * 2 + 1][0] < heap[curInd][0] || heap[curInd * 2 + 2][0] < heap[curInd][0])
                {
                    if (heap[curInd * 2 + 1][0] < heap[curInd * 2 + 2][0]) { Swap(curInd, curInd * 2 + 1); curInd = curInd * 2 + 1; }
                    else { Swap(curInd, curInd * 2 + 2); curInd = curInd * 2 + 2; }
                }
            }

            return result;
        }
    }
}
