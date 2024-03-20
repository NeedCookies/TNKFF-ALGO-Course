using System;

namespace BinarySearch6
{
    internal class Program
    {
        static int inv = 0;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var strNums = Console.ReadLine().Split(' ');
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(strNums[i]);
            }
            int[] ans = mergeSort(nums);
            Console.WriteLine(inv);
            foreach(int i in ans)
            {
                Console.Write(i + " ");
            }
            Console.ReadLine();
        }

        private static int[] mergeSort(int[] nums)
        {
            if (nums.Length == 1) return nums;

            var left = new int[nums.Length / 2];
            for (int i = 0; i < left.Length; i++)
                left[i] = nums[i];
            left = mergeSort(left);

            var right = new int[nums.Length - left.Length];
            for (int i = left.Length; i < nums.Length; i++)
                right[i - left.Length] = nums[i];

            right = mergeSort(right);

            int l = 0; int r = 0;

            int[] totalItems = new int[left.Length + right.Length];
            int t = 0;
            while (l < left.Length && r < right.Length && t < totalItems.Length)
            {
                if (left[l] <= right[r])
                {
                    totalItems[t] = left[l];
                    t++;
                    l++;
                }
                else
                {
                    totalItems[t] = right[r];
                    t++;
                    r++;
                    inv += left.Length - l;
                }
            }

            while (l < left.Length && t < totalItems.Length)
            {
                totalItems[t] = left[l];
                t++;
                l++;
            }
            while (r < right.Length && t < totalItems.Length)
            {
                totalItems[t] = right[r];
                t++;
                r++;
            }

            return totalItems;
        }
/*
        private static int invCount(int[] Nums)
        {
            if (Nums.Length == 0)
                return 0;

            var left = new int[Nums.Length / 2];
            for (int i = 0; i < left.Length; i++)
                left[i] = Nums[i];
            //left = mergeSort(left);

            var right = new int[Nums.Length - left.Length];
            for (int i = left.Length; i < Nums.Length; i++)
                right[i - left.Length] = Nums[i];
            //right = mergeSort(right);

            var leftInv = invCount(left);
            var rightInv = invCount(right);
        }*/

        /*
         6 8 2 5 4 5
         */
    }
}
