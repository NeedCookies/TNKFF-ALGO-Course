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
            long[] hashs = new long[str.Length + 1];
            long[] hashPr = new long[str.Length + 1];
            hashs[0] = 0;
            hashPr[0] = 1;
            long Pr = 1_000_000_009;
            for (int i = 0; i < str.Length; i++)
            {
                hashs[i + 1] = hashs[i] * Pr + str[i];
                hashPr[i + 1] = hashPr[i] * Pr;
            }
            for (int i = 0; i < m; i++)
            {
                string[] nn = Console.ReadLine().Split(' ');
                int x1 = int.Parse(nn[0]);
                int x2 = int.Parse(nn[1]);
                int y1 = int.Parse(nn[2]);
                int y2 = int.Parse(nn[3]);
                long hash1 = hashs[x2] - hashs[x1 - 1] * hashPr[x2 - x1 + 1];
                long hash2 = hashs[y2] - hashs[y1 - 1] * hashPr[y2 - y1 + 1];
                if (hash1 == hash2)
                {
                    ans.Append("Yes \n");
                }
                else
                {
                    ans.Append("No\n");
                }
            }
            Console.WriteLine(ans);
            Console.ReadLine();
        }
    }
}
