using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.DAL;
using MetricsAgent.Models;

namespace MetricsAgent.Controllers
{
    [Route("api/metricsagent/cpu")]
    [ApiController]
    public class CpuMetricsAgentController : ControllerBase
    {
        private readonly ILogger<CpuMetricsAgentController> _logger;
        private readonly IRepository<CpuMetric> _cpuMetricsAgentRepository;
        public CpuMetricsAgentController(ILogger<CpuMetricsAgentController> logger, IRepository<CpuMetric> cpuMetricsAgentRepository)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsAgentController");
            _cpuMetricsAgentRepository = cpuMetricsAgentRepository;
        }
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"fromTime: {fromTime} toTime: {toTime}");
            return Ok();
        }
    }
}
