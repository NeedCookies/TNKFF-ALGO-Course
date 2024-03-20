using System;

namespace BinarySearch4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double C = double.Parse(Console.ReadLine());
            int num = int.Parse(Math.Ceiling(Math.Sqrt(C)).ToString() + 1);

            double low = 0; double high = num;
            double Eps = 0.000001;
            double mid = 0;

            while (high - low > Eps)
            {
                mid = (high + low) / 2.0;
                double curX = equation(mid);
                if (curX - C > 0)
                    high = mid;
                else
                    low = mid;
            }
            Console.WriteLine(Math.Round(mid, 6));
        }

        private static double equation(double x)
        {
            return Math.Pow(x, 2) + Math.Sqrt(x + 1);
        }
    }
}
