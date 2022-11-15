using MetricsManager.Client;
using MetricsManager.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/metricsmanager/hdd")]
    [ApiController]
    public class HddMetricsManagerController : ControllerBase
    {
        private readonly ILogger<HddMetricsManagerController> _logger;
        private readonly MetricAgentClient _metricAgentClient;
        public HddMetricsManagerController(ILogger<HddMetricsManagerController> logger, GetAllHddMetricsRequest getAllHddMetricsRequest, MetricAgentClient metricAgentClient)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в HddMetricsManagerController");
            _metricAgentClient = metricAgentClient;
        }
        [HttpGet("from/{fromTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] string fromTime)
        {

            // обращение в сервис
            var metrics = _metricAgentClient.GetHddMetrics(getAllHddMetricsRequest);

            return Ok(metrics);
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}
