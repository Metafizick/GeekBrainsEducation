using ClientServiceProtos;
using ClinicService.DAL.Interfaces;
using ClinicService.Data;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using PetServiceProtos;
using System.Runtime.CompilerServices;
using static PetServiceProtos.PetService;

namespace ClinicService.Services;

[Authorize]
public class PetService : PetServiceBase
{
    private readonly IPetRepository _db;
    private readonly ILogger<PetService> _logger;

    private void LogError(Exception ex, [CallerMemberName] string methodName = null!)
        => _logger.LogError(ex, "Ошибка выполнения {methodName}", methodName);
    public PetService(IPetRepository db, ILogger<PetService> logger)
     => (_db, _logger) = (db, logger);

    public override Task<PetServiceProtos.GetPetByIdResponse> GetPetById(PetServiceProtos.GetPetByIdRequest request, ServerCallContext context)
    {
        var response = new GetPetByIdResponse();
        try
        {
            var pet = _db.GetById(request.PetId);
            response.Pet = new PetResponse()
            {
                PetId = pet.PetId,
                ClientId = pet.ClientId,
                Name = pet.Name,
                Birthday = Timestamp.FromDateTime(pet.Birthday.ToUniversalTime())
            };
        }
        catch (Exception ex)
        {
            LogError(ex);
            response.ErrCode = (int)ErrorCodes.Get;
            response.ErrMessage = $"Ошибка получения питомца {request.PetId}";
        }

        return Task.FromResult(response);
    }

    public override Task<GetPetsResponse> GetClientPets(GetPetsRequest request, ServerCallContext context)
    {
        var response = new GetPetsResponse();

        try
        {
            response.Pets.AddRange(_db.GetByClient(request.ClientId).Select(pet => new PetResponse
            {
                PetId = pet.PetId,
                ClientId= pet.ClientId,
                Name= pet.Name,
                Birthday= Timestamp.FromDateTime(pet.Birthday.ToUniversalTime())
            }).ToList());
        }
        catch (Exception ex)
        {
            LogError(ex);
            response.ErrCode = (int)ErrorCodes.Get;
            response.ErrMessage = $"Ошибка получения питомцев для клиента {request.ClientId}";

        }

        return Task.FromResult(response);
    }

    public override Task<CreatePetResponse> CreatePet(CreatePetRequest request, ServerCallContext context)
    {
        var response = new CreatePetResponse();

        try
        {
            var pet = new Pet
            {
                ClientId = request.ClientId,
                Name = request.Name,
                Birthday = request.Birthday.ToDateTime()
            };
            _db.Add(pet);
            response.PetId = pet.PetId;
        }
        catch (Exception ex)
        {
            LogError(ex);
            response.ErrCode = (int)ErrorCodes.Create;
            response.ErrMessage = $"Ошибка создания питомца";
        }

        return Task.FromResult(response);
    }

    public override Task<UpdatePetResponse> UpdatePet(UpdatePetRequest request, ServerCallContext context)
    {
        var response = new UpdatePetResponse();

        try
        {
            var pet = new Pet
            {
                PetId = request.PetId,
                ClientId = request.ClientId,
                Name = request.Name,
                Birthday = request.Birthday.ToDateTime()
            };
            _db.Update(pet);
        }
        catch (Exception ex)
        {
            LogError(ex);
            response.ErrCode = (int)ErrorCodes.Create;
            response.ErrMessage = $"Ошибка изменения питомца {request.PetId}";
        }

        return Task.FromResult(response);
    }

    public override Task<DeletePetResponse> DeletePet(DeletePetRequest request, ServerCallContext context)
    {
        var response = new DeletePetResponse();

        try
        {
            _db.Delete(request.PetId);
        }
        catch (Exception ex)
        {
            LogError(ex);
            response.ErrCode = (int)ErrorCodes.Create;
            response.ErrMessage = $"Ошибка удаления питомца {request.PetId}";
        }

        return Task.FromResult(response);
    }
}
