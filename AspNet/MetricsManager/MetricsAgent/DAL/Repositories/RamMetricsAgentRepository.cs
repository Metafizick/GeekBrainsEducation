﻿using Dapper;
using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public class RamMetricsAgentRepository : IRepository<RamMetric>
    {
        private const string ConnectionString = @"Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public RamMetricsAgentRepository()
        {
            SqlMapper.AddTypeHandler(new DataTimeOffsetHandler());
        }
        public void Create(RamMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO rammetrics(value, time) VALUES(@value, @time)",
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
                connection.Execute("DELETE FROM rammetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }
        public void Update(RamMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE rammetrics SET value = @value, time = @time WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        time = item.Time.ToUnixTimeSeconds(),
                        id = item.Id
                    });
            }
        }
        public IList<RamMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = connection.Query<RamMetric>("SELECT Id, Time, Value FROM rammetrics").ToList();
                return result;
            }
        }
        public RamMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = connection.QuerySingle<RamMetric>("SELECT Id, Time, Value FROM rammetrics WHERE id=@id",
                    new { id = id });
                return result;
            }
        }
        public IList<RamMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = connection.Query<RamMetric>("SELECT id, value, time FROM rammetrics WHERE time>@fromTime AND time<@toTime").ToList();
                return result;
            }
        }
    }
}
