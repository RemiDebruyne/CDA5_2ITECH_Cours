using Infrastructure.Entities;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository;
public class ProductRepository(IApplicationDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    public async Task<List<Product>> GetAllWithParams(string category = "", string name = "")
    {
       return await DbSet.Where(product => product.Category == category && product.Name.Contains(name)).ToListAsync();
    }
}
