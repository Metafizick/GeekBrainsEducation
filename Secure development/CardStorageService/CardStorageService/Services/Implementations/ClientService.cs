using CardStorageService.Data;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using static ClientServiceProtos.ClientService;
using System.Threading.Tasks;
using System;
using ClientServiceProtos;
using CardStorageService.Models.Requests;

namespace CardStorageService.Services.Implementations
{
    public class ClientService : ClientServiceBase 
    {
        private readonly IClientRepositoryService _clientRepositoryService;
        private readonly ILogger<ClientService> _logger;

        public ClientService(ILogger<ClientService> logger, IClientRepositoryService clientRepositoryService)
        {
            _logger = logger;
            _clientRepositoryService = clientRepositoryService;
        }

        public override Task<CreateClientResponse> Create (CreateClientRequest request, ServerCallContext context)
        {
            try
            {
                var clientId = _clientRepositoryService.Create(new Client
                {
                    FirstName = request.FirstName,
                    Surname = request.Surname,
                    Patronymic = request.Patronymic,
                });

                var response = new CreateClientResponse
                {
                    ClientId = clientId,
                    ErrorCode = 0,
                    ErrorMessage = String.Empty
                };

                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create client error");

                var response = new CreateClientResponse
                {
                    ClientId = -1,
                    ErrorCode = 912,
                    ErrorMessage = "Create client error"
                };
                return Task.FromResult(response);
            }
        }
    }
}
