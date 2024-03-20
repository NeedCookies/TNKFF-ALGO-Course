using System;
using System.Runtime.Remoting;
using System.Security.Cryptography;

namespace BinarySearch8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var strNums = Console.ReadLine().Split(' ');
            int[] changeNums = new int[n];
            for (int i = 0; i < n; i++)
            {
                changeNums[i] = int.Parse(strNums[i]);
            }

            int[] mas = new int[n];
            for (int i = 0; i < n; i++)
                mas[i] = 0;

            int rInd = changeNums.Length - 1;
            Console.Write(1 + " ");
            for (int i = 0; i < n; i++)
            {
                mas[changeNums[i] - 1] = 1;
                int ans = calculateSorts(mas, i + 1, ref rInd);
                Console.Write(ans + " ");
            }
            Console.ReadLine();
        }

        private static int calculateSorts(int[] nums, int onesCount, ref int r)
        {
            int sortsCount = 1;
            onesCount = onesCount - (nums.Length - r - 1);
            /*            [0 0 0 0 0 1 0 0 1 1 1]
            */
            if (onesCount == nums.Length || onesCount == 0)
                return sortsCount;
            while (onesCount > 0 && nums[r] == 1)
            {
                r--;
                onesCount--;
            }
            return sortsCount + onesCount;
            /*while (onesCount > 0 && r > l)
            {
                mid = (l + r) / 2;
                bool flag = checkIt(mid, nums);
                
                if (flag)
                {
                    return sortsCount + onesCount - (nums.Length - mid);
                }
                else
                {
                    l = mid + 1;
                    onesCount--;
                }
            }
            return sortsCount + onesCount - (nums.Length - Math.Min(l , r));*/
        }

        private static bool checkIt(int mid, int[] nums)
        {
            bool flag = true;
            for (int i = mid; i < nums.Length; i++)
            {
                if (nums[i] == 0 || nums[i - 1] == 1)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}
