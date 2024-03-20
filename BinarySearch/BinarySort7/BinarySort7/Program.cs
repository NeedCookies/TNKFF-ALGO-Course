using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySort7
{
    internal class Program
    {
        private static int sr = 0;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];
            for (int i = 1; i <= n; i++)
            {
                nums[i-1] = i;
            }
            antiQSort(nums);
            /*
            int n1 = n - 1;
            int num = 1;
            while (n1 > 0)
            {
                n1 = n1 / 2;
                nums[n1] = num;
                num++;
            }
            for (int i = 0; i < (n - 1) / 2; i++)
            {
                if (!(nums[i] > 0 && nums[i] < num))
                {
                    nums[i] = num;
                    num++;
                }
            }

            int n2 = (n - 1) / 2;
            while (n2 < n - 1)
            {
                n2 = (n2 + n) / 2;
                nums[n2] = num;
                num++;
            }
            for (int i = (n - 1) / 2; i < n; i++)
            {
                if (!(nums[i] > 0 && nums[i] < num))
                {
                    nums[i] = num;
                    num++;
                }
            }

            */
            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }
            
            /*//string[] strNums = Console.ReadLine().Split(' ');
            //int[] nums = new int[strNums.Length];
            for (int i = 0; i < strNums.Length; i++)
            {
                nums[i] = int.Parse(strNums[i]);
            }
            qSort(nums, 0, nums.Length - 1);
            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(sr);
            Console.ReadLine();
            */
        }

        static void antiQSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var temp = nums[i];
                nums[i] = nums[i / 2];
                nums[i / 2] = temp;
            }
        }

        private static void qSort(int[] a, int left, int right)
        {
            if (right <= left)
                return;
            int q = a[(left + right) / 2];
            int i = left;
            int j = right;

            while (i <= j)
            {
                while (a[i] < q)
                {
                    ++i;
                    sr++;
                }
                while (q < a[j])
                {
                    --j;
                    sr++;
                }
                if (i <= j)
                {
                    var temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    ++i;
                    --j;
                }
            }
            qSort(a, left, j);
            qSort(a, i, right);
        }
    }
}
