using System;
using System.IO;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How much numbers you want to write?");
            int numbersLenght = Number(); //Convert.ToInt32(Console.ReadLine());
            byte[] numbers = new byte [numbersLenght];
            for (int i =0; i<numbersLenght; i++)
            {
                Console.WriteLine($"Enter {i + 1} number");
                numbers[i] = Number();
            }
            File.WriteAllBytes("numbers.bin", numbers);

            
        }
        static byte Number()
        {
            byte num;
            bool numBool;
            do
            {
                numBool = byte.TryParse(Console.ReadLine(), out num);
                if ( numBool == false | num < 0 | num > 255)
                {
                    Console.WriteLine("Incorrected value of number (0..255");
                }
            } while (numBool == false | num < 0 | num > 255);
            return num;
        }
    }
}
