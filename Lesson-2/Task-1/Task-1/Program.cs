using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        enum months { 
            January=1, 
            Februry = 2, 
            March = 3,
            April = 4, 
            May = 5, 
            June = 6,
            July = 7,
            August = 8, 
            September = 9, 
            October = 10, 
            November = 11, 
            December = 12 }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ThermoMetrium!");
            bool minBool, maxBool,monBool;
            double min, max;
            int mon;
            do
             {
                 Console.Write("Please enter a minimal temperature in Celsius: ");
                 string minStr = Console.ReadLine();
                 minBool = Double.TryParse(minStr, out min);
                if (minBool == false)
                {
                    Console.WriteLine("Incorrect value of temperature. Try again");
                }
             } while (minBool == false);
            do
            {
                Console.Write("Please enter a maximum temperature in Celsius: ");
                string maxStr = Console.ReadLine();
                maxBool = Double.TryParse(maxStr, out max);
                if (maxBool == false)
                {
                    Console.WriteLine("Incorrect value of temperature. Try again");
                }
            } while (maxBool == false);
            double average = (max + min) / 2;
            Console.WriteLine($"Average temperature of the day = {average}");
            do
            {
                Console.Write("Please enter a number of current month: ");
                string monStr = Console.ReadLine();
                monBool = Int32.TryParse(monStr, out mon);
                if (monBool == false)
                {
                    Console.WriteLine("Incorrected value of number. Try again");
                }
            } while (monBool == false);
            Console.WriteLine("month is: {0}", Enum.GetName(typeof(months), mon));
            switch (mon)
            {
                case 12:
                case 1:
                case 2:
                    if (average>=0)
                    {
                        Console.WriteLine("Winter in Europa");
                    }
                    else
                    {
                        Console.WriteLine("Winter in Russia");
                    }
                    break;
                case 3:
                case 4:
                case 5:
                    if (average<=0)
                    {
                        Console.WriteLine("Abnormally cold spring");
                    }
                    else
                    {
                        Console.WriteLine("Normal spring, season of love:)");
                    }
                    break;
                case 6:
                case 7:
                case 8:
                    if (average>30)
                    {
                        Console.WriteLine("Hot summer");
                    }
                    else if (average<10)
                    {
                        Console.WriteLine("Abnormally cold summer");
                    }
                    else
                    {
                        Console.WriteLine("summer in Russia");
                    }
                    break;
                case 9:
                case 10:
                case 11:
                    if (average>15)
                    {
                        Console.WriteLine("Very good autumn!");
                    }
                    else if (average<0)
                    {
                        Console.WriteLine("Abnormally cold autumn!");
                    }
                    else
                    {
                        Console.WriteLine("Autumn in Russia");
                    }
                    break;
            }
            Console.ReadKey();
        }
    }
}