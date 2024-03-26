using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string sub = Console.ReadLine();

            int ans = hashing(str, sub);
            Console.WriteLine(ans);
            Console.ReadLine();
        }

        private static int hashing(string str, string sub)
        {
            int t = 179;
            int count = 0;

            long[] strh = new long[str.Length + 1];
            strh[0] = 0;
            long[] pr = new long[str.Length + 1];
            pr[0] = 1;
            for (int i = 0; i < str.Length; i++)
            {
                strh[i + 1] = strh[i] * t + str[i]; // + ((int)str[i] - (int)'a' + 1)
                pr[i + 1] = pr[i] * t;
            }

            long[] subh = new long[sub.Length + 1];
            subh[0] = 0;
            long[] subPr = new long[sub.Length + 1];
            subPr[0] = 1;
            for (int i = 0; i < sub.Length; i++)
            {
                subh[i + 1] = subh[i] * t + sub[i]; // + ((int)sub[i] - (int)'a' + 1)
                subPr[i + 1] = subPr[i] * t;
            }

            Dictionary<long, bool> visited = new Dictionary<long, bool>();
            for (int k = 0; k < sub.Length; k++)
            {
                long curSubH = (subh[subh.Length - 1] - subh[k] * subPr[sub.Length - k]) * subPr[k] + subh[k];
                if (visited.ContainsKey(curSubH))
                {
                    continue;
                }

                for (int i = sub.Length; i <= str.Length; i++)
                {
                    long x1 = strh[i - sub.Length];
                    long x2 = pr[sub.Length];
                    long xx = x1 * x2;
                    long hash1 = strh[i] - xx;
                    if (hash1 == curSubH)
                    {
                        count++;
                    }
                }
                visited.Add(curSubH, true);
            }

            return count;
        }

        // Функция правильная, но не проходит TL
        private static int zFunc(string str, string sub)
        {
            Dictionary<string, bool> looked = new Dictionary<string, bool>();

            int count = 0;
            for (int k = 0; k < sub.Length; k++)
            {
                string curSub = sub.Substring(k) + sub.Substring(0, k);
                if (looked.ContainsKey(curSub))
                {
                    continue;
                }

                string curStr = curSub + "#" + str;

                int[] z = new int[curStr.Length];
                int l = 0; int r = 0;
                for (int i = 1; i < curStr.Length; i++)
                {
                    z[i] = Math.Max(0, Math.Min(r - i, z[i - l]));
                    while (z[i] + i < curStr.Length && curStr[z[i] + i] == curStr[z[i]])
                    {
                        z[i]++;
                    }
                    if (z[i] + i > r)
                    {
                        l = i;
                        r = i + z[i];
                    }
                }
                for (int i = 0; i < z.Length; i++)
                {
                    if (z[i] == sub.Length)
                    {
                        count++;
                    }
                }
                looked.Add(curSub, true);
            }
            return count;
        }
    }
}
