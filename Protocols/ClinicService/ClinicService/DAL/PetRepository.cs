using ClinicService.DAL.Interfaces;
using ClinicService.Data;
using Microsoft.EntityFrameworkCore;
using static Grpc.Core.Metadata;

namespace ClinicService.DAL;

public class PetRepository : IPetRepository
{
    private readonly ClinicServiceDbContext _db;
    private readonly ILogger<PetRepository> _logger;

    public PetRepository(ClinicServiceDbContext db, ILogger<PetRepository> logger)
        => (_db, _logger) = (db, logger);

    public IList<Pet> GetAll()
    {
        return _db.Pets.ToList();
    }

    public Pet GetById(int id)
    {
        var result = _db.Pets.FirstOrDefault(p => p.PetId == id);
        if (result is null)
            throw new KeyNotFoundException();

        return result;
    }

    public IList<Pet> GetByClient(int clientId)
    {
        return _db.Pets.Where(p => p.ClientId == clientId).ToList();
    }

    public int Add(Pet entity)
    {
        _db.Pets.Add(entity);
        _db.SaveChanges();
        return entity.ClientId;
    }

    public void Update(Pet entity)
    {
        if (entity == null)
            throw new NullReferenceException();

        var pet = GetById(entity.PetId);
        if (pet == null)
            throw new KeyNotFoundException();

        pet.ClientId = entity.ClientId;
        pet.Birthday = entity.Birthday;
        pet.Name = entity.Name;

        _db.Update(pet);
        _db.SaveChanges();
    }

    public void Delete(Pet entity)
    {
        if (entity == null)
            throw new NullReferenceException();

        Delete(entity.PetId);
    }

    public void Delete(int id)
    {
        var pet = GetById(id);

        if (pet == null)
            throw new KeyNotFoundException();

        _db.Remove(pet);
        _db.SaveChanges();
    }
}
