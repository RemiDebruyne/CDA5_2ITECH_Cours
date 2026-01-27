
using Microsoft.AspNetCore.Mvc;
using Utilities.Dto;
using Utilities.Entities;
using Utilities.Interfaces;
using Utilities.Request;

namespace exo_pizza.Controllers;

[ApiController]
[Route("/api/pizza")]
public class PizzaController(
    IPizzaRepository pizzaRepository, 
    IIngredientRepository ingredientRepository) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return Ok(pizzaRepository.GetAll());
    }

    [HttpPost]
    public ActionResult<Pizza> Create([FromBody] PizzaRequest pizzaRequest)
    {
        var ingredients = ingredientRepository.GetAllwithIds(pizzaRequest.IngredientsId);

        var createdPizza = pizzaRepository.Add(new Pizza()
        {
            Name = pizzaRequest.Name,
            Description = pizzaRequest.Description,
            Ingredients = ingredients,
        });

        if (createdPizza == null) return BadRequest();
        

        pizzaRepository.SaveChanges();

        return Ok(PizzaDto.FromPizza(createdPizza));
    }

    [HttpGet("${pizzId}")]
    public ActionResult<Pizza> GetOne([FromRoute] int pizzaId)
    {
        var pizza = pizzaRepository.GetById(pizzaId);

        if(pizza == null)
        {
            return NotFound();
        }

        return Ok(PizzaDto.FromPizza(pizza));
    }

    [HttpDelete]
    public ActionResult Delete(Pizza pizza)
    {
        pizzaRepository.Delete(pizza);
        pizzaRepository.SaveChanges();


        return NoContent();
    }

    [HttpPatch]
    public ActionResult<Pizza> Update(PizzaRequest pizzaRequest)
    {
        if(pizzaRepository.GetById(pizzaRequest.Id) == null)
        {
            return BadRequest();
        }


        var ingredients = ingredientRepository.GetAllwithIds(pizzaRequest.IngredientsId);


        pizzaRepository.Update(pizzaRequest.Id, new Pizza()
        {
            Name = pizzaRequest.Name,
            Description = pizzaRequest.Description,
            Ingredients = ingredients,
        });

        pizzaRepository.SaveChanges();

        return NoContent();
    }
}
