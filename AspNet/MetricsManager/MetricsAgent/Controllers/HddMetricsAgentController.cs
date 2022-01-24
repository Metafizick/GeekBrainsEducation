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
    [Route("api/metricsagent/hdd/left")]
    [ApiController]
    public class HddMetricsAgentController : ControllerBase
    {
        private readonly ILogger<HddMetricsAgentController> _logger;
        private readonly IRepository<HddMetric> __hddMetricsAgentRepository;
        public HddMetricsAgentController(ILogger<HddMetricsAgentController> logger, IRepository<HddMetric> hddMetricsAgentRepository)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в HddMetricsAgentController");
            __hddMetricsAgentRepository = hddMetricsAgentRepository;
        }
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogDebug($"fromTime: {fromTime} toTime: {toTime}");
            return Ok();
        }
    }
}
