using System;
using System.Collections.Generic;

namespace Task4
{
    internal class Program
    {
        static string FindLexicographicallyMinimalShift(string s)
        {
            s += s;
            int n = s.Length;

            List<int> shifts = new List<int>();
            for (int i = 0; i < n / 2; i++)
            {
                shifts.Add(i);
            }

            shifts.Sort((a, b) =>
            {
                int j = a;
                int k = b;
                for (int i = 0; i < n / 2; i++)
                {
                    if (s[j] != s[k]) return s[j] - s[k];
                    j++;
                    k++;
                }
                return 0;
            });

            return s.Substring(shifts[0], n / 2);
        }

        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string result = FindLexicographicallyMinimalShift(s);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
