using ClinicService.DAL.Interfaces;
using ClinicService.Data;

namespace ClinicService.DAL;

public class ClientRepository : IClientRepository
{
    private readonly ClinicServiceDbContext _db;
    private readonly ILogger<ClientRepository> _logger;

    public ClientRepository(ClinicServiceDbContext db, ILogger<ClientRepository> logger)
        => (_db, _logger) = (db, logger);

    public IList<Client> GetAll()
    {
        return _db.Clients.ToList();
    }

    public Client GetById(int id)
    {
        var result = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        if (result is null)
            throw new KeyNotFoundException();

        return result;
    }

    public int Add(Client entity)
    {
        _db.Clients.Add(entity);
        _db.SaveChanges();
        return entity.ClientId;
    }

    public void Update(Client entity)
    {
        if (entity == null)
            throw new NullReferenceException();

        var client = GetById(entity.ClientId);
        if (client == null)
            throw new KeyNotFoundException();

        client.Document = entity.Document;
        client.Surname = entity.Surname;
        client.FirstName = entity.FirstName;
        client.Patronymic = entity.Patronymic;

        _db.Update(client);
        _db.SaveChanges();
    }

    public void Delete(Client entity)
    {
        if (entity == null)
            throw new NullReferenceException();

        Delete(entity.ClientId);
    }

    public void Delete(int id)
    {
        var client = GetById(id);
        
        if (client == null)
            throw new KeyNotFoundException();
        
        _db.Remove(client);
        _db.SaveChanges();
    }
}
