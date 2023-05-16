using ClinicService.DAL.Interfaces;
using ClinicService.Data;

namespace ClinicService.DAL;

public class ConsultationRepository : IConsultationRepository
{
    private readonly ClinicServiceDbContext _db;
    private readonly ILogger<ConsultationRepository> _logger;

    public ConsultationRepository(ClinicServiceDbContext db, ILogger<ConsultationRepository> logger)
        => (_db, _logger) = (db, logger);

    public IList<Consultation> GetAll()
    {
        return _db.Consultations.ToList();
    }

    public Consultation GetById(int id)
    {
        throw new NotImplementedException();
    }

    public int Add(Consultation item)
    {
        throw new NotImplementedException();
    }

    public void Update(Consultation item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Consultation item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}
