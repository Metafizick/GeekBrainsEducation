using System;

namespace Lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {

                Console.WriteLine("Введите имя пользователя:");
                Properties.Settings.Default.UserName = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            string userName = Properties.Settings.Default.UserName;
            string greeting = Properties.Settings.Default.Greeting;
            Console.WriteLine($"{greeting}, {userName}!");

        }
    }
}
