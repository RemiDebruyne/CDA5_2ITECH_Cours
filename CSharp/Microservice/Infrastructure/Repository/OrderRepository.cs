using Infrastructure.Entities;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository;
public class OrderRepository(IApplicationDbContext context) : BaseRepository<Order>(context), IOrderRepository
{
    public async  Task<List<Order>> GetAllByUserIdAsync(int userId)
    {
        return await DbSet.Where(order => order.UserId == userId).ToListAsync();
    }
}
