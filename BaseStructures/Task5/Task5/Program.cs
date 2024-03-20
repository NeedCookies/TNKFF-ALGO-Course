using System;
using System.Collections.Generic;
using System.Text;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string[] vanNums = Console.ReadLine().Split();
            string ans = sortVans(vanNums);
            if (ans != "0")
            {
                Console.WriteLine(ans.Split(' ').Length - 1);
                Console.WriteLine(ans);
            }
            else
            {
                Console.WriteLine(0);
            }
            Console.ReadLine();
        }

        private static string sortVans(string[] vanNums)
        {
            VanStack vanStack = new VanStack();
            int maxInSorted = 0;

            StringBuilder ans = new StringBuilder();

            int inCount = 0; // кол-во в стеке на данный момент

            for (int i = 0; i < vanNums.Length - 1; i++)
            {
                var curNum = int.Parse(vanNums[i]);

                if (curNum < maxInSorted)
                    return "0";

                if (curNum < int.Parse(vanNums[i + 1])) //  && (vanStack.Count == 0 || vanStack.Peek().Number > curNum)
                {
                    if (inCount > 0) //если мы до этого момента добавляли в стек, то нужно это зафиксировать
                    {
                        ans.Append($"1 {inCount + 1}\n"); // +1 - считаем нынешний элемент, т.к. его тоже вместе заносим в стек
                        inCount = 0;
                        vanStack.Push(new Van(curNum));
                    }
                    else
                    {
                        vanStack.Push(new Van(curNum));
                        ans.Append($"1 1\n");
                    }

                    maxInSorted = Math.Max(maxInSorted, curNum);

                    var curVanInStack = vanStack.Count;
                    while (vanStack.Count > 0 && vanStack.Peek().Number < int.Parse(vanNums[i + 1]))
                    {
                        maxInSorted = Math.Max(maxInSorted, vanStack.Peek().Number);
                        vanStack.Pop();
                    }
                    var curVanInStack2 = vanStack.Count;
                    if (curVanInStack - curVanInStack2 > 0)
                        ans.Append($"2 {curVanInStack - curVanInStack2}\n");
                }
                else if (curNum > int.Parse(vanNums[i + 1]))
                {
                    vanStack.Push(new Van(curNum));
                    inCount++;
                }
            }

            ans.Append($"1 {inCount + 1}\n");

            var lastVan = int.Parse(vanNums[vanNums.Length - 1]);
            if (lastVan < maxInSorted)
                return "0";


            vanStack.Push(new Van(lastVan));
            var lastVanInStack = vanStack.Count;
            while (vanStack.Count > 0)
            {
                vanStack.Pop();                
            }
            var lastVanInStack2 = vanStack.Count;
            if (lastVanInStack - lastVanInStack2 > 0)
                ans.Append($"2 {lastVanInStack - lastVanInStack2}"); //1+ - т.к. мы еще добавили в стек последний элемент из списка
            return ans.ToString();
        }
    }

    public class VanStack
    {
        public Van Current { get; set; }
        public Van Previous { get; set; }
        public int Count { get; set; }
        public void Push(Van newVan)
        {
            newVan.previous = Current;
            Previous = Current;
            Current = newVan;
            Count++;
        }
        public Van Pop()
        {
            if (Count > 2)
            {
                Van van = Current;
                Current = Previous;
                Previous = Previous.previous;
                Count--;
                return van;
            }
            else if (Count == 2)
            {
                Van van = Current;
                Current = Previous;
                Count--;
                Previous = null;
                return van;
            }
            else if (Count == 1)
            {
                Van van = Current;
                Current = null;
                Count--;
                return Current;
            }
            else
                throw new NullReferenceException("Стек пуст");
        }

        public Van Peek()
        {
            return Current;
        }
    }

    public class Van
    {
        public int Number { get; set; }
        public Van previous { get; set; }
        public Van(int number)
        {
            Number = number;
        }
    }
}
