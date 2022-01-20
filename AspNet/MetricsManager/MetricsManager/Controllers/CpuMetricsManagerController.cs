using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/metricsmanager/cpu")]
    [ApiController]
    public class CpuMetricsManagerController : ControllerBase
    {
        private readonly ILogger<CpuMetricsManagerController> _logger;
        public CpuMetricsManagerController(ILogger<CpuMetricsManagerController> logger) 
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsManagerController");
        }
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            return Ok();
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            _logger.LogError("Hello");
            return Ok();
        }

    }
}
