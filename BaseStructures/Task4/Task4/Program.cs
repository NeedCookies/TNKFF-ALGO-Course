using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string[] balls = Console.ReadLine().Split(' ');
            var ans = delBallsCount(balls);
            Console.WriteLine(ans);
            Console.ReadLine();
        }

        private static int delBallsCount(string[] balls)
        {
            BallsStack ballsStack = new BallsStack();
            int delsCount = 0;
            
            for (int i = 0; i < balls.Length; i++)
            {
                Ball newBall = new Ball(int.Parse(balls[i]));
                if (ballsStack.Count > 0 && newBall.Color == ballsStack.Peek().Color)
                {
                    ballsStack.Push(newBall);
                }
                else
                {
                    if (ballsStack.Count > 0 && ballsStack.Peek().PreviousSimCount >= 3)
                    {
                        while (ballsStack.Count > 0 && ballsStack.Peek().PreviousSimCount > 1)
                        {
                            ballsStack.Pop();
                            delsCount++;
                        }
                        ballsStack.Pop();
                        delsCount++;
                        ballsStack.Push(newBall);
                    }
                    else
                    {
                        ballsStack.Push(newBall);
                    }
                }
            }
            if (ballsStack.Count > 0 && ballsStack.Peek().PreviousSimCount >= 3)
            {
                while (ballsStack.Count > 0 && ballsStack.Peek().PreviousSimCount > 1)
                {
                    ballsStack.Pop();
                    delsCount++;
                }
                ballsStack.Pop();
                delsCount++;
            }
            return delsCount;
        }
    }

    public class BallsStack
    {
        public Ball current { get; set; }
        public Ball previous { get; set; }
        public int Count = 0;

        public void Push(Ball newBall)
        {
            newBall.Previous = current;
            if (newBall.Color == current?.Color)
            {
                newBall.PreviousSimCount = current.PreviousSimCount + 1;
            }
            else
            {
                newBall.PreviousSimCount = 1;
            }
            previous = current;
            current = newBall;
            Count++;
        }

        public Ball Pop()
        {
            if (Count > 2)
            {
                Ball ball = current;
                current = previous;
                previous = previous.Previous;
                Count--;
                return ball;
            }
            else if (Count == 2)
            {
                Ball ball = current;
                current = previous;
                previous = null;
                Count--;
                return ball;
            }
            else if (Count == 1)
            {
                Ball ball = current;
                current = null;
                return ball;
            }
            else
            {
                throw new NullReferenceException("Стек пуст");
            }
        }

        public Ball Peek()
        {
            if ( Count > 0)
            {
                return current;
            }
            else
            {
                throw new NullReferenceException("Стек пуст");
            }
        }
    }

    public class Ball
    {
        public int Color { get; set; }
        public int PreviousSimCount { get; set; }
        public Ball Previous { get; set; }
        public Ball(int color)
        {
            Color = color;
        }
    }
}
