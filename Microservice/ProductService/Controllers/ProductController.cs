using Infrastructure.Dto;
using Infrastructure.Entities;
using Infrastructure.Interface;
using Infrastructure.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers;
[Route("api/products")]
[ApiController]
public class ProductController(IProductRepository productRepository) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAll([FromQuery] string category, [FromQuery] string name)
    {
        var products = await productRepository.GetAllWithParams(category, name);

        return Ok(products);
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<List<ProductDto>>> GetById([FromRoute] int productId)
    {
        var product = await productRepository.GetByIdAsync(productId);

        if (product is null)
        {
            return BadRequest();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Add([FromBody] ProductRequest request)
    {
        var product = await productRepository.AddAsync(new Product
        {
            Name = request.Name,
            Category = request.Category,
            Description = request.Description,
        });


        if (product is null)
        {
            return BadRequest();
        }

        return Ok(product);
    }
}
