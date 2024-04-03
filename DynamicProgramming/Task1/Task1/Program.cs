using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string[] numsStr = Console.ReadLine().Split(' ');
            int[] nums = new int[N];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(numsStr[i]);
            }

            Console.WriteLine(findWay(nums));
            Console.ReadLine();
        }

        static int findWay(int[] nums)
        {
            if (nums.Length == 1)
            {  
                return nums[0];
            }
            if (nums.Length == 2)
            {
                return nums[1];
            }

            int[] way = new int[nums.Length];
            way[0] = nums[0];
            way[1] = nums[1];
            for (int i = 2; i < nums.Length; i++)
            {
                way[i] = Math.Min(way[i - 2] + nums[i], way[i - 1] + nums[i]);
            }
            return way[way.Length - 1];
        }
    }
}
