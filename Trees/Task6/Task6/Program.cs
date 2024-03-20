using System;
using System.Collections.Generic;
using System.Text;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Tree t = new Tree();
            int cur = 0;
            for (int i = 0; i < N; i++)
            {
                string[] com = Console.ReadLine().Split(' ');
                if (com[0] == "+")
                {
                    if (cur != 0)
                    {
                        cur = int.Parse(((long.Parse(com[1]) + long.Parse(cur.ToString())) % Math.Pow(10, 9)).ToString());
                        t.Add(new Node(cur));
                    }
                    else
                    {
                        t.Add(new Node(int.Parse(com[1])));
                    }
                    cur = 0;
                }
                else
                {
                    cur = t.Get(int.Parse(com[1]));
                    Console.WriteLine(cur);
                    //cur = cur == -1 ? 0 : cur;
                }
            }
            Console.ReadLine();
        }
    }

    public class Tree
    { 
        public Node Root { get; set; }

        private void UpdateHeights(Node stNode)
        {
            var Current = stNode;

            while (Current.Parent != null)
            {
                Current.Parent.Height = Math.Max(Current.Parent.Height, Current.Height + 1);
                Current = Current.Parent;
            }
        }

        public void Add(Node node)
        {
            if (Root == null)
            {
                Root = node;
                return;
            }

            var Current = Root;
            while (Current != null && Current.Data != node.Data)
            {
                if (node.Data > Current.Data)
                {
                    if (Current.Right != null)
                    {
                        Current = Current.Right;
                    }
                    else
                    {
                        Current.Right = node;
                        node.Parent = Current;
                        node.Height = 0;
                        Current.Height = 0;
                        //UpdateHeights(Current);
                        break;
                    }                    
                }
                else if (node.Data < Current.Data)
                {
                    if (Current.Left != null)
                    {
                        Current = Current.Left;
                    }
                    else
                    {
                        Current.Left = node;
                        node.Parent = Current;
                        node.Height = 0;
                        Current.Height = 0;
                        //UpdateHeights(Current);
                        break;
                    }
                }
            }
        }

        public int Get(int num)
        {
            if (Root == null)
            {
                return -1;
            }
            var Current = Root;
            int ans = Current.Data;
            while ((num > Current.Data && Current.Right != null) ||
                (num < Current.Data && Current.Left != null) ||
                (num == Current.Data))
            {
                if (num == Current.Data)
                {
                    return num;
                }

                if (num > Current.Data)
                {
                    Current = Current.Right;
                    ans = Current.Data;
                }
                else
                {
                    Current = Current.Left;
                    if (Current.Data >= num && Current.Data < ans)
                    {
                        ans = Current.Data;
                    }
                }
            }
            if (ans < num)
                return -1;
            return ans;
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public int Height { get; set; }
        public Node Parent { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            Data = data;
        }
    }
}
