using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson1.Framework
{

    public delegate int BinaryOperation(int x, int y);

    internal class Program
    {

        static int Plus(int x,  int y)
        {
            Console.WriteLine($"Метод Plus() выполняется в контексте потока {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            return x + y;
        }

        static void Task1()
        {
            BinaryOperation binaryOperation = new BinaryOperation(Plus);
            int answer = binaryOperation.Invoke(10, 15);

            Console.WriteLine($"10 + 15 = {answer}");

        }

        static void Task2()
        {
            Console.WriteLine($"Метод (Task2) выполняется в контексте потока {Thread.CurrentThread.ManagedThreadId}");
            BinaryOperation binaryOperation = new BinaryOperation(Plus);
            IAsyncResult asyncResult = binaryOperation.BeginInvoke(10, 15, null, null);
            int answer = binaryOperation.EndInvoke(asyncResult);
            Console.WriteLine($"10 + 15 = {answer}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Начало работы приложения");
            Console.WriteLine($"(Main) Идентификатор главного потока: {Thread.CurrentThread.ManagedThreadId}");
            //Task1();
            Task2();
            //Console.WriteLine($"Thread priority: {Thread.CurrentThread.Priority}");

            //Thread.CurrentThread.Name = "123";
            //Console.WriteLine($"Thread name: {Thread.CurrentThread.Name}");
            Console.WriteLine("Завершение работы приложения");

            Console.WriteLine($"(Main) Идентификатор главного потока: {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadKey(true);

        }
    }
}
