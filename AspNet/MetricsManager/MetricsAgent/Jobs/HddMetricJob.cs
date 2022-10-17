using MetricsAgent.DAL;
using MetricsAgent.Models;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class HddMetricJob : IJob
        {
            private readonly IRepository<HddMetric> _hddMetricsAgentRepository;
            private PerformanceCounter _performanceCounter;
            public HddMetricJob(IRepository<HddMetric> hddMetricsAgentRepository)
            {
            _hddMetricsAgentRepository = hddMetricsAgentRepository;
                _performanceCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
            }
            public Task Execute(IJobExecutionContext context)
            {
                var hddDiskTime = Convert.ToInt32(_performanceCounter.NextValue());
                var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                _hddMetricsAgentRepository.Create(new HddMetric()
                {
                    Time = time,
                    Value = hddDiskTime
                });
                return Task.CompletedTask;
            }
        }
}
