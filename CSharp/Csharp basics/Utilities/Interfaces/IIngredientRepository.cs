using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace Utilities.Interfaces;

public interface IIngredientRepository : IEfRepository<Ingredient,int>
{
    List<Ingredient> GetAllwithIds(List<int> ingredients);
}
