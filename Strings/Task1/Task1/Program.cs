using System;
using System.Text;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            int m = int.Parse(Console.ReadLine());

            StringBuilder ans = new StringBuilder();
            ulong[] hashs = new ulong[str.Length + 1];
            hashs[0] = 0;
            ulong t = 29;
            ulong aN = (int)'a';
            for (int i = 1; i <= str.Length; i++)
            {
                hashs[i] = hashs[i - 1] * t + ((ulong)str[i - 1] - aN);
            }
            for (int i = 0; i < m; i++)
            {
                string[] nn = Console.ReadLine().Split(' ');
                int x1 = int.Parse(nn[0]);
                int x2 = int.Parse(nn[1]);
                int y1 = int.Parse(nn[2]);
                int y2 = int.Parse(nn[3]);
                ulong hash1 = hashs[x2] - hashs[x1 - 1] * ulong.Parse(Math.Pow(t, x2 - x1 + 1).ToString());
                ulong hash2 = hashs[y2] - hashs[y1 - 1] * ulong.Parse(Math.Pow(t, y2 - y1 + 1).ToString());
                if (x2 - x1 != y2 - y1)
                {
                    ans.Append("No\n");
                    continue;
                }
                if (hash1 == hash2)
                {
                    ans.Append("Yes\n");
                }
                else
                {
                    ans.Append("No\n");
                }
            }

            Console.WriteLine(ans);
        }
    }
}
