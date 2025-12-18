using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace Utilities;

public class ApplicationDbContext: DbContext, IApplicationDbContext
{
    public DbSet<Contact> Contacts { get; set; }

    public DbSet<HotelClient> HotelClients { get; set; }

    public DbSet<Reservartion> Reservations { get; set; }
    public DbSet<Room> Rooms { get; set; }

    public DbSet<Pizza> Pizzas {  get; set; }

    public DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=localhost;Database=exo;User ID=root;Password=root";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), x => x.MigrationsAssembly("Utilities"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
