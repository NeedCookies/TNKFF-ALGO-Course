using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack();
            
            int n = int.Parse(Console.ReadLine());

            //List<int> answers = new List<int>();
            StringBuilder answers = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string comNum = command.Split(' ')[0];
                if (comNum == "1")
                {
                    int x = int.Parse(command.Split(' ')[1]);
                    stack.Push(x);
                }
                else if (comNum == "2")
                {
                    stack.Pop();
                }
                else if (comNum == "3")
                {
                    StackItem item = stack.Peek();
                    answers.Append($"{item.currentMin}\n");
                }
            }
            Console.Write(answers);
            Console.ReadLine();

        }
    }

    public class MyStack
    {
        private StackItem previousItem;
        private StackItem currentItem;
        private int itemsCount = 0;

        public void Push(int x)
        {
            StackItem newItem = new StackItem();
            newItem.Data = x;

            if (itemsCount == 0)
            {
                newItem.currentMin = x;
                currentItem = newItem;

                itemsCount++;
            }
            else
            {
                newItem.currentMin = Math.Min(currentItem.currentMin, newItem.Data);
                newItem.previous = currentItem;

                previousItem = currentItem;
                currentItem = newItem;
                itemsCount++;
            }
        }

        public StackItem Peek()
        {
            if (currentItem != null)
                return currentItem;
            throw new NullReferenceException("Стек пустой");
        }

        public StackItem Pop()
        {
            if (itemsCount > 2)
            {
                StackItem item = currentItem;
                currentItem = previousItem;
                previousItem = previousItem.previous;
                itemsCount--;
                return item;
            }
            else if ( itemsCount == 2 )
            {
                StackItem item = currentItem;
                currentItem = previousItem;
                previousItem = null;
                itemsCount--;
                return item;
            }
            else if (itemsCount == 1)
            {
                StackItem item = currentItem;
                currentItem = null;
                itemsCount--;
                return item;
            }
            else
            { throw new NullReferenceException("Стек пустой"); }
        }

    }

    public class StackItem
    {
        public int Data { get; set; }
        public int currentMin { get; set; }
        public StackItem previous { get; set;}
        public StackItem() { }

        public StackItem(int x)
        {
            Data = x;
        }

    }
}
