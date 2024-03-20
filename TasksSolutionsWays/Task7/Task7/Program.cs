using System;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int NN = N;
            int[] works = new int[3600 * 24];
            long allTime = 0;
            int night = 0;
            for (int i = 0; i < N; i++)
            {
                string[] ns = Console.ReadLine().Split(' ');
                int[] n = Array.ConvertAll(ns, int.Parse);

                int open = n[0] * 3600 + n[1] * 60 + n[2];
                int close = n[3] * 3600 + n[4] * 60 + n[5];

                if (close < open)
                {
                    works[open] += 1;
                    works[close] -= 1;
                    night += 1;
                    /*for (int k = open;k < works.Length; k++)
                    {
                        works[k] += 1;
                    }
                    for (int k = 0; k < close; k++)
                    {
                        works[k] += 1;
                    }*/
                }
                else if (close > open)
                {
                    works[open] += 1;
                    works[close] -= 1;
                }
                else
                {
                    NN -= 1;
                }
            }

            int curWork = night;
            for (int i = 0; i < works.Length; i++)
            {
                curWork += works[i];
                if (curWork >= NN)
                {
                    allTime += 1;
                }
            }

            Console.WriteLine(allTime);
            Console.ReadLine();
        }
    }
}
