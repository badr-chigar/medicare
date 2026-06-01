using MediCare.Models;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Data;

public class MediCareContext : DbContext
{
    public MediCareContext(DbContextOptions<MediCareContext> options) : base(options) { }

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Medecin> Medecins => Set<Medecin>();
    public DbSet<Chambre> Chambres => Set<Chambre>();
    public DbSet<Materiel> Materiels => Set<Materiel>();
    public DbSet<Facture> Factures => Set<Facture>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Facture>().Property(f => f.Montant).HasColumnType("decimal(12,2)");
    }
}
