using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n_r = Console.ReadLine().Split(' ');
            int n = int.Parse(n_r[0]);
            int r = int.Parse(n_r[1]);
            Tree tree = new Tree(n, new Node(r));

            int trueTree1 = 1;
            for (int i = 0; i < n; i++)
            {
                var l_r = Console.ReadLine().Split(' ');
                if (l_r[0] != "-1")
                {
                    trueTree1 *= tree.Add(int.Parse(l_r[0]), i, 'l');
                }
                if (l_r[1] != "-1")
                {
                    trueTree1 *= tree.Add(int.Parse(l_r[1]), i, 'r');
                }
            }
            if (trueTree1 == 1)
            {
                Console.WriteLine(trueTree1 * tree.UpdateVeights());
            }
            else
            {
                Console.WriteLine(trueTree1);
            }
        }
    }

    public class Tree
    {
        public Node Root { get; set; }
        public Node Current { get; set; }
        public Dictionary<int, Node> Nodes { get; set; }

        public int UpdateVeights()
        {
            Stack<Node> stack = new Stack<Node>();
            Dictionary<Node, bool> visited = new Dictionary<Node, bool>();
            stack.Push(Root);
            Current = Root;

            int isAvlTree = 1;
            while (stack.Count > 0)
            {
                Current = stack.Peek();
                if (Current.Left != null && !visited.ContainsKey(Current.Left))
                {
                    stack.Push(Current.Left);
                    Current = Current.Left;
                }
                else if (Current.Right != null && !visited.ContainsKey(Current.Right))
                {
                    stack.Push(Current.Right);
                    Current = Current.Right;
                }
                else
                {
                    Current = stack.Pop();
                    visited.Add(Current, true);
                    int curLeftH = Current.Left == null ? -1 : Current.Left.Height;
                    int curRightH = Current.Right == null ? -1 : Current.Right.Height;
                    Current.Height = Math.Max(curLeftH + 1, curRightH + 1);
                    if (Math.Abs(curLeftH - curRightH) > 1)
                    {
                        isAvlTree = 0;
                    }
                    /*if (stack.Count > 0 && stack.Peek().Left != null && stack.Peek().Left == Current)
                    {
                        var Current1 = stack.Pop();
                        Current1.leftCount = Current.leftCount + Current.rightCount + 1;
                        stack.Push(Current1);
                    }
                    else if (stack.Count > 0)
                    {
                        var Current1 = stack.Pop();
                        Current1.rightCount = Current.leftCount + Current.rightCount + 1;
                        stack.Push(Current1);
                    }
                    if (Math.Abs(Current.leftCount - Current.rightCount) > 1)
                    {
                        isAvlTree = 0;
                        return isAvlTree;
                    }*/
                }
            }
            return isAvlTree;
        }

        public int Add(int addNode, int toNode, char child)
        {
            Node NtoNode = Nodes[toNode];
            Node NaddNode = Nodes[addNode];
            int trueTree = 1;
       
            if (NaddNode == null)
            { 
                NaddNode = new Node(addNode);
            }
            if (NtoNode == null)
            {
                NtoNode = new Node(toNode);
            }

            if (child == 'l')
            {
                NtoNode.Left = NaddNode;
                NaddNode.Parent = NtoNode;
                if (addNode > toNode)
                {
                    trueTree = 0;
                }
            }
            else
            {
                NtoNode.Right = NaddNode;
                NaddNode.Parent = NtoNode;
                if (addNode < toNode)
                {
                    trueTree = 0;
                }
            }

            Nodes[toNode] = NtoNode;
            Nodes[addNode] = NaddNode;

            return trueTree;
        }

        public Tree(int nodesCount, Node root)
        {
            Root = root;
            Nodes = new Dictionary<int, Node>();
            for (int i = 0; i < nodesCount; i++)
            {
                Nodes.Add(i, null);
            }
            Nodes[Root.Num] = Root;
        }
    }

    public class Node
    { 
        public int Num { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }
        public int Height { get; set; }

        /*public int leftCount = 0;
        public int rightCount = 0;*/
        public Node(int num)
        {
            Num = num;
        }
    }
}
