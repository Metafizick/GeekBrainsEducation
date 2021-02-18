using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите своё имя:");
            string name = Console.ReadLine();
            Console.WriteLine($"Приветствую, {name}, Сегодня { DateTime.Now }");
        }
    }
}
