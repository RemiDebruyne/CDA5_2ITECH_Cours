using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;
using Utilities.Interfaces;

namespace Utilities.Reppository
{
    public class IngredientRepository(ApplicationDbContext context) : EfRepository<Ingredient>(context), IIngredientRepository
    {
        public List<Ingredient> GetAllwithIds(List<int> ingredients)
        {
            return [.. DbSet.Where(ingredient => ingredients.Contains(ingredient.Id))];
        }
    }
}
