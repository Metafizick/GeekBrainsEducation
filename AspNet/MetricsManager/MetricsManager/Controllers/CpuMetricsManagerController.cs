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
    [Route("api/metricsmanager/cpu")]
    [ApiController]
    public class CpuMetricsManagerController : ControllerBase
    {
        
        private readonly MetricAgentClient _metricAgentClient;
        public CpuMetricsManagerController( MetricAgentClient metricAgentClient)
        {
            
            _metricAgentClient = metricAgentClient;
        }
        [HttpGet("from/{fromTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] string fromTime)
        {
           
            // обращение в сервис
            var metrics = _metricAgentClient.GetCpuMetrics(new GetAllCpuMetricsRequest(){FromTime = fromTime });

            return Ok(metrics);
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
           
            return Ok();
        }

    }
}
