using System;
using System.IO;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string date = Convert.ToString(DateTime.Now);
            File.WriteAllText("startup.txt", date);
            Console.WriteLine(File.ReadAllText("startup.txt"));
        }
    }
}
