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
    public class CpuMetricsAgentControllerUnitTests
    {
        private CpuMetricsAgentController controller;
        private Mock<ILogger<CpuMetricsAgentController>> _loggerMock;
        private Mock<IRepository<CpuMetric>> _cpuMetricsAgentRepositoryMock;

        public CpuMetricsAgentControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<CpuMetricsAgentController>>();
            _cpuMetricsAgentRepositoryMock = new Mock<IRepository<CpuMetric>>();
            controller = new CpuMetricsAgentController(_loggerMock.Object, _cpuMetricsAgentRepositoryMock.Object);

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
