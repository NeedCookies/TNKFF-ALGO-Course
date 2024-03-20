using System;

namespace BinarySearch5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a_b_c_d = Console.ReadLine();
            int a = int.Parse(a_b_c_d.Split(' ')[0]);
            int b = int.Parse(a_b_c_d.Split(' ')[1]);
            int c = int.Parse(a_b_c_d.Split(' ')[2]);
            int d = int.Parse(a_b_c_d.Split(' ')[3]);

            decimal low = -1100; decimal high = 1100;
            decimal Eps = 0.0000001M;
            decimal mid = 0;

            if (b + c + d == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (a > 0)
                {
                    while (high - low > Eps)
                    {
                        mid = (high + low) / 2;
                        decimal ans = (root(a, b, c, d, mid));
                        if (ans > 0)
                            high = mid;
                        else if (ans < 0)
                            low = mid;
                        else break;
                    }
                    Console.WriteLine(Math.Round(mid, 6));
                }
                else
                {
                    while (high - low > Eps)
                    {
                        mid = (high + low) / 2;
                        decimal ans = (root(a, b, c, d, mid));
                        if (ans > 0)
                            low = mid;
                        else if (ans < 0)
                            high = mid;
                        else break;
                    }
                    Console.WriteLine(Math.Round(mid, 6));
                }
            }
            Console.ReadLine();
        }

        private static decimal root(int a, int b, int c, int d, decimal x)
        {
            return a * (x*x*x) + b * (x*x) + c * x + d;
        }
    }
}
