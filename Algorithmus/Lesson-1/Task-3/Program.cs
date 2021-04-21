using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int number = EntNumb();
            int fibNumberRec;
            int fibNumberFor;
            if (number >= 0)
            {
                fibNumberRec = FibonacciRecPos(number);
                fibNumberFor = FibonacciForPos(number);
            }
            else
            {
                fibNumberRec = FibonacciRecNeg(number);
                fibNumberFor = FibonacciForNeg(number);
            }

            Console.WriteLine($"Fibonacci number from {number} = {fibNumberRec} with Recursion and {fibNumberFor} with For cycle");
            Console.ReadKey();

        }
        public static int EntNumb()
        {
            bool numBool;
            int num;
            do
            {
                Console.WriteLine("Please, enter number");
                numBool = Int32.TryParse(Console.ReadLine(), out num);
                if (numBool == false)
                {
                    Console.WriteLine("Incorrected value of number. Try again");
                }
            }
            while (numBool == false);
            return num;
        }
        public static int FibonacciRecPos(int numb)
        {
            if (numb == 0)
            {
                return 0;
            }
            else if (numb == 1)
            {
                return 1;
            }
            return FibonacciRecPos(numb - 2) + FibonacciRecPos(numb - 1);
        }
        public static int FibonacciRecNeg(int numb)
        {
            if (numb == -1)
            {
                return -1;
            }
            else if (numb == -2)
            {
                return -1;
            }
            return FibonacciRecNeg(numb + 2) + FibonacciRecNeg(numb + 1);
        }
        public static int FibonacciForPos(int numb)
        {
            int a0 = 0;
            int a1 = 1;
            int t = a1;
            for (int i = 1; i<numb; i++ )
            {
                t = a0 + a1;
                a0 = a1;
                a1 = t;
            }
            
           switch (numb)
           {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return t;              
           };
        }
        public static int FibonacciForNeg(int numb)
        {
            int a0 = - 1;
            int a1 = - 1;
            int t = a1;
            for (int i = - 2; i > numb; i--)
            {
                t = a0 + a1;
                a0 = a1;
                a1 = t;
            }

            switch (numb)
            {
                case -1 :
                    return -1;
                case -2 :
                    return -1;
                default:
                    return t;
            };
        }
    }
}
