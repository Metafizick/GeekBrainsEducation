﻿using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter numbers");
            string numbers = Console.ReadLine();
            int sum = 0;
            string sumstr = "";
            for (int i = 0; i<numbers.Length; i++)
            {
                if (numbers[i] != ' ' )
                {
                    sumstr += Convert.ToString(numbers[i]);
                }
                else 
                {
                    (int numb, bool numbool) = ConvNumb(sumstr);
                    if (numbool)
                    {
                        sum += numb;
                    }
                    else if (sumstr !="")
                    {
                        Console.WriteLine($"{sumstr} not a number");
                    }
                    sumstr = "";
                }
            }
            if (sumstr != "")
            {
                (int numb, bool numbool) = ConvNumb(sumstr);
                if (numbool)
                {
                    sum += numb;
                }
                else 
                {
                    Console.WriteLine($"{sumstr} not a number");
                }
                sumstr = "";
            }

            Console.WriteLine($"The amount of numbers:{sum}");
            Console.ReadKey();
        }
        static (int numb, bool numbool) ConvNumb (string num)
        {
            bool numbool = int.TryParse(num, out int numb);
            return (numb, numbool);
        }
    }
}
