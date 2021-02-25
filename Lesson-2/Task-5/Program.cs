using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    class Program
    {
        [Flags]
        public enum daysOfWeek
        {
            Monday = 0b0000001,
            Tuesday = 0b0000010,
            Wednesday = 0b0000100,
            Thursday = 0b0001000,
            Friday = 0b0010000,
            Saturday = 0b0100000,
            Sunday = 0b1000000
        }
        static void Main(string[] args)
        {
            daysOfWeek office1 = daysOfWeek.Monday | daysOfWeek.Friday;
            daysOfWeek office2 = daysOfWeek.Monday | daysOfWeek.Tuesday | daysOfWeek.Wednesday | daysOfWeek.Thursday | daysOfWeek.Friday | daysOfWeek.Saturday | daysOfWeek.Sunday;
            daysOfWeek office3 = daysOfWeek.Tuesday | daysOfWeek.Wednesday | daysOfWeek.Thursday | daysOfWeek.Friday;
            string mode;
            do
            {
                Console.Write("Choose your operating mode (first, second, third)");
                mode = Console.ReadLine();
                if (mode == "first")
                {
                    Console.WriteLine($"Your workdaus will be {office1}");
                } else if (mode == "second")
                {
                    Console.WriteLine($"Your workdaus will be {office2}");
                } else if (mode == "third")
                {
                    Console.WriteLine($"Your workdaus will be {office3}");
                } else
                {
                    Console.WriteLine("Don't want to work, don't waste our time! Last try");
                }
            } while (!(mode == "first" || mode == "second" || mode == "third"));
            Console.ReadKey();
        }
    }
}
