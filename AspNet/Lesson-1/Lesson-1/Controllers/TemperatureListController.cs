using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1.Controllers
{
    [Route("api/TemperatureList")]
    [ApiController]
    public class TemperatureListController : ControllerBase
    {
        private readonly TemperatureList _temperatureList;
        public TemperatureListController(TemperatureList temperatureList)
        {
            _temperatureList = temperatureList;
        }
        [HttpPost("CreateNewIndication")]
        public IActionResult CreateNewIndication([FromBody] WeatherForecast weatherForecast)
        {
            _temperatureList.Add(weatherForecast);
            return Ok();
        }
        [HttpGet("ReadTemperatureFromPeriod")]
        public IActionResult ReadTemperatureFromPeriod ([FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
        {
            return Ok(_temperatureList.Get(startTime, endTime));
        }
        [HttpPut("UpdateIndication")]
        public IActionResult UpdateIndication ([FromQuery] DateTime currentTime, [FromQuery] int newTemperature)
        {
            _temperatureList.Update(currentTime, newTemperature);
            return Ok();
        }
        [HttpDelete("DeleteFromPeriod")]
        public IActionResult DeleteFromPeriod ([FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
        {
            _temperatureList.Delete(startTime, endTime);
            return Ok();
        }
    }
}
