using MetricsAgent.DAL;
using MetricsAgent.Models;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricJob : IJob
    {
        private readonly IRepository<DotNetMetric> _dotNetMetricsAgentRepository;
        private PerformanceCounter _performanceCounter;
        public DotNetMetricJob(IRepository<DotNetMetric> dotNetMetricsAgentRepository)
        {
            _dotNetMetricsAgentRepository = dotNetMetricsAgentRepository;
            _performanceCounter = new PerformanceCounter(".NET CLR Memory", "% Time in GC", "_Global_");
        }
        public Task Execute(IJobExecutionContext context)
        {
            var dotNetTmeInGc = Convert.ToInt32(_performanceCounter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _dotNetMetricsAgentRepository.Create(new DotNetMetric()
            {
                Time = time,
                Value = dotNetTmeInGc
            });
            return Task.CompletedTask;
        }
    }
}
