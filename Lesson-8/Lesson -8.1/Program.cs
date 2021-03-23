using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson__8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string greeting = Properties.Settings.Default.Greeting;
            Console.WriteLine(greeting);
            if (string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {

                Console.WriteLine("Enter name of user:");
                Properties.Settings.Default.UserName = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default.Age))
            {
                Console.WriteLine("Enter age of user:");
                Properties.Settings.Default.Age = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default.Profession))
            {
                Console.WriteLine("Enter profession of user:");
                Properties.Settings.Default.Profession = Console.ReadLine();
                Properties.Settings.Default.Save();
            }
            string userName = Properties.Settings.Default.UserName;
            string age = Properties.Settings.Default.Age;
            string profession = Properties.Settings.Default.Profession;
            Console.WriteLine($"Good day to you {userName}!\n Your age is {age} and you are {profession}");
            Console.ReadKey();
        }
    }
}
