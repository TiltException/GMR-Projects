using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterPipes
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxPipeHeight = 10;
            const int numPipes = 6;

            //int[] pipes = new int[numPipes];
            //Random rand = new Random();

            //for (int i = 0; i < pipes.Length; i++)
            //{
            //    pipes[i] = rand.Next(1, maxPipeHeight + 1);
            //}

            int[] pipes = new int[] { 6, 0, 0, 4, 5, 8};
            int[] waters = new int[numPipes];
            int waterContained = calcWaters(pipes, waters);
            Display(pipes, maxPipeHeight, waters);
            Console.SetCursorPosition(0, maxPipeHeight + 10);
            Console.WriteLine($"Water contained: {waterContained}");
            Console.ReadKey();
        }

        static int calcWaters(int[] pipes, int[] waters)
        {
            int[] tallestToLeft = new int[pipes.Length];
            int[] tallestToRight = new int[pipes.Length];

            tallestToLeft[0] = pipes[0];
            for (int i = 1; i < tallestToLeft.Length;i++)
            {
                //tallestToLeft[i] = tallestToLeft[i - 1] > pipes[i] ? tallestToLeft[i] : pipes[i];
                tallestToLeft[i] = Math.Max(tallestToLeft[i - 1], pipes[i]);
 
            }

            tallestToRight[tallestToRight.Length - 1] = pipes[pipes.Length - 1];
            for (int i = pipes.Length - 2; i >= 0; i--)
            {
                tallestToRight[i] = Math.Max(pipes[i], tallestToRight[i+1]);
            }

            int totalWater = 0;
            for (int i = 0; i < waters.Length; i++)
            {
                waters[i] = Math.Min(tallestToLeft[i], tallestToRight[i]) - pipes[i];
                totalWater += waters[i];
            }
            return totalWater;
        }

        static void Display(int[] pipes, int maxHeight, int[] waters)
        {
            for(int i = 0; i < pipes.Length; i++)
            {
                for (int ii = 0; ii < pipes[i]; ii++)
                {
                    Console.SetCursorPosition(i, maxHeight - ii);
                    Console.Write('Σ');
                }
                for (int ii = 0; ii < waters[i]; ii++)
                {
                    Console.SetCursorPosition(i, maxHeight - pipes[i] - ii);
                    Console.Write('W');
                }
            }
        }
    }
}
