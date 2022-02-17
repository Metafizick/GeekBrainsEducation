using Dapper;
using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public class NetworkMetricsAgentRepository : IRepository<NetworkMetric>
    {
        private const string ConnectionString = @"Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public NetworkMetricsAgentRepository()
        {
            SqlMapper.AddTypeHandler(new DataTimeOffsetHandler());
        }
        public void Create(NetworkMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO networkmetrics(value, time) VALUES(@value, @time)",
                    new
                    {
                        value = item.Value,
                        time = item.Time.ToUnixTimeSeconds()
                    });
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("DELETE FROM networkmetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }
        public void Update(NetworkMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE networkmetrics SET value = @value, time = @time WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        time = item.Time.ToUnixTimeSeconds(),
                        id = item.Id
                    });
            }
        }
        public IList<NetworkMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = connection.Query<NetworkMetric>("SELECT Id, Time, Value FROM networkmetrics").ToList();
                return result;
            }
        }
        public NetworkMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = connection.QuerySingle<NetworkMetric>("SELECT Id, Time, Value FROM networkmetrics WHERE id=@id",
                    new { id = id });
                return result;
            }
        }

        public IList<NetworkMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = connection.Query<NetworkMetric>("SELECT id, value, time FROM networkmetrics WHERE time>@fromTime AND time<@toTime").ToList();
                return result;
            }
        }
    }
}
