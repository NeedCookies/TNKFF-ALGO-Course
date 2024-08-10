using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;

namespace Task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());
            List<long> dels = new List<long>();
            List<int> count = new List<int>();
            for (int i = 2; i < Math.Ceiling(Math.Sqrt(n)) + 1; i++)
            {
                int c = 0;
                while (n % i == 0)
                {
                    if (dels.Count == 0) { dels.Add(i); }
                    else if (dels[dels.Count - 1] != i) { dels.Add(i); }
                    n /= i;
                    c++;
                }
                if (c > 0) { count.Add(c); }
            }
            if (n > 1)
            {
                dels.Add(n);
                count.Add(1);
            }

            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < dels.Count; i++)
            {
                if (count[i] > 1)
                {
                    ans.Append($"{dels[i]}^{count[i]}");
                }
                else
                {
                    ans.Append(dels[i]);
                }
                ans.Append("*");
            }

            Console.WriteLine(ans.ToString().Substring(0, ans.Length - 1));
        }
    }
}