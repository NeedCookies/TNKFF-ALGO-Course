
using System;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] N_K = Console.ReadLine().Split(' ');
            int N = int.Parse(N_K[0]);
            int K = int.Parse(N_K[1]);

            string[] numsStr = Console.ReadLine().Split(' ');
            int[] nums = Array.ConvertAll(numsStr, int.Parse);

            int l = 0; int r = nums[nums.Length - 1];
            int mid = 0;
            while (r - 1 > l)
            {
                int K1 = K;
                mid = (l + r) / 2;
                int last = nums[0];
                K1--;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] - last >= mid)
                    {
                        last = nums[i];
                        K1--;
                    }
                }
                if (K1 > 0)
                {
                    r = mid;
                }
                else
                {
                    l = mid;
                }
            }
            Console.WriteLine(l);
        }
    }
}
