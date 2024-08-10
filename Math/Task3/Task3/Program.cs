using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i < n; i++)
            {
                if (isSimple(i) && isSimple(n - i))
                {
                    if (i < n/2) { Console.WriteLine($"{i} {n - i}"); }
                    else { Console.WriteLine($"{n - i} {i}"); }
                    break;
                }
            }
        }

        private static bool isSimple(int n)
        {
            for (int i = 2; i < Math.Sqrt(n) + 3; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}