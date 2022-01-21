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
    public class DotNetMetricsAgentControllerUnitTests
    {
        private DotNetMetricsAgentController controller;
        private Mock<ILogger<DotNetMetricsAgentController>> _loggerMock;
        private Mock<IRepository<DotNetMetric>> _dotNetMetricsAgentRepositoryMock;
        public DotNetMetricsAgentControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<DotNetMetricsAgentController>>();
            _dotNetMetricsAgentRepositoryMock = new Mock<IRepository<DotNetMetric>>();
            controller = new DotNetMetricsAgentController(_loggerMock.Object, _dotNetMetricsAgentRepositoryMock.Object);
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);


            var result = controller.GetMetricsFromAgent(fromTime, toTime);


            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
