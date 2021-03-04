using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PhoneBook");
            String[,] phone = new String[5, 2];
            for (int i = 0; i<phone.GetLength(0); i++)
            {
                Console.Write($"Enter {i} phone/email adress");
                phone[i, 0] = Console.ReadLine();
            }
            for (int i = 0; i < phone.GetLength(0); i++)
            {
                Console.Write($"Enter {i} name");
                phone[i, 1] = Console.ReadLine();
            }
            Console.WriteLine("{0,0} {1,15}", "Phone/email", "name");
            for (int i=0; i<phone.GetLength(0); i++)
            {
                for (int j=0; j<phone.GetLength(1); j++)
                {
                    Console.Write($"{phone[i, j]}\t\t\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
