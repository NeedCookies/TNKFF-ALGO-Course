using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task2;

namespace Task2Tests
{
    [TestClass]
    public class UnitTest1
    {
        private int Res(int nodesCount, int root, string nodes)
        {
            int ans = -1;

            Tree tree1 = new Tree(nodesCount, new Node(root));
            string[] allNodes = nodes.Split('\n');
            int trueTree1 = 1;
            for (int i = 0; i < nodesCount; i++)
            {
                var l_r = allNodes[i].Split(' ');
                if (l_r[0] != "-1")
                {
                    trueTree1 *= tree1.Add(int.Parse(l_r[0]), i, 'l');
                }
                if (l_r[1] != "-1")
                {
                    trueTree1 *= tree1.Add(int.Parse(l_r[1]), i, 'r');
                }
            }
            if (trueTree1 == 1)
            {
                ans = (trueTree1 * tree1.UpdateVeights());
            }
            else
            {
                ans = (trueTree1);
            }
            return ans;
        }

        [TestMethod]
        public void isTreeAvl_Data1()
        {
            int nodesCount = 6;
            int root = 3;
            string nodes = "-1 -1\n0 2\n-1 -1\n1 4\n-1 5\n-1 -1\n";

            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 1);
        }

        [TestMethod]
        public void isTreeAvl_Data10()
        {
            int nodesCount = 8;
            int root = 4;
            string nodes = "-1 -1\n0 2\n-1 -1\n1 6\n3 -1\n-1 -1\n5 7\n-1 -1";
            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 0);
        }

        [TestMethod]
        public void isTreeAvl_Data11()
        {
            int nodesCount = 16;
            int root = 4;
            string nodes = "-1 -1\n0 2\n-1 -1\n1 6\n3 12\n-1 -1\n5 7\n-1 -1\n-1 -1\n8 -1\n9 11\n-1 -1\n" +
                "10 14\n-1 -1\n13 15\n-1 -1";
            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 1);
        }

        [TestMethod]
        public void isTreeAvl_Data12()
        {
            int nodesCount = 1;
            int root = 0;
            string nodes = "-1 -1";
            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 1);
        }

        [TestMethod]
        public void isTreeAvl_Data13()
        {
            int nodesCount = 9;
            int root = 5;
            string nodes = "-1 -1\n-1 -1\n0 1\n2 4\n-1 -1\n3 7\n-1 -1\n6 8\n-1 -1";
            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 0);
        }

        [TestMethod]
        public void isTreeAvl_Data14()
        {
            int nodesCount = 9;
            int root = 5;
            string nodes = "-1 -1\n0 2\n-1 -1\n1 4\n-1 -1\n3 7\n-1 -1\n6 8\n-1 -1";
            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 1);
        }

        [TestMethod]
        public void isTreeAvl_Data15()
        {
            int nodesCount = 5;
            int root = 0;
            string nodes = "-1 1\n-1 2\n-1 3\n-1 4\n-1 -1";
            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 0);
        }

        [TestMethod]
        public void isTreeAvl_Data16()
        {
            int nodesCount = 5;
            int root = 2;
            string nodes = "-1 -1\n0 -1\n1 3\n-1 4\n-1 -1";
            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 1);
        }


        [TestMethod]
        public void isTreeAvl_Data2()
        {
            int nodesCount = 6;
            int root = 3;
            string nodes = "-1 -1\n0 2\n-1 -1\n1 4\n5 -1\n-1 -1\n";

            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 0);
        }

        [TestMethod]
        public void isTreeAvl_Data3()
        {
            int nodesCount = 2;
            int root = 0;
            string nodes = "1 -1\n-1 -1";

            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 0);
        }

        [TestMethod]
        public void isTreeAvl_Data4()
        {
            int nodesCount = 3;
            int root = 2;
            string nodes = "-1 -1\n0 -1\n1 -1";

            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 0);
        }

        [TestMethod]
        public void isTreeAvl_Data5()
        {
            int nodesCount = 11;
            int root = 4;
            string nodes = "-1 -1\n0 -1\n1 3\n-1 -1\n2 5\n-1 7\n-1 -1\n6 8\n-1 10\n-1 -1\n9 -1";

            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 0);
        }

        [TestMethod]
        public void isTreeAvl_Data6()
        {
            int nodesCount = 11;
            int root = 5;
            string nodes = "-1 -1\n0 -1\n1 3\n-1 4\n-1 -1\n2 8\n-1 -1\n6 -1\n7 9\n-1 10\n-1 -1";

            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 1);
        }

        [TestMethod]
        public void isTreeAvl_Data7()
        {
            int nodesCount = 2;
            int root = 0;
            string nodes = "1 -1\n-1 -1";

            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 0);
        }

        [TestMethod]
        public void isTreeAvl_Data8()
        {
            int nodesCount = 2;
            int root = 1;
            string nodes = "-1 -1\n0 -1";

            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 1);
        }

        [TestMethod]
        public void isTreeAvl_Data9()
        {
            int nodesCount = 11;
            int root = 4;
            string nodes = "-1 -1\n0 -1\n1 3\n-1 -1\n2 5\n-1 7\n-1 -1\n6 8\n9 10\n-1 -1\n-1 -1";

            int ans = Res(nodesCount, root, nodes);

            Assert.AreEqual(ans, 0);
        }
    }
}
