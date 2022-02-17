using MetricsAgent.DAL;
using MetricsAgent.Models;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class RamMetricJob : IJob
    {
        private readonly IRepository<RamMetric> _ramMetricsAgentRepository;
        private PerformanceCounter _performanceCounter;
        public RamMetricJob(IRepository<RamMetric> ramMetricsAgentRepository)
        {
            _ramMetricsAgentRepository = ramMetricsAgentRepository;
            _performanceCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
        public Task Execute(IJobExecutionContext context)
        {
            var ramAvailableMbites = Convert.ToInt32(_performanceCounter.NextValue());
            _ramMetricsAgentRepository.Create(new RamMetric()
            {
                Time = DateTimeOffset.UtcNow,
                Value = ramAvailableMbites
            });
            return Task.CompletedTask;
        }
    }
}
