using System;

namespace Lessons_for_algo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of array");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] newArray = new int[size];
            int[] reverseArray = new int[size];
            for (int i = 0; i< size; i++ )
            {
                Console.WriteLine($"Enter {i} element of array");
                newArray[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{newArray[i]} ");
            }
            Console.WriteLine();
            int index = 0;
            while (index < size)
            {
                reverseArray[index] = newArray[size - 1 - index];
                index++;
            }
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{reverseArray[i]} ");
            }
            Console.WriteLine();
            index = 0;
            float average,
                  sum = 0;
            while(index < size)
            {
                sum += newArray[index];
                index++;
            }
            average = sum / size;
            index = 1;
               int indexMax = 0,
                indexMin = 0;
            while (index < size)
            {
                if (newArray[index] >= newArray[indexMax])
                {
                    indexMax = index;
                    index++;
                }
                else if (newArray[index] < newArray[indexMin])
                {
                    indexMin = index;
                    index++;
                }
                else index++;
            }
            Console.WriteLine($"index Max of array = {indexMax}, index Min of array = {indexMin}");
            Console.WriteLine($"Average of all array elements = {average} ");

        }
    }
}
