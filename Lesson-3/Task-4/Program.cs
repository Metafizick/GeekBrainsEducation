using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sea Fight!");
            char [,] seafight = new char[10, 10];
            for (int i =0; i<seafight.GetLength(0); i++)
            {
                for (int j=0; j<seafight.GetLength(1); j++)
                {
                    seafight[i, j] = 'o';
                }
            }
            seafight[7, 0] ='x'; 
            seafight[0,1] = 'x';
            seafight[1, 1] = 'x';
            seafight[2, 1] = 'x';
            seafight[6, 2] = 'x';
            seafight[0, 4] = 'x';
            seafight[4, 4] = 'x';
            seafight[0, 5] = 'x';
            seafight[2, 5] = 'x';
            seafight[4, 5] = 'x';
            seafight[7, 5] = 'x';
            seafight[0, 6] = 'x';
            seafight[7, 6] = 'x';
            seafight[9, 6] = 'x';
            seafight[9, 7] = 'x';
            seafight[4, 8] = 'x';
            seafight[5, 8] = 'x';
            seafight[6, 8] = 'x';
            seafight[7, 8] = 'x';
            seafight[2, 9] = 'x';
            for (int i =0; i<seafight.GetLength(0); i++)
            {
                for (int j=0; j<seafight.GetLength(1); j++)
                {
                    Console.Write($"{seafight[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
