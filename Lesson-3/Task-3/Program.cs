using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "Hello";
            Console.Write($"{word} inverted is ");
            for (int i = word.Length-1; i>=0; i--)
            {
                Console.Write(word[i]);
            }
            Console.ReadKey();
        }
    }
}
