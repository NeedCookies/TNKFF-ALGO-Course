using System;
using System.Collections.Generic;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string[] xy1 = Console.ReadLine().Split(' ');
            int x1 = int.Parse(xy1[0]);
            int y1 = int.Parse(xy1[1]);
            string[] xy2 = Console.ReadLine().Split(' ');
            int x2 = int.Parse(xy2[0]);
            int y2 = int.Parse(xy2[1]);
            Chess ch = new Chess(N);
            var ans = ch.findWay(x1, y1, x2, y2);
            int n = ans.Split('\n').Length - 1;
            Console.WriteLine($"{n}");
            Console.Write(ans);
            Console.ReadLine();
        }
    }

    public class Chess
    {
        private int Size = 0;
        public Cell[,] Table { get; set; }

        public Chess(int N)
        {
            Table = new Cell[N + 1, N + 1];
            Size = N;
        }

        public string findWay(int x1, int y1, int x2, int y2)
        {
            int[,] visited = new int[Size + 1, Size + 1];
            
            Queue<Cell> q = new Queue<Cell>();
            Cell st = new Cell(x1, y1);
            q.Enqueue(st);
            while (q.Count > 0)
            {
                Cell curPair = q.Dequeue();
                int x = curPair.X;
                int y = curPair.Y;
                foreach (var pos in nextStep(x, y))
                {
                    if (pos[0] == x2 && pos[1] == y2)
                    {
                        if (curPair.Way != null)
                            return $"{curPair.Way}\n{curPair.X} {curPair.Y}\n{pos[0]} {pos[1]}";
                        return $"{curPair.X} {curPair.Y}\n{pos[0]} {pos[1]}";
                    }
                    if (visited[pos[0], pos[1]] == 1)
                    {
                        continue;
                    }
                    Cell nextCell = new Cell(pos[0], pos[1], curPair);
                    q.Enqueue(nextCell);
                    visited[curPair.X, curPair.Y] = 1;
                }
            }
            return null;
        }

        private List<List<int>> nextStep(int x1, int y1)
        {
            int border = int.Parse(Math.Sqrt(Table.Length).ToString());

            int[] xStep = new int[4] { 1, 2, -1, -2 };
            int[] yStep = new int[4] { 2, 1, -2, -1 };
            List<List<int>> next = new List<List<int>>();
            foreach (var x in xStep)
            {
                foreach (var y in yStep)
                {
                    if (Math.Abs(x) == Math.Abs(y))
                    {
                        continue;
                    }

                    if ((x1 + x > 0 && x1 + x < border) &&
                        (y1 + y > 0 && y1 + y < border))
                    {
                        List<int> pair = new List<int>
                        {
                            x1 + x,
                            y1 + y
                        };
                        next.Add(pair);
                    }
                }
            }
            return next;
        }
    }

    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Cell From { get; set; }

        public string Way { get; set; }

        public Cell(int x, int y, Cell from = null)
        {
            X = x;
            Y = y;
            if (from != null)
            {
                From = from;
                if (from.Way != null)
                {
                    Way = $"{from.Way}\n{from.X} {from.Y}";
                }
                else
                {
                    Way = $"{from.X} {from.Y}";
                }
            }
        }

        public Cell GetPrev()
        {
            return From;
        }
    }
}
