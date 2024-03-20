using System;
using System.ComponentModel;

namespace BinarySearch2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n_k = Console.ReadLine();
            int n = int.Parse(n_k.Split(' ')[0]);
            int k = int.Parse(n_k.Split(' ')[1]);

            var strNums = Console.ReadLine();
            var masNums = strNums.Split(' ');
            int[] masN = new int[n];
            for (int i = 0; i < n; i++)
            {
                masN[i] = int.Parse(masNums[i]);
            }

            var strq = Console.ReadLine();
            var masQuest = strq.Split(' ');
            int[] masQ = new int[k];
            for (int i = 0; i < k; i++)
            {
                masQ[i] = int.Parse(masQuest[i]);
            }

            foreach (int item in masQ)
            {
                Console.WriteLine(binarySearch(masN, item));
            }
            Console.ReadLine();
        }

        public static int binarySearch(int[] n, int kn)
        {
            if (kn <= n[0])
                return n[0];
            if (kn >= n[n.Length - 1])
                return n[n.Length - 1];

            int l = 0; int r = n.Length - 1;

            /*while (l <= r)
            {
                int mid = (l + r) / 2;

                if (kn < n[mid])
                    r = mid - 1;
                else if (kn > n[mid])
                    l = mid + 1;
                else
                    return n[mid];
            }*/

            while (r - l > 1)
            {
                int mid = (l + r) / 2;
                if (kn == n[mid]) { return kn; }
                else if (kn > n[mid])
                {
                    l = mid;
                }
                else
                {
                    r = mid;
                }
            }

            if (Math.Abs(kn - n[r]) < Math.Abs(kn - n[l]) )
                return n[r];
            else 
                return n[l];
        }
    }
}
