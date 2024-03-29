﻿using Dapper;
using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.DAL
{
    public class CpuMetricsAgentRepository : IRepository<CpuMetric>
    {
        private const string ConnectionString = @"Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public CpuMetricsAgentRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }
        public void Create(CpuMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO cpumetrics(value, time) VALUES(@value, @time)",
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds
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
                        time = item.Time.TotalSeconds,
                        id = item.Id
                    });
            }
        }
        public IList<CpuMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
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
        public IList<CpuMetric> GetByTimePeriod(string fromTime)
        {
            var fromTimeToSec = Convert.ToInt64(fromTime);
            var toTime = Convert.ToInt64(TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds()).TotalSeconds);
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                var result = connection.Query<CpuMetric>($"SELECT Id, Time, Value FROM cpumetrics WHERE Time>{fromTimeToSec} AND Time<{toTime}").ToList();
                return result;
            }
        }
    }
}
