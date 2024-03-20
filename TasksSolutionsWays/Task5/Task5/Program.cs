using System;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] n_k = Console.ReadLine().Split(' ');
            int n = int.Parse(n_k[0]);
            int k = int.Parse(n_k[1]);

            long sum = 0;
            int maxNum = 0;
            string[] s = Console.ReadLine().Split(' ');
            int[] nums = Array.ConvertAll(s, int.Parse);

            for (int i = 0; i < n; i++)
            {
                sum += nums[i];
                if (nums[i] > maxNum)
                {
                    maxNum = nums[i];
                }
            }

            long l = maxNum;
            long r = sum;
            while (l <= r)
            {
                long mid = (l + r) / 2;
                long count = 1;
                long curSum = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    if (curSum + nums[i] <= mid)
                    {
                        curSum += nums[i];
                    }
                    else
                    {
                        curSum = nums[i];
                        count++;
                    }
                }
                if (count <= k)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            Console.WriteLine(l);
        }
    }
}
