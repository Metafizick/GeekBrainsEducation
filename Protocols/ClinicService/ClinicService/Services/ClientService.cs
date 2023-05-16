using ClientServiceProtos;
using ClinicService.DAL.Interfaces;
using ClinicService.Data;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;
using static ClientServiceProtos.ClientService;

namespace ClinicService.Services;

[Authorize]
public class ClientService : ClientServiceBase
{
    private readonly IClientRepository _db;
    private readonly ILogger<ClientService> _logger;

    private void LogError(Exception ex, [CallerMemberName] string methodName = null!)
        => _logger.LogError(ex, "Ошибка выполнения {methodName}", methodName);
    public ClientService(IClientRepository db, ILogger<ClientService> logger)
     => (_db, _logger) = (db, logger);

    public override Task<GetClientByIdResponse> GetClientById(GetClientByIdRequest request, ServerCallContext context)
    {
        var response = new GetClientByIdResponse();
        try
        {
            var client = _db.GetById(request.ClientId);
            response.Client = new ClientResponse()
            {
                ClientId = client.ClientId,
                Document = client.Document,
                FirstName = client.FirstName,
                Patronymic = client.Patronymic,
                Surname = client.Surname
            };
        }
        catch (Exception ex)
        {
            LogError(ex);
            response.ErrCode = (int)ErrorCodes.Get;
            response.ErrMessage = $"Ошибка получения клиента {request.ClientId}";
        }

        return Task.FromResult(response);
    }

    public override Task<GetClientsResponse> GetClients(GetClientsRequest request, ServerCallContext context)
    {
        var response = new GetClientsResponse();

        try
        {
            response.Clients.AddRange(_db.GetAll().Select(client => new ClientResponse
            {
                ClientId = client.ClientId,
                Document = client.Document,
                FirstName = client.FirstName,
                Patronymic = client.Patronymic,
                Surname = client.Surname
            }).ToList());
        }
        catch (Exception ex)
        {
            LogError(ex);
            response.ErrCode = (int)ErrorCodes.Get;
            response.ErrMessage = $"Ошибка получения всех клиентов";

        }

        return Task.FromResult(response);
    }

    public override Task<CreateClientResponse> CreateClient(CreateClientRequest request, ServerCallContext context)
    {
        var response = new CreateClientResponse();

        try
        {
            var client = new Client
            {
                Document = request.Document,
                Surname = request.Surname,
                FirstName = request.FirstName,
                Patronymic = request.Patronymic
            };
            _db.Add(client);
            response.ClientId = client.ClientId;
        }
        catch (Exception ex)
        {
            LogError(ex);
            response.ErrCode = (int)ErrorCodes.Create;
            response.ErrMessage = $"Ошибка создания клиента";
        }

        return Task.FromResult(response);
    }

    public override Task<UpdateClientResponse> UpdateClient(UpdateClientRequest request, ServerCallContext context)
    {
        var response = new UpdateClientResponse();

        try
        {
            var client = new Client
            {
                ClientId = request.ClientId,
                Document = request.Document,
                Surname = request.Surname,
                FirstName = request.FirstName,
                Patronymic = request.Patronymic
            };
            _db.Update(client);
        }
        catch (Exception ex)
        {
            LogError(ex);
            response.ErrCode = (int)ErrorCodes.Create;
            response.ErrMessage = $"Ошибка изменения клиента {request.ClientId}";
        }

        return Task.FromResult(response);
    }

    public override Task<DeleteClientResponse> DeleteClient(DeleteClientRequest request, ServerCallContext context)
    {
        var response = new DeleteClientResponse();
        
        try
        {
            _db.Delete(request.ClientId);
        }
        catch (Exception ex)
        {
            LogError(ex);
            response.ErrCode = (int)ErrorCodes.Create;
            response.ErrMessage = $"Ошибка удаления клиента {request.ClientId}";
        }

        return Task.FromResult(response);
    }

}
