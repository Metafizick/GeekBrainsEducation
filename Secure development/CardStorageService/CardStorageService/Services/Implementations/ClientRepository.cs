using CardStorageService.Data;

namespace CardStorageService.Services.Implementations
{
    public class ClientRepository : IClientRepositoryService
    {
        #region Services
        private readonly CardStorageServiceDbContext _context;
        private readonly ILogger<ClientRepository> _logger;
        #endregion

        #region Constructors
        public ClientRepository(CardStorageServiceDbContext context, ILogger<ClientRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public int Create(Client data)
        {
            _context.Clients.Add(data);
            _context.SaveChanges();
            return data.ClientId;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Client GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Client data)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
