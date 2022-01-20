using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/metricsmanager/network")]
    [ApiController]
    public class NetworkMetricsManagerController : ControllerBase
    {
        private readonly ILogger<NetworkMetricsManagerController> _logger;
        public NetworkMetricsManagerController(ILogger<NetworkMetricsManagerController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в NetworkMetricsManagerController");
        }
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}
