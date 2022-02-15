using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Responses;

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
        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            _cpuMetricsAgentRepository.Create(new CpuMetric
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _cpuMetricsAgentRepository.GetAll();

            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new CpuMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }

    }
}
