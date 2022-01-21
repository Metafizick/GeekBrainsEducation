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
    public class HddMetricsAgentControllerUnitTests
    {
        private HddMetricsAgentController controller;
        private Mock<ILogger<HddMetricsAgentController>> _loggerMock;
        private Mock<IRepository<HddMetric>> _hddMetricsAgentRepositoryMock;
        public HddMetricsAgentControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<HddMetricsAgentController>>();
            _hddMetricsAgentRepositoryMock = new Mock<IRepository<HddMetric>>();
            controller = new HddMetricsAgentController(_loggerMock.Object, _hddMetricsAgentRepositoryMock.Object);
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
