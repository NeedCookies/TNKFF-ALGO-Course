using System;
using System.Text;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] N_M_K = Console.ReadLine().Split(' ');
            int N = int.Parse(N_M_K[0]);
            int M = int.Parse(N_M_K[1]);
            int K = int.Parse(N_M_K[2]);

            long[][] prefixSum = new long[N + 1][];
            prefixSum[0] = new long[M + 1];
            for (int i = 0; i < M; i++)
            {
                prefixSum[0][i] = 0;
            }

            for (int i = 1; i <= N; i++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int curStrSum = 0;
                prefixSum[i] = new long[M + 1];
                prefixSum[i][0] = 0;
                for (int j = 1; j <= M; j++)
                {
                    int num = int.Parse(nums[j - 1]);
                    curStrSum += num;
                    prefixSum[i][j] = prefixSum[i - 1][j] + curStrSum;
                }
            }

            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < K; i++)
            {
                string[] x1_x2_y1_y2 = Console.ReadLine().Split(' ');

                int y1 = int.Parse(x1_x2_y1_y2[0]);
                int x1 = int.Parse(x1_x2_y1_y2[1]);
                int y2 = int.Parse(x1_x2_y1_y2[2]);
                int x2 = int.Parse(x1_x2_y1_y2[3]);
                long sumAll = prefixSum[y2][x2];
                long sumLeft = prefixSum[y2][x1 - 1];
                long sumUp = prefixSum[y1 - 1][x2];
                long restSum = prefixSum[y1 - 1][x1 - 1];
                long sum = sumAll - sumLeft - sumUp + restSum;
                ans.Append(sum + "\n");
            }

            Console.WriteLine(ans);
        }
    }
}
