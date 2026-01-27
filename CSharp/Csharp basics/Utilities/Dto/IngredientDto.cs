using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace Utilities.Dto
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name {  get; set; }

        public string Description { get; set; }

        public static IngredientDto FromIngredient(Ingredient ingredient)
        {
            return new()
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Description = ingredient.Description,
            };
        }
    }
}
