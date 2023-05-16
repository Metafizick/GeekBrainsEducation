using PumpClient.PumpServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpClient
{
    public class CallbackHandler : IPumpServiceCallback
    {
        public void UpdateStatistics(StatisticsData statisticsData)
        {
            Console.Clear();
            Console.WriteLine("Обновление по статистике выполнения скрипта");
            Console.WriteLine($"Всего     тактов: {statisticsData.AllTacts}");
            Console.WriteLine($"Успешных  тактов: {statisticsData.SuccessTacts}");
            Console.WriteLine($"Ошибочных тактов: {statisticsData.ErrorTacts}");
        }
    }
}
