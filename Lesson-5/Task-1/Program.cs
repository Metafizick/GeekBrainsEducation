using System;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, write something, please");
            File.WriteAllText("textFile.txt", Console.ReadLine());
            string text = File.ReadAllText("textFile");
            Console.WriteLine(text);
        }
    }
}
