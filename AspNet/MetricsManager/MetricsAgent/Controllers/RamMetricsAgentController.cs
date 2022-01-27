using MetricsAgent.DAL;
using MetricsAgent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/metricsagent/ram/available")]
    [ApiController]
    public class RamMetricsAgentController : ControllerBase
    {
        private readonly ILogger<RamMetricsAgentController> _logger;
        private readonly IRepository<RamMetric> _ramMetricsAgentRepository;
        public RamMetricsAgentController(ILogger<RamMetricsAgentController> logger, IRepository<RamMetric> ramMetricsAgentRepository)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в RamMetricsAgentController");
            _ramMetricsAgentRepository = ramMetricsAgentRepository;
        }
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"fromTime: {fromTime} toTime: {toTime}");
            return Ok();
        }
    }
}
