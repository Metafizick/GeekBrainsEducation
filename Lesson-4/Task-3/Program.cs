using System;

namespace Task_3
{
    class Program
    {
        public enum Seasons
        {
            Winter, Spring, Summer, Autumn
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter a number of month");
            int a = Program.EnterMonth();
            Console.WriteLine(a);
        }
        public static Int32  EnterMonth()
        {
            bool monBool;
            int mon;
            do
            {
                Console.Write("Please enter a number of current month (1..12): ");
                string monStr = Console.ReadLine();
                monBool = Int32.TryParse(monStr, out mon);
                if (monBool == false || mon > 12 || mon < 0)
                {
                    Console.WriteLine("Incorrected value of number. Try again");
                }
            } while (monBool == false || mon > 12 || mon < 0);
            return mon;
        }
    }
}
