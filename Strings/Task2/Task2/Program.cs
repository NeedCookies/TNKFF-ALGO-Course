using System;
using System.Text;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int q = int.Parse(Console.ReadLine());

            for (int i = 0; i < q; i++)
            {
                string subStr = Console.ReadLine();

                var ans = zFunc(str, subStr);

                if (ans.Length == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    int sl = ans.Split().Length - 1;
                    Console.WriteLine($"{sl} {ans}");
                }
            }
        }

        private static string zFunc(string str, string sub)
        { 
            string curStr = sub + '#' + str;

            StringBuilder ans = new StringBuilder();

            int[] z = new int[curStr.Length];
            int l = 0; int r = 0;
            for (int i = 1; i < curStr.Length; i++)
            {
                z[i] = Math.Max(0, Math.Min(r - i, z[i - l]));
                while (i + z[i] < curStr.Length && curStr[z[i]] 
                    == curStr[z[i] + i])
                {
                    z[i]++;
                }
                if (z[i] + i > r)
                {
                    l = i;
                    r = i + z[i];
                }
                if (z[i] == sub.Length)
                {
                    ans.Append((i - sub.Length - 1).ToString() + " ");
                }
            }
            return ans.ToString();
        }
    }
}
