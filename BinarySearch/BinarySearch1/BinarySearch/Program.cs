using System;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n_k = Console.ReadLine();
            int n = int.Parse(n_k.Split(' ')[0]);
            int k = int.Parse(n_k.Split(' ')[1]);

            var mm = Console.ReadLine();
            string[] masStr = mm.Split(' ');
            int[] mas = new int[n];

            for (int i = 0; i < n; i++)
            {
                mas[i] = int.Parse(masStr[i]);
            }

            var ss = Console.ReadLine();
            string[] masStr1 = ss.Split(' ');
            int[] questions = new int[k];
            for (int i = 0; i<k; i++)
            {
                questions[i] = int.Parse(masStr1[i]);
            }

            for (int i = 0; i < k; i++)
            {
                if (binarySearch(mas, questions[i]))
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }

            Console.ReadLine();
        }

        public static bool binarySearch(int[] mas, int item)
        {
            int l = 0;
            int r = mas.Length - 1;
            
            while (r - 1 > l)
            {
                int mid = (l + r) / 2;
                if (mas[mid] == item)
                    return true;
                else if (item > mas[mid])
                    l = mid;
                else
                    r = mid;
            }
            if (mas[r - 1] == item || mas[l + 1] == item)
                return true;
            return false;
        }
    }
}
