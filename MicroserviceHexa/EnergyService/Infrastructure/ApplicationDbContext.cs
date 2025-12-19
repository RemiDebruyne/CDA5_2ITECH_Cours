using EnergyApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EnergyApi.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Energy> Energies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=localhost;Database=exo;User ID=root;Password=root";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
