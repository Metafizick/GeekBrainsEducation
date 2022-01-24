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
    [Route("api/metricsagent/network")]
    [ApiController]
    public class NetworkMetricsAgentController : ControllerBase
    {
        private readonly ILogger<NetworkMetricsAgentController> _logger;
        private readonly IRepository<NetworkMetric> _networkMetricsAgentRepository;
        public NetworkMetricsAgentController(ILogger<NetworkMetricsAgentController> logger, IRepository<NetworkMetric> networkMetricsAgentRepository)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в NetworkMetricsAgentController");
            _networkMetricsAgentRepository = networkMetricsAgentRepository;
        }
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogDebug($"fromTime: {fromTime} toTime: {toTime}");
            return Ok();
        }
    }
}
