using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Booking
{
    public class Restaurant
    {
        private readonly List<Table> _tables = new(); 
        public Restaurant() 
        {
            for (ushort i = 1; i <= 10; i++)
            {
                _tables.Add(new Table(i)); 
            }
        }
        public void BookFreeTable(int countOfPerson)
        {
            Console.WriteLine("Добрый день! Подождите секунду я подберу столик и подтвержу вашу бронь, оставайтесь на линии");
            var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPerson
                                                        && t.State == State.Free );
            Thread.Sleep(1000*5);
            Console.WriteLine(table is null
                ? $"К сожалению сейчас все столики заняты"
                : $"Готово! Ваш столик номер {table.Id}");
        }
        public void BookFreeTableAsync(int countOfPerson)
        {
            Console.WriteLine("Добрый день! Подождите секунду я подберу столик и подтвержу вашу бронь, вам придёт уведомление");
            Task.Run(async () => 
            {
                var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPerson
                                                        && t.State == State.Free);
                await Task.Delay(1000*5);
                table?.SetState(State.Booked);
                Console.WriteLine(table is null
                ? $"К сожалению сейчас все столики заняты"
                : $"Готово! Ваш столик номер {table.Id}");
            });
        }
    }
}
