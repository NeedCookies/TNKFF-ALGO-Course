using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Tree mt = new Tree();
            string[] nums = Console.ReadLine().Split(' ');
            for (int i = 0; i < nums.Length; i++)
            {
                mt.Add(int.Parse(nums[i]), new Node(i + 1));
            }
            int m = int.Parse(Console.ReadLine());
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < m; i++)
            {
                bool flag = false;
                string[] nn = Console.ReadLine().Split(' ');
                List<int> n1Way = mt.GetWay(int.Parse(nn[0]));
                List<int> n2Way = mt.GetWay(int.Parse(nn[1]));
                for (int k = 0; k < Math.Min(n1Way.Count, n2Way.Count); k++)
                {
                    if (n1Way[k] != n2Way[k])
                    {
                        ans.Append(n1Way[k - 1] + "\n");
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    if (n1Way.Count < n2Way.Count)
                    {
                        ans.Append(n1Way[n1Way.Count - 1] + "\n");
                    }
                    else
                    {
                        ans.Append(n2Way[n2Way.Count - 1] + "\n");
                    }
                }

            }
            Console.WriteLine(ans.ToString());
        }
    }

    public class Tree
    {
        public Node Root { get; set; }
        public Dictionary<int, Node> Nodes { get; set; } = new Dictionary<int, Node>();
        
        public void Add(int parent, Node child)
        {
            var cur = Nodes[parent];
            cur.Children.Add(child);
            child.Parent = cur;
            foreach (var item in cur.Way)
            {
                child.Way.Add(item);
            }
            child.Way.Add(child.Num);
            Nodes[child.Num] = child;
        }

        public List<int> GetWay(int nodeNum)
        {
            var cur = Nodes[nodeNum];
            return cur.Way;
        }

        public Tree()
        {
            Root = new Node(0);
            Root.Way.Add(0);
            Nodes.Add(0, Root);
        }
    }

    public class Node
    {
        public int Num;
        public Node Parent { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();
        public List<int> Way { get; set; } = new List<int>();
        public Node(int num)
        {
            Num = num;
        }
    }
}
