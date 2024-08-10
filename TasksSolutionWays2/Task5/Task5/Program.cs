using System;
using System.Collections.Generic;

namespace Task5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int n = str.Length;
            if (n <= 4) { Console.WriteLine(str); return; }

            string[,] packed = new string[n, n];
            for (int d = 1; d <= n; d++)
            {
                for (int i = 0; i < n - d + 1; i++) //i - represents left border
                {
                    string curStr = str.Substring(i, d);
                    int right = i + d - 1;
                    if (d <= 4)
                    {
                        packed[i, right] = curStr;
                        continue;
                    }

                    
                    for (int r2 = i; r2 < right; r2++)
                    {
                        string curMin = packed[i, r2] + packed[r2 + 1, right];
                        if (curMin.Length < curStr.Length) { curStr = curMin; }
                    }

                    for (int p = 1; p < d; p++)
                    {
                        if (d % p != 0)
                            continue;
                        bool isTrueSeq = true;
                        for (int k = i + p; k <= right; k++)
                        {
                            if (str[k] != str[k - p])
                            {
                                isTrueSeq = false;
                                break;
                            }
                        }
                        if (isTrueSeq)
                        {
                            string curMin = (d/p).ToString() + "(" + packed[i, i + p - 1] + ")";
                            if (curMin.Length < curStr.Length) { curStr = curMin; }
                        }
                    }

                    packed[i, right] = curStr;
                }
            }
            Console.WriteLine(packed[0, n - 1]);
        }
    }
}