using CardStorageService.Data;
using CardStorageService.Models.Requests;
using CardStorageService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardStorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        #region Services

        private readonly ILogger<ClientController> _logger;
        private readonly IClientRepositoryService _clientRepositoryService;

        #endregion

        #region Constructors

        public ClientController(ILogger<ClientController> logger, IClientRepositoryService clientRepositoryService)
        {
            _logger = logger;
            _clientRepositoryService = clientRepositoryService;
        }

        #endregion

        #region Public Methods

        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateClientResponse), StatusCodes.Status200OK)]

        public IActionResult Create([FromBody] CreateClientRequest request)
        {
            try
            {
                var clientId = _clientRepositoryService.Create(new Client
                {
                    FirstName = request.FirstName,
                    Surname = request.Surname,
                    Patronymic = request.Patronymic
                });
                return Ok(new CreateClientResponse
                {
                    ClientId = clientId
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Create client error");
                return Ok(new CreateClientResponse
                {
                    ErrorCode = 912,
                    ErrorMessage = "Create client error"
                });
            }
        }
        #endregion
    }
}
