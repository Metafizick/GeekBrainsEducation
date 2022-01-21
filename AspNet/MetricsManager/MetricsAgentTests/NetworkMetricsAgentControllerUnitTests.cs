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
    public class NetworkMetricsAgentControllerUnitTests
    {
        private NetworkMetricsAgentController controller;
        private Mock<ILogger<NetworkMetricsAgentController>> _loggerMock;
        private Mock<IRepository<NetworkMetric>> _networkMetricsAgentRepositoryMock;
        public NetworkMetricsAgentControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<NetworkMetricsAgentController>>();
            _networkMetricsAgentRepositoryMock = new Mock<IRepository<NetworkMetric>>();
            controller = new NetworkMetricsAgentController(_loggerMock.Object, _networkMetricsAgentRepositoryMock.Object);
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