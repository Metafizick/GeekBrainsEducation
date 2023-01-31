using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{

    class ThreadControl
    {
        
        public bool IsActive { get; set; }

    }

    internal class Sample02
    {
       static void Main(string[] args)
        {
            Console.WriteLine("Начало работы приложения ...");

            Task3();

            Console.WriteLine("Завершение работы приложения ...");
        }

        static void Task2()
        {
            var threadControl = new ThreadControl()
            {
                IsActive = true
            };

            Thread thread = new Thread((o) =>
            {
                if (o != null && o is ThreadControl)
                {
                    var threadControl = (ThreadControl)o;
                    while (threadControl.IsActive)
                    {
                        Console.WriteLine($"Метод запущен в потоке {Thread.CurrentThread.Name}");
                        try
                        {
                            Thread.Sleep(30000);
                        }
                        catch(ThreadInterruptedException e)
                        {
                            Console.WriteLine("Поступил сигнал на прерывание потока.");
                            //TODO: Корректно завершаем работу метода ...
                            break;
                        }
                    }
                }
            });

            thread.Name = "#testThread";
            thread.Start(threadControl);

            Thread.Sleep(5000);
            //threadControl.IsActive = false;
            thread.Interrupt();



        }

        static void Task3()
        {

            Random random = new Random();

            AutoResetEvent[] waitHandlers = new AutoResetEvent[5];
            for (int i = 0; i < waitHandlers.Length; i++)
            {
                waitHandlers[i] = new AutoResetEvent(false);
            }

            Thread[] threads = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread((o) =>
                {
                    Console.WriteLine($"Метод запущен в потоке: {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(random.Next(1000, 5000));
                    Console.WriteLine($"Завершение потока: {Thread.CurrentThread.ManagedThreadId}");
                    ((AutoResetEvent)o).Set();
                });
                threads[i].Start(waitHandlers[i]);
            }

            WaitHandle.WaitAll(waitHandlers);
        }


        static void Task1()
        {
            var threadControl = new ThreadControl()
            {
                IsActive = true
            };

            Thread thread = new Thread((o) =>
            {
                if (o != null && o is ThreadControl)
                {
                    var threadControl = (ThreadControl)o;
                    while (threadControl.IsActive)
                    {
                        Console.WriteLine($"Метод запущен в потоке {Thread.CurrentThread.Name}");
                        Thread.Sleep(30000);
                    }
                }
            });

            thread.Name = "#testThread";
            thread.Start(threadControl);

            Thread.Sleep(5000);
            threadControl.IsActive = false;

        }
    }
}
