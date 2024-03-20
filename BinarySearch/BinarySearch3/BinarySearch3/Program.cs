using System;

namespace BinarySearch3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int low = 0; int high = n;
            string sign;
            while (low < high - 1)
            {
                int mid = (low + high) / 2;
                Console.WriteLine(mid);
                sign = Console.ReadLine();
                if (sign == "<")
                    high = mid;
                else if (sign == ">=")
                    low = mid;
            }
            Console.WriteLine(high);
            sign = Console.ReadLine();
            if (sign == "<")
            {
                Console.WriteLine($"! {low}");
            }
            else
                Console.WriteLine($"! {high}");

            Console.ReadLine();
        }
    }
}
