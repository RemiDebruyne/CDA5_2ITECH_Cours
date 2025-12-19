using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WasteApi.Domain.Entities;

namespace WasteApi.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Waste> Wastes{ get; set; }

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
