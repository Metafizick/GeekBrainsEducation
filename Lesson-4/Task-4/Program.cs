using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int number = EntNumb();
            int fibNumber;
            if (number>=0)
            {
                fibNumber = FibonacciPos(number);
            }else
            {
                fibNumber = FibonacciNeg(number);
            }
             
            Console.WriteLine($"Fibonacci number from {number} = {fibNumber}"); 

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
        public static int FibonacciPos(int numb)
        {
            if (numb == 0)
            {
                return 0;
            }
            else if (numb == 1)
            {
                return 1;
            }
            return FibonacciPos (numb-2)  + FibonacciPos(numb - 1);
        }
        public static int FibonacciNeg(int numb)
        {
            if (numb == -1)
            {
                return -1;
            }
            else if (numb == -2)
            {
                return -1;
            }
            return FibonacciNeg(numb + 2) + FibonacciNeg(numb + 1);
        }
    }
}
