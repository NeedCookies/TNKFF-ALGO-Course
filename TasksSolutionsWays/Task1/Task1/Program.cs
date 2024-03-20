using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string[] numsStr = Console.ReadLine().Split(' ');
            int[] nums = new int[N];
            long[] prefSum = new long[N + 1];
            prefSum[0] = 0;
            long[] prefXoR = new long[N + 1];
            prefXoR[0] = 0;
            for (int i = 0; i < N; i++)
            {
                nums[i] = int.Parse(numsStr[i]);
                prefSum[i + 1] = prefSum[i] + nums[i];
                prefXoR[i + 1] = prefXoR[i] ^ nums[i];
            }

            StringBuilder ans = new StringBuilder();
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] coms = Console.ReadLine().Split(' ');
                if (coms[0] == "1")
                {
                    long sumAll = prefSum[long.Parse(coms[2])];
                    long subSum = prefSum[long.Parse(coms[1]) - 1];
                    ans.Append((sumAll - subSum) + "\n");
                }
                else
                {
                    int n1 = int.Parse(coms[1]);
                    int n2 = int.Parse(coms[2]);
                    long xor = prefXoR[n1 - 1] ^ prefXoR[n2];
                    ans.Append(xor + "\n");
                }
            }
            Console.WriteLine(ans);

            Console.ReadLine();
        }
    }
}
