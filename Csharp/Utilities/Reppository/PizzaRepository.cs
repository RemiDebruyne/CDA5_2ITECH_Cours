using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;
using Utilities.Interfaces;

namespace Utilities.Reppository;

public class PizzaRepository(ApplicationDbContext context) : EfRepository<Pizza>(context),  IPizzaRepository
{
    public List<Pizza> GetAllWithIngredients(int id)
    {
        return [.. DbSet
                .Where(pizza => pizza.Id == id)
                .Include(pizza => pizza.Ingredients)
            ];
    }

}
