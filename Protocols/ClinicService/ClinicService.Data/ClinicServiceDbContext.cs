using Microsoft.EntityFrameworkCore;

namespace ClinicService.Data;

public class ClinicServiceDbContext : DbContext
{

    public virtual DbSet<Client> Clients { get; set; } = default!;
    public virtual DbSet<Pet> Pets { get; set; } = default!;
    public virtual DbSet<Consultation> Consultations { get; set; } = default!;
    public virtual DbSet<Account> Accounts { get; set; } = default!;
    public virtual DbSet<AccountSession> AccountSessions { get; set; } = default!;

    public ClinicServiceDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Consultation>()
            .HasOne(p => p.Pet)
            .WithMany(c => c.Consultations)
            .HasForeignKey(p => p.PetId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
