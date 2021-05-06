using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i*2;
            }
            foreach (var item in array)
            {
                Console.Write($"{item}\t");
            }
            var result = BinarySearch(array, 8);
            Console.WriteLine($"Result = {result}");
        }
        /*Асимптотическая сложность алгоритма бинарного поиска = O(log2(n)) - логарифму от размера массива,
         * в котором ведётся поиск, по основанию 2 */

        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
