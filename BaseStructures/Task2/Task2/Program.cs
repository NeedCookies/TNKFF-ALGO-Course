using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string N_K = Console.ReadLine();
            int N = int.Parse(N_K.Split()[0]);
            int K = int.Parse(N_K.Split()[1]);
            string[] N_Seq_Str = Console.ReadLine().Split(' ');
            minNums(N, K, N_Seq_Str);
            Console.ReadLine();
        }

        private static void minNums(int N, int K, string[] nums)
        {
            List<int> deque = new List<int>();
            

            int l = 0; int r = K - 1;
            for (int i = 0; i < K; i++)
            {
                deque.Add(int.Parse(nums[i]));
                while (deque.Count > 1 && deque[deque.Count - 1] < deque[deque.Count - 2])
                {
                    deque.RemoveAt(deque.Count - 2);
                }
            }
            Console.Write(deque[0] + " ");

            for (int i = K; i < nums.Length; i++)
            {
                if (int.Parse(nums[i - K]) == deque[0])
                {
                    deque.RemoveAt(0);
                }
                deque.Add(int.Parse(nums[i]));
                while (deque.Count > 1 && deque[deque.Count - 1] < deque[deque.Count - 2])
                {
                    deque.RemoveAt(deque.Count - 2);
                }
                Console.Write(deque[0] + " ");
            }
        }
    }
}
