using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] expr = Console.ReadLine().Split(' ');
            var ans = countExpr(expr);
            for (int i = 0; i < ans.Count; i++)
            {
                Console.WriteLine(ans[i]); 
            }
            Console.ReadLine();
        }

        private static List<int> countExpr(string[] expr)
        {
            List<int> nums = new List<int>();

            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] == "+" )
                {
                    var cur = nums[nums.Count - 2] + nums[nums.Count - 1];
                    nums.RemoveAt(nums.Count - 1);
                    nums.RemoveAt(nums.Count - 1);
                    nums.Add(cur);
                }
                else if (expr[i] == "-")
                {
                    var cur = nums[nums.Count - 2] - nums[nums.Count - 1];
                    nums.RemoveAt(nums.Count - 1);
                    nums.RemoveAt(nums.Count - 1);
                    nums.Add(cur);
                }
                else if (expr[i] == "*")
                {
                    var cur = nums[nums.Count - 2] * nums[nums.Count - 1];
                    nums.RemoveAt(nums.Count - 1);
                    nums.RemoveAt(nums.Count - 1);
                    nums.Add(cur);
                }
                else
                {
                    nums.Add(int.Parse(expr[i]));
                }
            }
            return nums;
        }

        private class Container
        {
            private int curSum { get; set; }
            private int curPr { get; set; } = 1;
            private int curDif { get; set; }

            public Container previous { get; set; }

            public void newValue(int val)
            {
                curSum += val;
                curPr *= val;
                curDif -= val;
            }
            public int getSum()
            {
                var sum = curSum;
                toDefault();
                return sum;
            }
            public int getPr()
            {
                var Pr = curPr;
                toDefault();
                return Pr;
            }
            public int getDif()
            {
                var dif = curDif;
                toDefault();
                return dif;
            }

            private void toDefault()
            {
                curSum = 0;
                curPr = 1;
                curDif = 0;
            }
        }
    }
}
