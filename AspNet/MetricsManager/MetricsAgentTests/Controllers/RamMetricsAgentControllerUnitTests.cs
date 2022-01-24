using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class RamMetricsAgentControllerUnitTests
    {
        private RamMetricsAgentController _controller;
        private Mock<ILogger<RamMetricsAgentController>> _loggerMock;
        private Mock<IRepository<RamMetric>> _ramMetricsAgentRepositoryMock;
        public RamMetricsAgentControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<RamMetricsAgentController>>();
            _ramMetricsAgentRepositoryMock = new Mock<IRepository<RamMetric>>();
            _controller = new RamMetricsAgentController(_loggerMock.Object, _ramMetricsAgentRepositoryMock.Object);
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);


            var result = _controller.GetMetricsFromAgent(fromTime, toTime);


            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
