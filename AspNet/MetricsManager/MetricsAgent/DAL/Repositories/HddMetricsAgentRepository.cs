using Dapper;
using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public class HddMetricsAgentRepository : IRepository<HddMetric>
    {
        private const string ConnectionString = @"Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public HddMetricsAgentRepository()
        {
            SqlMapper.AddTypeHandler(new DataTimeOffsetHandler());
        }
        public void Create(HddMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO hddmetrics(value, time) VALUES(@value, @time)",
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
                connection.Execute("DELETE FROM hddmetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }
        public void Update(HddMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE hddmetrics SET value = @value, time = @time WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        time = item.Time.ToUnixTimeSeconds(),
                        id = item.Id
                    });
            }
        }
        public IList<HddMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = connection.Query<HddMetric>("SELECT Id, Time, Value FROM hddmetrics").ToList();
                return result;
            }
        }
        public HddMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = connection.QuerySingle<HddMetric>("SELECT Id, Time, Value FROM hddmetrics WHERE id=@id",
                    new { id = id });
                return result;
            }
        }

        public IList<HddMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = connection.Query<HddMetric>("SELECT id, value, time FROM hddmetrics WHERE time>@fromTime AND time<@toTime").ToList();
                return result;
            }
        }
    }
}

