using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities;

namespace Utilities.Dto;

public class PizzaDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }

    public List<IngredientDto> Ingredients { get; set; }

    public static PizzaDto FromPizza(Pizza pizza)
    {
        return new()
        {
            Id = pizza.Id,
            Name = pizza.Name,
            Description = pizza.Description,
            Type = pizza.Type.ToString(),
            Ingredients = [..pizza.Ingredients.Select(ingredient => 
                new IngredientDto() {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    Description = ingredient.Description,
                })]

        };
    }
}
