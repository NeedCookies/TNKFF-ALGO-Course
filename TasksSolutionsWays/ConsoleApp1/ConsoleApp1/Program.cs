using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> points = new Dictionary<int, int>();   
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] nn = Console.ReadLine().Split(' ');
                int n1 = int.Parse(nn[0]);
                int n2 = int.Parse(nn[1]);

                if (points.ContainsKey(n1))
                {
                    points[n1] += 1;
                }
                else
                {
                    points.Add(n1, 1);
                }

                if (points.ContainsKey(n2))
                {
                    points[n2] -= 1;
                }
                else
                {
                    points.Add(n2, -1);
                }
            }

            List<int> allKeys = new List<int>();
            foreach (var t in points.Keys)
            {
                allKeys.Add(t);
            }
            allKeys.Sort();

            long count = 0;
            long depth = points[allKeys[0]];
            for (int i = 1; i < allKeys.Count; i++)
            {
                if (depth > 0)
                {
                    count += allKeys[i] - allKeys[i - 1];
                }
                depth += points[allKeys[i]];
            }

            Console.WriteLine(count);
        }
    }
}
