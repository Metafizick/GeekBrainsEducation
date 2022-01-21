using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class NetworkMetricsManagerConrollerUnitTests
    {
        private NetworkMetricsManagerController controller;
        private Mock<ILogger<NetworkMetricsManagerController>> _loggerMock;
        public NetworkMetricsManagerConrollerUnitTests()
        {
            _loggerMock = new Mock<ILogger<NetworkMetricsManagerController>>();
            controller = new NetworkMetricsManagerController(_loggerMock.Object);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);


            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);


            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetMetricsFromAllCluster_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);


            var result = controller.GetMetricsFromAllCluster(fromTime, toTime);


            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}
