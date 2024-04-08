using System;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);
            long[,] cities = new long[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        cities[i, j] = 0;
                    }
                    else
                    {
                        cities[i, j] = int.MaxValue;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                string[] vect = Console.ReadLine().Split(' ');
                cities[int.Parse(vect[0]) - 1, int.Parse(vect[1]) - 1] = int.Parse(vect[2]);
                cities[int.Parse(vect[1]) - 1, int.Parse(vect[0]) - 1] = int.Parse(vect[2]);
            }
            FloydAlg(cities, n);
            long allMin = int.MaxValue;
            int cityNum = n + 10;
            for (int i = 0; i < n; i++)
            {
                long maxDist = 0;
                for (int j = 0; j < n; j++)
                {
                    if (cities[i, j] > maxDist)
                    {
                        maxDist = cities[i, j];
                    }
                }
                if (maxDist < allMin) 
                {
                    allMin = maxDist;
                    cityNum = i + 1;
                }
            }
            Console.WriteLine($"{cityNum}");
            Console.ReadLine();
        }

        private static void FloydAlg(long[,] gr, int size)
        {
            for (int k = 0; k < size; k++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        long cur = gr[i, k] + gr[k, j];
                        if (gr[i, j] > cur)
                        {
                            gr[i, j] = cur;
                        }
                    }
                }
            }
        }
    }
}
