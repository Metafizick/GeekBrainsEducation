using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        public static int GetNumb()
        {
            bool numbool;
            int number;
            do
            {
                Console.Write("Enter a number: ");
                numbool = int.TryParse(Console.ReadLine(), out number);
                if (numbool == false)
                {
                    Console.WriteLine("Incorrected value of number. Try again");
                }
            } while (numbool == false);
            return number;
        }
        public static string SimpleNumb (int number)
        {
            int d = 0;
            string result;
            for (int i = 2; i<number; i++ )
            {
                if (number%i == 0)
                {
                    d++;
                }
            }
            if (d == 0)
            {
                result = "Simple";
                return result;
            }
            else
            {
                result = "Composite";
                return result;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Your number is: {SimpleNumb(GetNumb())}");
            Console.ReadKey();
        }
    }
}
