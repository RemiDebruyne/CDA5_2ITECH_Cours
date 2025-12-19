using TransportApi.Domain.Entities;
using TransportApi.Domain.Ports;

namespace TransportApi.Infrastructure.Repository;

public class TransportRepository(ApplicationDbContext context) : Repository<Transport>(context), ITransportRepository
{
}
