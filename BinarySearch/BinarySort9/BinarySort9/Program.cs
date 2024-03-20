using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySort9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            string ans = buildMaxPal(str);
            Console.WriteLine(ans);
            Console.ReadLine();
        }

        private static string buildMaxPal(string str)
        {
            int[] dict = new int[256];
            StringBuilder palindrom = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                dict[str[i]] += 1;
            }

            for (int i = 0; i < dict.Length; i++)
            {
                if (dict[i] > 1)
                {
                    int addCount = 0;
                    while (addCount < dict[i] - 1)
                    {
                        palindrom.Append(Convert.ToChar(i));
                        addCount+= 2;
                    }
                    dict[i] -= addCount;
                }
            }

            int addedSym = 0;
            for (int i = 0; i < dict.Length; i++)
            {
                if (dict[i] > 0 && dict[i] % 2 != 0)
                {
                    palindrom.Append(Convert.ToChar(i));
                    addedSym++;
                    break;
                }
            }

            for (int i = palindrom.Length - 1 - addedSym; i >= 0; i--)
            {
                palindrom.Append(palindrom[i]);
            }

            return palindrom.ToString();
        }
    }
}
