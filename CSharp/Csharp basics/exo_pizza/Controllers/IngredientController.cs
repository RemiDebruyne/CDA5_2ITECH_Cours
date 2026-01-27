using Microsoft.AspNetCore.Mvc;
using Utilities.Dto;
using Utilities.Entities;
using Utilities.Interfaces;
using Utilities.Reppository;
using Utilities.Request;

namespace exo_pizza.Controllers
{
    [ApiController]
    [Route("/api/ingredients")]
    public class IngredientController(IIngredientRepository ingredientRepository) : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll()
        {
            return Ok(ingredientRepository.GetAll());
        }

        [HttpPost]
        public ActionResult<Pizza> Create([FromBody] IngredientRequest ingredientRequest)
        {
            var createdIngredient = ingredientRepository.Add(new Ingredient()
            {
                Name = ingredientRequest.Name,
                Description = ingredientRequest.Description,
            });

            if (createdIngredient == null) return BadRequest();


            ingredientRepository.SaveChanges();

            return Ok(IngredientDto.FromIngredient(createdIngredient));
        }

        [HttpGet("${ingredientId}")]
        public ActionResult<Pizza> GetOne([FromRoute] int ingredientId)
        {
            var ingredient = ingredientRepository.GetById(ingredientId);

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(IngredientDto.FromIngredient(ingredient));
        }

        [HttpDelete]
        public ActionResult Delete(Ingredient ingredient)
        {
            ingredientRepository.Delete(ingredient);
            ingredientRepository.SaveChanges();


            return NoContent();
        }

        [HttpPatch]
        public ActionResult<Pizza> Update(IngredientRequest ingredientRequest)
        {
            if (ingredientRepository.GetById(ingredientRequest.Id) == null)
            {
                return BadRequest();
            }




            ingredientRepository.Update(ingredientRequest.Id, new Ingredient()
            {
                Name = ingredientRequest.Name,
                Description = ingredientRequest.Description,
            });

            ingredientRepository.SaveChanges();

            return NoContent();
        }

    }
}
