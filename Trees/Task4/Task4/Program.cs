using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Heap heap = new Heap();
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                string[] com = Console.ReadLine().Split(' ');
                if (com[0] == "0")
                {
                    heap.Add(int.Parse(com[1]));
                }
                else
                {
                    var num = heap.RemoveMax();
                    ans.Append(num + "\n");
                }
            }

            Console.WriteLine(ans);
        }
    }

    public class Heap
    { 
        List<int> Nums = new List<int>();

        public void Add(int node)
        {
            Nums.Add(node);

            var currentInd = Nums.Count - 1;
            var parentInd = (currentInd - 1) / 2;

            while (Nums[parentInd] < Nums[currentInd])
            {
                var temp = Nums[parentInd];
                Nums[parentInd] = Nums[currentInd];
                Nums[currentInd] = temp;

                currentInd = parentInd;
                parentInd = (currentInd - 1) / 2;
            }
        }

        public int RemoveMax()
        {
            var maxNum = Nums[0];

            Nums[0] = Nums[Nums.Count - 1];
            var curInd = 0;
            Nums.RemoveAt(Nums.Count - 1);

            while (Nums.Count > 2 * curInd + 2 && (Nums[2 * curInd + 1] > Nums[curInd] || Nums[2 * curInd + 2] > Nums[curInd]))
            {
                if (Nums[2 * curInd + 1] > Nums[2 * curInd + 2])
                {
                    var temp = Nums[curInd];
                    Nums[curInd] = Nums[2 * curInd + 1];
                    Nums[2 * curInd + 1] = temp;
                    curInd = 2 * curInd + 1;
                }
                else
                {
                    var temp = Nums[curInd];
                    Nums[curInd] = Nums[2 * curInd + 2];
                    Nums[2 * curInd + 2] = temp;
                    curInd = 2 * curInd + 2;
                }
            }
            if ((Nums.Count > 2 * curInd + 1) && (Nums[curInd] < Nums[2 * curInd + 1]))
            {
                var temp = Nums[curInd];
                Nums[curInd] = Nums[2 * curInd + 1];
                Nums[2 * curInd + 1] = temp;
            }

            return maxNum;
        }
    }
}
