using System;
using System.Collections.Generic;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sub = Console.ReadLine();
            string str = Console.ReadLine();

            var ans = findSubs(sub, str);
            long count = ans.Length;
            Console.WriteLine(count);
            foreach (var item in ans)
            {
                Console.Write($"{item} ");
            }
        }

        private static bool cmp_str(string a, string b)
        {
            bool flag = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    if (flag)
                        flag = false;
                    else
                        return false;
                }
            }
            return true;
        }

        private static long[] findSubs(string sub, string str)
        {
            List<long> ans = new List<long>();


            for (int i = 0; i < str.Length - sub.Length + 1; i++)
            {
                bool fl = cmp_str(sub, str.Substring(i, sub.Length));
                if (fl)
                {
                    ans.Add(i + 1);
                }
            }
            return ans.ToArray();
        }
    }
}
