using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class DotNetMetricsAgentControllerUnitTests
    {
        private DotNetMetricsAgentController controller;

        public DotNetMetricsAgentControllerUnitTests()
        {
            controller = new DotNetMetricsAgentController();
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
