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
    [Route("api/metricsagent/ram/available")]
    [ApiController]
    public class RamMetricsAgentController : ControllerBase
    {
        private readonly ILogger<RamMetricsAgentController> _logger;
        private readonly IRepository<RamMetric> _ramMetricsAgentRepository;
        private readonly IMapper _mapper;
        public RamMetricsAgentController(ILogger<RamMetricsAgentController> logger, IRepository<RamMetric> ramMetricsAgentRepository, IMapper mapper)
        {
            _logger = logger;
            _ramMetricsAgentRepository = ramMetricsAgentRepository;
            _mapper = mapper;
        }
        [HttpGet("from/{fromTime}")]
        public IActionResult GetByTimePeriod([FromRoute] string fromTime)
        {
            _logger.LogInformation($"fromTime: {fromTime}");            
            var metrics = _ramMetricsAgentRepository.GetByTimePeriod(fromTime);
            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<RamMetricDto>(metric));
            }
            return Ok(response);
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] RamMetricCreateRequest request)
        {
            _ramMetricsAgentRepository.Create(new RamMetric
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _ramMetricsAgentRepository.GetAll();

            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<RamMetricDto>(metric));
            }
            return Ok(response);
        }
        [HttpGet("getfromid/{Id}")]
        public IActionResult GetFromId([FromRoute] int Id)
        {
            _logger.LogInformation($"Id: {Id}");
            var metric = _ramMetricsAgentRepository.GetById(Id);
            var response =_mapper.Map<RamMetricDto>(metric);                      
            return Ok(response);
        }
    }
}
