using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class RamMetricsAgentControllerUnitTests
    {
        private RamMetricsAgentController controller;

        public RamMetricsAgentControllerUnitTests()
        {
            controller = new RamMetricsAgentController();
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
