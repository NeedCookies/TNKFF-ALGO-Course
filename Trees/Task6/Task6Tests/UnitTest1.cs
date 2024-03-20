using System.Text;
using Task6;

namespace Task6Tests
{
    [TestClass]
    public class UnitTest1
    {
        public string genTest(int N, string[] coms)
        {
            Tree t = new Tree();
            StringBuilder ans = new StringBuilder();
            int cur = 0;
            for (int i = 0; i < N; i++)
            {
                string[] com = coms[i].Split(' ');
                if (com[0] == "+")
                {
                    if (cur != 0)
                        t.Add(new Node(int.Parse(com[1]) + cur));
                    else
                        t.Add(new Node(int.Parse(com[1])));
                    cur = 0;
                }
                else
                {
                    cur = t.Get(int.Parse(com[1]));
                    ans.Append(cur + "\n");
                    cur = cur == -1 ? 0 : cur;
                }
            }
            return ans.ToString();
        }
        [TestMethod]
        public void TestMethod1()
        {
            int N = 6;
            string comsAll = "+ 1|+ 3|+ 3|? 2|+ 1|? 4";
            string[] coms = comsAll.Split('|');
            string ans = genTest(N, coms);

            Assert.AreEqual("3\n4\n", ans);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int N = 10;
            string comsAll = "+ 1|+ 3|+ 3|+ 5|? 4|? 4|+ 1|? 6|? 1|? 15";
            string[] coms = comsAll.Split('|');
            string ans = genTest(N, coms);

            Assert.AreEqual("5\n5\n6\n1\n-1\n", ans);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int N = 6;
            string comsAll = "+ 1|+ 3|+ 3|? 2|+ 1|? 4";
            string[] coms = comsAll.Split('|');
            string ans = genTest(N, coms);

            Assert.AreEqual("3\n4\n", ans);
        }
    }
}