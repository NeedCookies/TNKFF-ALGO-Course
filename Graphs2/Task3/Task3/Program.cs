using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            int num = 0;
            int[] parents = new int[1 + encode(n, m)];
            int[] size = new int[1 + encode(n, m)];
            
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = i;
                size[i] = 1;
            }

            int encode(int i, int j)
            {
                return i * m + j;
            }

            int findSet(int x)
            {
                if (parents[x] == x)
                {
                    return x;
                }
                return parents[x] = findSet(parents[x]);
            }

            bool unionSets(int a, int b)
            {
                a = findSet(a);
                b = findSet(b);
                if (a == b)
                {
                    return false;
                }
                if (size[a] < size[b])
                {
                    parents[a] = b;
                    size[b] += size[a];
                }
                else
                {
                    parents[b] = a;
                    size[a] += size[b];
                }
                return true;
            }

            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    int v = int.Parse(row[j]);
                    if (v == 1 && i < n - 1)
                    {
                        unionSets(encode(i, j), encode(i + 1, j));
                    }
                    else if (v == 2 && j < m - 1)
                    {
                        unionSets(encode(i, j), encode(i, j + 1));
                    }
                    else if (v == 3 && i < n - 1 && j < m - 1)
                    {
                        unionSets(encode(i, j), encode(i + 1, j));
                        unionSets(encode(i, j), encode(i, j + 1));
                    }
                }
            }
            int sum = 0;
            List<int> ansI = new List<int>();
            List<int> ansJ = new List<int>();
            List<int> ansDist = new List<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i < n - 1 && unionSets(encode(i, j), encode(i + 1, j)))
                    {
                        ansI.Add(i + 1);
                        ansJ.Add(j + 1);
                        ansDist.Add(1);
                        sum += 1;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j < m - 1 && unionSets(encode(i, j), encode(i, j + 1)))
                    {
                        ansI.Add(i + 1);
                        ansJ.Add(j + 1);
                        ansDist.Add(2);
                        sum += 2;
                    }
                }
            }

            Console.WriteLine(ansI.Count + " " + sum);
            for (int i = 0; i < ansI.Count; i++)
            {
                Console.WriteLine($"{ansI[i]} {ansJ[i]} {ansDist[i]}");
            }
            Console.ReadLine();
        }
    }
}
