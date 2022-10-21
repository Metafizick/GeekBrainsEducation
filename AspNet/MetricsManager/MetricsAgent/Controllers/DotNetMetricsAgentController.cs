using AutoMapper;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/metricsagent/dotnet")]
    [ApiController]
    public class DotNetMetricsAgentController : ControllerBase
    {
        private readonly ILogger<DotNetMetricsAgentController> _logger;
        private readonly IRepository<DotNetMetric> _dotNetMetricsAgentRepository;
        private readonly IMapper _mapper;
        public DotNetMetricsAgentController(ILogger<DotNetMetricsAgentController> logger, IRepository<DotNetMetric> dotNetMetricsAgentRepository, IMapper mapper)
        {
            _logger = logger;
            _dotNetMetricsAgentRepository = dotNetMetricsAgentRepository;
            _mapper = mapper;
        }
        [HttpGet("from/{fromTime}/")]
        public IActionResult GetMetricsFromAgent([FromRoute] string fromTime)
        {
            _logger.LogInformation($"fromTime: {fromTime}");
            var metrics = _dotNetMetricsAgentRepository.GetByTimePeriod(fromTime);
            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
            }
            return Ok(response);
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {
            _dotNetMetricsAgentRepository.Create(new DotNetMetric
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _dotNetMetricsAgentRepository.GetAll();

            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
            }
            return Ok(response);
        }
    }
}
