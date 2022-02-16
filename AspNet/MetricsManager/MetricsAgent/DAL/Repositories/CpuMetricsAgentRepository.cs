using Dapper;
using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.DAL
{
    public class CpuMetricsAgentRepository : IRepository<CpuMetric>
    {
        public CpuMetricsAgentRepository()
        {
            SqlMapper.AddTypeHandler(new DataTimeOffsetHandler());
        }
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        // инжектируем соединение с базой данных в наш репозиторий через конструктор

        public void Create(CpuMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                //  Запрос на вставку данных с плейсхолдерами для параметров
                connection.Execute("INSERT INTO cpumetrics(value, time) VALUES(@value, @time)",
                    // Анонимный объект с параметрами запроса
                    new
                    {
                        // Value подставится на место "@value" в строке запроса
                        // Значение запишется из поля Value объекта item
                        value = item.Value,

                        // Записываем в поле time количество секунд
                        time = item.Time.ToUnixTimeSeconds()
                    });
            }
        }
        public void Delete(int id)
        {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Execute("DELETE FROM cpumetrics WHERE id=@id",
                        new
                        {
                            id = id
                        });
                }
        }
        public void Update(CpuMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE cpumetrics SET value = @value, time = @time WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        time = item.Time.ToUnixTimeSeconds(),
                        id = item.Id
                    });
            }
        }
        public IList<CpuMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                // Читаем, используя Query, и в шаблон подставляем тип данных,
                // объект которого Dapper, он сам заполнит его поля
                // в соответствии с названиями колонок
                var result = connection.Query<CpuMetric>("SELECT Id, Time, Value FROM cpumetrics").ToList();
                return result;
            }
        }

        public CpuMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = connection.QuerySingle<CpuMetric>("SELECT Id, Time, Value FROM cpumetrics WHERE id=@id",
                    new { id = id });
                return result;
            }

        }
    }
}
