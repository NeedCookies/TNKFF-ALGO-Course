using System;
using System.Collections.Generic;

namespace Task4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            int res = 0;
            long bal = 0;
            long f = 1;
            for (int i = 1; i <= n; i++)
            {
                long curNum = i;
                while (curNum % 2 == 0)
                {
                    curNum = curNum / 2;
                    bal++;
                }
                while (curNum % 5 == 0)
                {
                    curNum = curNum / 5;
                    bal--;
                }
                f = f * curNum % 10;
            }
            f = f * long.Parse(Math.Pow(2, bal).ToString()) % 10;
            Console.WriteLine(f);
            return;
            if (n == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int lastNum = 1;
            for (int i = 1; i <= n; i++)
            {
                int curNum = i;
                while (curNum > 0 && curNum % 10 == 0) { curNum /= 10; }
                curNum = curNum % 10;

                lastNum = lastNum * curNum;
                while (lastNum > 0 && lastNum % 10 == 0) {lastNum /= 10; }
                lastNum = lastNum % 10;
            }
            Console.WriteLine(lastNum);
        }
    }
}