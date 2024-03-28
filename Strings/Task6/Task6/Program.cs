using System;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int p = 179;
            long ans = findPals(str, p);
            Console.WriteLine(ans);
            Console.ReadLine();
        }

        private static long findPals(string str, int p)
        {
            int n = str.Length;

            long[] h = new long[str.Length + 1];
            long[] rh = new long[str.Length + 1];
            rh[str.Length] = 0;
            long[] pow = new long[str.Length + 1];
            h[0] = 0;
            pow[0] = 1;

            long Mod = 9_223_372_036_854_775_807;
            for (int i = 1; i <= str.Length; i++)
            {
                pow[i] = (pow[i - 1] * p) % Mod;
                h[i] = (h[i - 1] + (str[i - 1]) * pow[i - 1]) % Mod; // - 'a' + 1
                rh[str.Length - i] = (rh[str.Length - i + 1] + (str[str.Length - i]) * pow[i - 1]) % Mod; // - 'a' + 1
            }

            long[] oddCount = new long[n];
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                int l = 1; int r = Math.Min(i + 1, n - i);
                while (l <= r)
                {
                    int mid = (l + r) / 2;
                    if (isPalindr(h, rh, pow, i - mid + 1, i + mid - 1))
                    {
                        oddCount[i] = mid;
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
                sum += oddCount[i];
            }

            long[] evenCount = new long[n];
            for (int i = 0; i < n; i++)
            {
                int l = 1; int r = Math.Min(i, n - i);
                while (l <= r)
                {
                    int mid = (l + r) / 2;
                    if (isPalindr(h, rh, pow, i - mid, i + mid - 1))
                    {
                        evenCount[i] = mid;
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
                sum += evenCount[i];
            }
            return sum;
        }

        private static long getHash(long[] h, int L, int R)
        {
            long res = h[R + 1];
            if (L > 0) res -= h[L];
            return res;
        }

        private static long getRevHash(long[] rh, int L, int R)
        {
            long res = rh[L];
            if (R < rh.Length - 1) res -= rh[R + 1];
            return res;
        }

        private static bool isPalindr(long[] h, long[] rh, long[] pow, int L, int R)
        {
            long h1 = getHash(h, L, R) * pow[h.Length - R - 1];
            long h2 = getRevHash(rh, L, R) * pow[L + 1];
            return h1 == h2;
        }
    }
}
