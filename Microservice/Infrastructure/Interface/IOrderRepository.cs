using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface;
public interface IOrderRepository : IRepository<Order>
{
    Task<List<Order>> GetAllByUserIdAsync(int userId);
}
