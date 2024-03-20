using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree myTree = new Tree();
            int N = int.Parse(Console.ReadLine());
            string[] numsStr = Console.ReadLine().Split(' ');
            StringBuilder nodesNums = new StringBuilder();
            for (int i = 0; i < numsStr.Length; i++) 
            {
                nodesNums.Append(myTree.Peek().NodeDepth + " ");
                myTree.Add(myTree.Nodes[int.Parse(numsStr[i])]);
            }
            nodesNums.Append(myTree.Peek().NodeDepth);
            Console.WriteLine(myTree.TreeHeight + " " + myTree.findDiametr());
            Console.WriteLine(nodesNums);
            Console.ReadLine();
        }
    }

    public class Tree
    {
        public Node Root { get; set; }
        public Node Current { get; set; }
        public int TreeHeight { get; set; }
        public List<Node> Nodes = new List<Node>();

        public Tree()
        {
            Root = new Node(0);
            TreeHeight = 1;
            Root.NodeDepth = 0;
            Nodes.Add(Root);
            Current = Root;
        }

        public void Add(Node parent)
        {
            Node newNode = new Node(Nodes.Count);
            newNode.parent = parent;
            newNode.NodeDepth = parent.NodeDepth + 1;
            parent.children.Add(newNode);
            Nodes.Add(newNode);
            TreeHeight = newNode.NodeDepth > TreeHeight - 1? newNode.NodeDepth : TreeHeight;
            Current = newNode;
        }

        public Node Peek()
        {
            return Current;
        }

        public int findDiametr()
        {
            var startNode = Root;
            foreach (Node node in Nodes)
            {
                if (node.NodeDepth == TreeHeight)
                {
                    startNode = node;
                    break;
                }
            }
            var fathestNode = DST(startNode);
            return fathestNode;

        }

        private int DST(Node start)
        {
            Node farthest = start;

            Dictionary<Node, bool> visited = new Dictionary<Node, bool>();
            Dictionary<Node, int> wayLength = new Dictionary<Node, int>();

            foreach (var nd in Nodes)
            {
                visited[nd] = false;
                wayLength[nd] = 0;
            }
            
            //Dictionary<Node, Node> wayToNode = new Dictionary<Node, Node>();

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var Node = queue.Dequeue();
                if (visited[Node] == false)
                {
                    foreach (Node node in Node.children)
                    {
                        if (visited[node] == false)
                        {
                            queue.Enqueue(node);
                            //wayToNode[node] = Node;
                            wayLength[node] = wayLength[Node] + 1;
                        }
                    }
                    if (Node.parent != null && visited[Node.parent] == false)
                    {
                        queue.Enqueue(Node.parent);
                        //wayToNode[Node.parent] = Node;
                        wayLength[Node.parent] = wayLength[Node] + 1;

                    }

                    farthest = wayLength[Node] > wayLength[farthest] ? Node : farthest;

                    visited[Node] = true;
                }
            }

            return wayLength[farthest];
        }

        public List<int> GetTreeNodesDepth()
        {
            List<int> ans = new List<int>();
            foreach (Node node in Nodes)
            {
                ans.Add(node.NodeDepth);
            }
            return ans;
        }
        
        
    }

    public class Node
    { 
        public int Number { get; set; }
        public int Level { get; set; }
        public List<Node> children { get; set; }
        public Node parent { get; set; }
        public int NodeDepth { get; set; }
        /*public int longestSubTree { get; set; }
        public Node farthestNode { get; set; }*/
        public Node(int num)
        {
            Number = num;
            children = new List<Node>();
        }
    }
}
