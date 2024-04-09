using System;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            Console.WriteLine(DamLav(str1, str2));
        }

        private static int DamLav(string str1, string str2)
        {
            int[,] dp = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                dp[i, 0] = i;
            }
            for (int i = 0; i <= str2.Length; i++)
            {
                dp[0, i] = i;
            }

            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    int var1 = dp[i - 1, j] + 1;
                    int var2 = dp[i, j - 1] + 1;
                    int var3 = str1[i - 1] == str2[j - 1] ? dp[i - 1, j - 1] : dp[i - 1, j - 1] + 1;
                    int var4 = var3 + 4; //just not for using while it appear to us
                    if ((i > 1 && j > 1) && str1[i - 1] == str2[j - 2] && str1[i - 2] == str2[j - 1])
                    {
                        var4 = dp[i - 1, j - 1];
                    }
                    dp[i, j] = Math.Min(Math.Min(var1, var2), Math.Min(var3, var4));
                }
            }

            /*for (int i = 0; i <= str1.Length; i++)
            {
                for (int j = 0; j <= str2.Length; j++)
                {
                    Console.Write(dp[i, j]);
                }
                Console.WriteLine();
            }*/

            return dp[str1.Length, str2.Length];
        }
    }
}
