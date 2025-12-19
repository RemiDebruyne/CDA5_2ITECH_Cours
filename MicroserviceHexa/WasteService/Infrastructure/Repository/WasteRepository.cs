using WasteApi.Domain.Entities;
using WasteApi.Domain.Ports;

namespace WasteApi.Infrastructure.Repository;

public class WasteRepository(ApplicationDbContext context) : Repository<Waste>(context), IWasteRepository
{
}
