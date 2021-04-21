using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    for (int k = 0; k < inputArray.Length; k++)
                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }

            return sum;
        }
        /* Асимптотическая сложность метода StrangeSum O(2+3n^3), 
         * где n = inputArray.Length. 2 получили из 2 действий, присвоения и возврата значения
         * коэффициент 3 - количество действий во внутреннем массиве
         * n^3 - согласно 4 правилу
         * Применяя правила несущественности констант, получим итоговую сложность O(n^3)
         */
        static void Main(string[] args)
        {
            int[] exampleArray = new int[4];
            int sum = StrangeSum(exampleArray);
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
