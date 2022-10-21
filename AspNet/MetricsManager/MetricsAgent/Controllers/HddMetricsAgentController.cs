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
    [Route("api/metricsagent/hdd")]
    [ApiController]
    public class HddMetricsAgentController : ControllerBase
    {
        private readonly ILogger<HddMetricsAgentController> _logger;
        private readonly IRepository<HddMetric> _hddMetricsAgentRepository;
        private readonly IMapper _mapper;
        public HddMetricsAgentController(ILogger<HddMetricsAgentController> logger, IRepository<HddMetric> hddMetricsAgentRepository, IMapper mapper)
        {
            _logger = logger;
            _hddMetricsAgentRepository = hddMetricsAgentRepository;
            _mapper = mapper;

        }
        [HttpGet("from/{fromTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] string fromTime)
        {
            _logger.LogInformation($"fromTime: {fromTime}");
            var metrics = _hddMetricsAgentRepository.GetByTimePeriod(fromTime);
            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
            }
            return Ok(response);
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            _hddMetricsAgentRepository.Create(new HddMetric
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _hddMetricsAgentRepository.GetAll();

            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
            }
            return Ok(response);
        }
    }
}
