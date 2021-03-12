using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int number = EntNumb();
            int fibNumber = Fibonacci(number);
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
        public static int Fibonacci(int numb)
        {
            if (numb == 0)
            {
                return numb;
            }
            return Fibonacci(numb - 1) + Fibonacci(numb - 2);
        }
    }
}
