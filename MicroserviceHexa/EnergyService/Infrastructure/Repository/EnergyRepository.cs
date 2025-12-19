using EnergyApi.Domain.Entities;
using EnergyApi.Domain.Ports;

namespace EnergyApi.Infrastructure.Repository;

public class EnergyRepository(ApplicationDbContext context) : Repository<Energy>(context), IEnergyRepository
{
}
