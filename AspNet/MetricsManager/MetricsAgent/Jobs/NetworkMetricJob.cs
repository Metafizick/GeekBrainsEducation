using MetricsAgent.DAL;
using MetricsAgent.Models;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private readonly IRepository<NetworkMetric> _networkMetricsAgentRepository;
        private PerformanceCounter _performanceCounter;
        public NetworkMetricJob(IRepository<NetworkMetric> networkMetricsAgentRepository)
        {
            _networkMetricsAgentRepository = networkMetricsAgentRepository;
            _performanceCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec");
        }
        public Task Execute(IJobExecutionContext context)
        {
            var NetworkBytesSent = Convert.ToInt32(_performanceCounter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _networkMetricsAgentRepository.Create(new NetworkMetric()
            {
                Time = time,
                Value = NetworkBytesSent
            });
            return Task.CompletedTask;
        }
    }
}
