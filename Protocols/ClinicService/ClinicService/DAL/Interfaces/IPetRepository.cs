using ClinicService.Data;

namespace ClinicService.DAL.Interfaces
{
    public interface IPetRepository : IRepository<Pet, int>
    {
        IList<Pet> GetByClient(int clientId);
    }
}
