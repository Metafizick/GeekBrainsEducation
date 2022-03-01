using MetricsAgent.DAL;
using MetricsAgent.Models;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class CpuMetricJob : IJob
    {
        private readonly IRepository<CpuMetric> _cpuMetricsAgentRepository;
        private PerformanceCounter _performanceCounter;
        public CpuMetricJob(IRepository<CpuMetric> cpuMetricsAgentRepository)
        {
            _cpuMetricsAgentRepository = cpuMetricsAgentRepository;
            _performanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }
        public Task Execute(IJobExecutionContext context)
        {
            var cpuUsageInPercents = Convert.ToInt32(_performanceCounter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _cpuMetricsAgentRepository.Create(new CpuMetric()
            {
                Time = time,
                Value = cpuUsageInPercents
            });
            return Task.CompletedTask;
        }
    }
}
