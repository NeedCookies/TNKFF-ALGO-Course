using System;
using System.Collections.Generic;
using System.Text;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deq qu = new Deq();
            int num = int.Parse(Console.ReadLine());
            StringBuilder ans = new StringBuilder();

            for (int i = 0; i < num; i++)
            {
                string[] com = Console.ReadLine().Split(' ');
                if (com[0] == "+")
                {
                    qu.Push(new Goblin(int.Parse(com[1])));
                }
                else if (com[0] == "*")
                {
                    qu.PushMid(new Goblin(int.Parse(com[1])));
                }
                else
                {
                    int gobNum = qu.PopFirst().Id;
                    ans.Append(gobNum + "\n");
                }
            }
            Console.WriteLine(ans);
        }
    }

    public class Deq
    {
        //должны уметь добавлять в конец и в середину (если элементов нечетное, то сразу за серединой)
        // вынимать последний эелемент
        public Goblin Current { get; set; }
        public Goblin Previous { get; set; }
        public int Count;

        public Goblin Middle { get; set; } // всегда добавлять за этим гоблином если привелигированный
        public Goblin Head { get; set; }

        public void Push(Goblin goblin)
        {
            if (Count > 0)
            {
                Current.next = goblin;
                goblin.previous = Current;
                Previous = Current;
                Current = goblin;

                if (Count % 2 == 0)
                {
                    Middle = Middle.next;
                }
            }
            else
            {
                Current = goblin;
                Head = Current;
                Middle = Current;
            }
            Count++;
        }

        public void PushMid(Goblin goblin)
        {
            if (Count > 0)
            {
                goblin.next = Middle.next;
                goblin.previous = Middle;

                if (Count > 1)
                {
                    Middle.next.previous = goblin;
                }
                else // т.к. когда у нас только один элемент, мы то Current указатель не обновится
                {
                    Current = goblin;
                }

                Middle.next = goblin;

                if (Count % 2 == 0)
                {
                    Middle = Middle.next;
                }
                
                Count++;
            }
            else
            {
                Current = goblin;
                Head = Current;
                Middle = Current;
                Count++;
            }
        }

        public Goblin PopFirst()
        {
            if (Count > 1)
            {
                var gob = Head;
                Head = Head.next;
                if (Count % 2 == 0)
                {
                    Middle = Middle.next;
                }
                Head.previous = null;
                Count--;
                return gob;
            }
            else if (Count == 1)
            {
                var gob = Head;
                Head = null;
                Middle = null;
                Current = null;
                Previous = null;
                Count--;
                return gob;
            }
            else
            {
                throw new NullReferenceException("Очередь пуста");
            }
        }
    }

    public class Goblin
    { 
        public int Id { get; set; }
        public Goblin previous { get; set; }
        public Goblin next { get; set; }
        public Goblin(int id)
        {
            Id = id;
        }
    }
}
