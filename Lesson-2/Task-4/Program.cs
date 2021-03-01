using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string company = "ЗАО Пупа&Лупа",
                adres1 = "Московская область",
                adres2 = "г. Орехово-Зуево, ул. Урицкого, д. 666",
                welcome = "Добро пожаловать!",
                thx = "СПАСИБО ЗА ПОКУПКУ!",
                product1 = "Носки муж. Macho!",
                product2 = "Гель для душа Palmolive (нежный)",
                product3 = "Пена для бритья Gillete";
            int index = 142605;
            double price1 = 100.21,
                   price2 = 250.53,
                   price3 = 134.78,
                   sum = price1 + price2 + price3,
                   cash = 1000,
                   deliv = cash - sum; 
            var date1 = new DateTime(2021, 2, 23, 9, 42, 45);
            Console.WriteLine("{0,25}\n {1,13}, {2,18}\n {3,10}\n {4,28}\n {5, 28}", company, index, adres1, adres2, welcome, date1);
            Console.WriteLine(new string('=', 42));
            Console.WriteLine("{0,10} {1,30}", "Товар", "Цена");
            Console.WriteLine(new string('_', 42));
            Console.WriteLine("{0,0}\n {1,40}", product1, price1);
            Console.WriteLine(new string('_', 42));
            Console.WriteLine("{0,0}\n {1,40}", product2, price2);
            Console.WriteLine(new string('_', 42));
            Console.WriteLine("{0,0}\n {1,40}", product3, price3);
            Console.WriteLine(new string('_', 42));
            Console.WriteLine("{0,0} {1,36}", "ИТОГ", sum);
            Console.WriteLine(new string('_', 42));
            Console.WriteLine("{0,0} {1,32}\n {2,0} {3,34}", "Наличные", cash, "Сдача", deliv);
            Console.WriteLine(new string('=', 42));
            Console.WriteLine("{0,28}", thx);
            Console.ReadKey();
           


        }
    }
}
