using MetricsManager;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class AgentsControllerUnitTests
    {
        private AgentsController controller;
        private Mock<ILogger<AgentsController>> _loggerMock;

        public AgentsControllerUnitTests()
        {
            _loggerMock = new Mock<ILogger<AgentsController>>();
            controller = new AgentsController(_loggerMock.Object);
        }

        [Fact]
        public void RegisterAgent_ReturnsOk()
        {
            AgentInfo agentInfo = new AgentInfo();

            

            var result = controller.RegisterAgent(agentInfo);


            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void EnableAgentById_ReturnsOk()
        {
            var agentId = 1;
            


            var result = controller.EnableAgentById(agentId);


            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void DisableAgentById_ReturnsOk()
        {
            var agentId = 1;



            var result = controller.DisableAgentById(agentId);


            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetAgentsList_ReturnsOk()
        {
            



            var result = controller.GetAgentsList();


            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}
