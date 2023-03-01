using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardStorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        #region Services

        private readonly ILogger<CardController> _logger;

        #endregion
        
        #region Constructors

        public CardController(ILogger<CardController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Publoc Methods
        [HttpGet("getAll")]
        public IActionResult GetByClientId(string clientId) 
        {
            _logger.LogInformation("GetbyClientId...");
            return Ok();
        }

        #endregion
    }
}
