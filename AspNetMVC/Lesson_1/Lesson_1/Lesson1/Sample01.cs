namespace Lesson1
{
    internal class Sample01
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начало работы приложения ...");

            Thread thread1 = new Thread(Print);
            Console.WriteLine($"Thread is Background?: {thread1.IsBackground}");
            thread1.Start();

            Thread thread2 = new Thread(Sum);
            thread2.IsBackground = true;
            Console.WriteLine($"Thread is Background?: {thread2.IsBackground}");
            thread2.Start(new int[] { 2, 5 });

            Thread thread3 = new Thread(delegate ()
            {
                Console.WriteLine($"thread3() вызывается из потока {Thread.CurrentThread.ManagedThreadId}");
            });

            Thread thread4 = new Thread(() =>
            {
                Console.WriteLine($"thread4() вызывается из потока {Thread.CurrentThread.ManagedThreadId}");
            });

            Thread thread5 = new Thread((o2) =>
            {
            Thread.Sleep(10000);
            if (o2 != null && o2 is int[] && ((int[])o2).Length > 1)
            {
                int[] arr = (int[])o2;
                Console.WriteLine($"Sum({arr[0]} + {arr[1]}) = {arr[0] + arr[1]}");
            }
            if (o2 != null && o2 is string)
            { 
                Console.WriteLine($"Hello" + o2);
            }
            });
            thread5.Start(Enter());


            Console.WriteLine("Завершение работы приложения ...");

            //Console.ReadKey(true);
        }

        static void Print()
        {
            Console.WriteLine($"Print() вызывается из потока {Thread.CurrentThread.ManagedThreadId}");
        }

        static void Sum(object o)
        {
            Thread.Sleep(10000);
            if (o != null && o is int[] && ((int[])o).Length  > 1){
                int[] arr = (int[])o;
                Console.WriteLine($"Sum({arr[0]} + {arr[1]}) = {arr[0] + arr[1]}");
            }
        }
        static string? Enter()
        {
            return Console.ReadLine();
        }
    }
}