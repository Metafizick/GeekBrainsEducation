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
    [Route("api/metricsagent/network")]
    [ApiController]
    public class NetworkMetricsAgentController : ControllerBase
    {
        private readonly ILogger<NetworkMetricsAgentController> _logger;
        private readonly IRepository<NetworkMetric> _networkMetricsAgentRepository;
        private readonly IMapper _mapper;
        public NetworkMetricsAgentController(ILogger<NetworkMetricsAgentController> logger, IRepository<NetworkMetric> networkMetricsAgentRepository, IMapper mapper)
        {
            _logger = logger;
            _networkMetricsAgentRepository = networkMetricsAgentRepository;
            _mapper = mapper;
        }
        [HttpGet("from/{fromTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] string fromTime)
        {
            _logger.LogInformation($"fromTime: {fromTime}");
            var metrics = _networkMetricsAgentRepository.GetByTimePeriod(fromTime);
            var response = new AllNetworkMetricsResponse()
            {
                Metrics = new List<NetworkMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<NetworkMetricDto>(metric));
            }
            return Ok(response);
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] NetworkMetricCreateRequest request)
        {
            _networkMetricsAgentRepository.Create(new NetworkMetric
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _networkMetricsAgentRepository.GetAll();

            var response = new AllNetworkMetricsResponse()
            {
                Metrics = new List<NetworkMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<NetworkMetricDto>(metric));
            }
            return Ok(response);
        }
    }
}
