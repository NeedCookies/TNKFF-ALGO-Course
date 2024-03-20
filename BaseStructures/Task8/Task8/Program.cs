using System;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumStek myStack = new NumStek();
            long controlSum = 0;

            int N = int.Parse(Console.ReadLine());
            string[] numsCur = Console.ReadLine().Split(' ');
            for (int i = 0; i < numsCur.Length; i++)
            {
                myStack.Push(new Number(int.Parse(numsCur[i])));
                var prev = myStack.Previous;
                if (prev != null && (myStack.Current.prefixSum - prev.prefixSum) * myStack.Current.Data > controlSum)
                {
                    controlSum = (myStack.Current.prefixSum - prev.prefixSum) * myStack.Current.Data;
                }
                else
                {
                    controlSum = Math.Max(controlSum, myStack.Current.Data * myStack.Current.Data);
                }

                var prev1 = prev;
                var prev2 = prev1?.previous;
                while (prev2 != null && prev1 != null)
                {
                    if ((myStack.Current.prefixSum - prev2.prefixSum) * prev1.Data > controlSum)
                    {
                        controlSum = (myStack.Current.prefixSum - prev2.prefixSum) * prev1.Data;
                    }
                    prev1 = prev2;
                    prev2 = prev2?.previous;
                }
                controlSum = Math.Max(controlSum, myStack.Current.prefixSum * myStack.curMin.Data);
            }

            int count = numsCur.Length;
            while (count < N)
            {
                numsCur = Console.ReadLine().Split(' ');
                count += numsCur.Length;
                for (int i = 0; i < numsCur.Length; i++)
                {
                    myStack.Push(new Number(int.Parse(numsCur[i])));
                    var prev = myStack.Previous;
                    if (prev != null && (myStack.Current.prefixSum - prev.prefixSum) * myStack.Current.Data > controlSum)
                    {
                        controlSum = (myStack.Current.prefixSum - prev.prefixSum) * myStack.Current.Data;
                    }
                    else
                    {
                        controlSum = Math.Max(controlSum, myStack.Current.Data * myStack.Current.Data);
                    }

                    var prev1 = prev;
                    var prev2 = prev1?.previous;
                    while (prev2 != null && prev1 != null)
                    {
                        if ((myStack.Current.prefixSum - prev2.prefixSum) * prev1.Data > controlSum)
                        {
                            controlSum = (myStack.Current.prefixSum - prev2.prefixSum) * prev1.Data;
                        }
                        prev1 = prev2;
                        prev2 = prev2?.previous;
                    }
                    controlSum = Math.Max(controlSum, myStack.Current.prefixSum * myStack.curMin.Data);
                }
            }
            Console.WriteLine(controlSum);
        }
    }

    public class NumStek
    {
        public Number Current { get; set; }
        public Number Previous { get; set; }
        public Number curMin { get; set; }
        int Count = 0;

        public void Push(Number num)
        {
            if (Count > 0)
            {
                if (num.Data > Current.Data)
                {
                    num.previous = Current;
                    num.numInMas = Current.numInMas + 1;
                    num.prefixSum = Current.prefixSum + num.Data;
                    Previous = Current;
                    Current = num;
                    Count++;
                }
                else if (num.Data < curMin.Data)
                {
                    num.previous = null;
                    num.prefixSum = Current.prefixSum + num.Data;
                    num.numInMas = 1;
                    Previous = null;
                    Current = num;
                    curMin = num;
                    Count = 1;
                }
                else
                {
                    long prefSum = Current.prefixSum;
                    num.prefixSum = prefSum + num.Data;
                    while (num.Data < Current.Data && Count > 2)
                    {
                        Current = Previous;
                        Previous = Previous.previous;
                        Count--;
                    }
                    if (Count == 2 && num.Data < Current.Data)
                    {
                        Current = Previous;
                        Previous = null;
                        Count--;
                    }
                    num.previous = Current;
                    num.numInMas = Current.numInMas + 1;
                    Previous = Current;
                    Current = num;
                    Count = num.numInMas;
                }
            }
            else
            {
                num.prefixSum = num.Data;
                num.numInMas = 1;
                curMin = num;
                Current = num;
                Count++;
            }
        }

        public Number Pop()
        {
            if (Count > 2)
            {
                var num = Current;
                Current = Previous;
                Previous = Previous.previous;
                Count--;
                return num;
            }
            else if (Count == 2) 
            {
                var num = Current;
                Current = Previous;
                Previous = null;
                Count--;
                return num;
            }
            else if(Count == 1)
            {
                var num = Current;
                Current = null;
                Count--;
                return num;
            }
            throw new NullReferenceException("Стек пуст");
        }

        public Number Peek()
        {
            return Current;
        }

        public Number getMin()
        {
            return curMin;
        }
    }

    public class Number
    {
        public int Data { get; set; }
        public Number previous { get; set; }
        public long prefixSum { get; set; }
        public int numInMas { get; set; }

        public Number(int data)
        {
            Data = data;
        }
    }
}
