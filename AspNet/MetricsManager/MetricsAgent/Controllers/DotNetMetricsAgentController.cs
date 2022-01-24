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
    [Route("api/metricsagent/dotnet/errors-count")]
    [ApiController]
    public class DotNetMetricsAgentController : ControllerBase
    {
        private readonly ILogger<DotNetMetricsAgentController> _logger;
        private readonly IRepository<DotNetMetric> _dotNetMetricsAgentRepository;
        public DotNetMetricsAgentController(ILogger<DotNetMetricsAgentController> logger, IRepository<DotNetMetric> dotNetMetricsAgentRepository)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в DotNetMetricsAgentController");
            _dotNetMetricsAgentRepository = dotNetMetricsAgentRepository;
        }
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogDebug($"fromTime: {fromTime} toTime: {toTime}");
            return Ok();
        }
    }
}
