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
            int mon = EnterMonth();
            Console.WriteLine($"Your season is {FromMonthToSeasons(mon)}");
        }
        public static Int32  EnterMonth()
        {
            bool monBool;
            int mon;
            do
            {
                string monStr = Console.ReadLine();
                monBool = Int32.TryParse(monStr, out mon);
                if (monBool == false || mon > 12 || mon < 0)
                {
                    Console.WriteLine("Incorrected value of number. Try again");
                }
            } while (monBool == false || mon > 12 || mon < 0);
            return mon;
        }
        public static Seasons FromMonthToSeasons(int mon)
        {
            switch (mon)
            {
                case 1:
                case 2:
                case 12:
                    return Seasons.Winter;
                case 3:
                case 4:
                case 5:
                    return Seasons.Spring;
                case 6:
                case 7:
                case 8:
                    return Seasons.Summer;
                default:
                    return Seasons.Autumn;

            }
        }
    }
}
