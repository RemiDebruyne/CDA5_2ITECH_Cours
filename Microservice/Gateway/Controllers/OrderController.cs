using Infrastructure;
using Infrastructure.Dto;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gateway.Controllers;
[Route("api/orders")]
[ApiController]
public class OrderController : ControllerBase
{
    private RestClient<UserDto> _userClient = new("http://localhost:5055/api");
    private RestClient<OrderDto> _orderClient = new("http://localhost:5103/api");
    private RestClient<ProductDto> _productClient = new("http://localhost:5059/api");

    [HttpGet]
    public async Task<ActionResult<List<OrderDto>>> Get([FromQuery] int userId)
    {
        var orderDtos = await _orderClient.GetListRequest($"/orders?userId={userId}");

        Dictionary<int, ProductDto> fetchedProduct = [];

        foreach (var order in orderDtos)
        {
            foreach (int productId in order.ProductIds)
            {
                if (!fetchedProduct.ContainsKey(productId))
                {
                    ProductDto productDto = await _productClient.GetRequest($"/products/{productId}");

                    fetchedProduct.Add(productId, productDto);
                }

                if(order.Products is null) order.Products = [];

                order.Products.Add(fetchedProduct[productId]);
            }
        }

        return Ok(orderDtos);
    }

    // GET api/<OrderController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    // POST api/<OrderController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<OrderController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<OrderController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
