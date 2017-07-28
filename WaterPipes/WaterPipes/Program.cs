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
            const int numPipes = 10;

            int[] pipes = new int[numPipes];
            Random rand = new Random();

            for (int i = 0; i < pipes.Length; i++)
            {
                pipes[i] = rand.Next(1, maxPipeHeight + 1);
            }

            Display(pipes, maxPipeHeight);

            Console.ReadKey();
        }

        static void Display(int[] pipes, int maxHeight)
        {
            for(int i = 0; i < pipes.Length; i++)
            {
                for (int j = 0; j < pipes[i]; j++)
                {
                    Console.SetCursorPosition(i, maxHeight - j);
                    Console.Write('Σ');
                }
            }
        }
    }
}
