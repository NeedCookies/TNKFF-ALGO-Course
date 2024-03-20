using System;
using System.Collections.Generic;
using System.Text;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deq deq = new Deq();
            int N = int.Parse(Console.ReadLine());
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                string[] coms = Console.ReadLine().Split(' ');
                if (coms[0] == "1")
                {
                    deq.Add(new Person(int.Parse(coms[1])));
                }
                else if (coms[0] == "2")
                {
                    deq.PopFirst();
                }
                else if (coms[0] == "3")
                {
                    deq.PopLast();
                }
                else if (coms[0] == "4")
                {
                    ans.Append(deq.GetPeopleBefore(int.Parse(coms[1])) + "\n");
                }
                else if (coms[0] == "5")
                {
                    ans.Append(deq.GetHead() + "\n");
                }
            }
            Console.Write(ans);
            Console.ReadLine();
        }
    }

    public class Deq
    {
        public Person Current { get; set; }
        public Person Head { get; set; }
        public Person Previous { get; set; }
        public Person Next { get; set; }
        public int Count { get; set; }

        int[] numsD = new int[1_000_000];

        public void Add(Person person)
        {
            if (Count > 0)
            {
                Current.next = person;
                person.previous = Current;
                person.NumberBefore = Current.NumberBefore + 1;
                numsD[person.Id] = Current.NumberBefore + 1;
            }
            else
            {
                person.NumberBefore = 0;
                numsD[person.Id] = 0;
            }

            
            Previous = Current;
            Current = person;
            Count++;

            if (Count == 1)
            {
                Head = Current;
            }
        }

        public void PopLast()
        {
            if (Count > 2)
            {
                Current = Previous;
                Current.next = null;
                Previous = Previous.previous;
                Count--;
            }
            else if (Count == 2)
            {
                Current = Previous;
                Current.next = null;
                Previous = null;
                Count--;
            }
            else if (Count == 1)
            {
                Current = null;
                Count--;
            }
        }

        public void PopFirst()
        {
            if (Count > 1)
            {
                Head.next.previous = null;
                Head = Head.next;
                Head.NumberBefore = 0;
                numsD[Head.Id] = 0;
                UpdateDeq();
            }
            else
            {
                Head = Head.next;
            }
            Count--;
        }

        private void UpdateDeq()
        {
            Person curPers = Head.next;
            while (curPers != null)
            {
                curPers.NumberBefore = curPers.previous.NumberBefore + 1;
                numsD[curPers.Id] = curPers.previous.NumberBefore + 1;
                curPers = curPers.next;
            }
        }

        public int GetPeopleBefore(int id)
        {
            /*Person pers = Head;
            int numBefore = 0;
            while (pers != null && pers.Id != id)
            {
                pers = pers.next;
                numBefore++;
            }*/
            return numsD[id];
        }

        public int GetHead()
        {
            return Head.Id;
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public Person previous { get; set; }
        public Person next{ get; set; }
        public int NumberBefore { get; set; }
        public Person(int id)
        {
            Id = id;
        }
    }
}
