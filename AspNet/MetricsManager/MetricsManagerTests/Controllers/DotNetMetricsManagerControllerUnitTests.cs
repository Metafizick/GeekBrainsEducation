using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class DotNetMetricsManagerConrollerUnitTests
    {
        private DotNetMetricsManagerController _controller;
        private Mock<ILogger<DotNetMetricsManagerController>> _loggerMock;
        public DotNetMetricsManagerConrollerUnitTests()
        {
            _loggerMock = new Mock<ILogger<DotNetMetricsManagerController>>();
            _controller = new DotNetMetricsManagerController(_loggerMock.Object);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);


            var result = _controller.GetMetricsFromAgent(agentId, fromTime, toTime);


            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetMetricsFromAllCluster_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);


            var result = _controller.GetMetricsFromAllCluster(fromTime, toTime);


            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}