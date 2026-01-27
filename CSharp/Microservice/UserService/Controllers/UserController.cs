using Infrastructure.Repository;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Dto;
using Infrastructure;
using Infrastructure.Request;
using Infrastructure.Entities;

namespace UserService.Controllers;
[Route("api/users")]
[ApiController]
public class UserController(IUserRepository userRepository) : ControllerBase
{

    private RestClient<OrderDto> _orderClient = new("http://localhost:5103/api");
    private RestClient<ProductDto> _productClient = new("http://localhost:5059/api");

    [HttpGet("/{userId}")]

    public async Task<ActionResult<List<UserDto>>> Get(
        [FromRoute] int userId,
        [FromQuery] bool includeOrder)
    {
        var user = await userRepository.GetByIdAsync(userId);

        if(user is null)
        {
            return NotFound();
        }

        if (!includeOrder)
        {
            return Ok(UserDto.FromUser(user));
        }

        List<OrderDto> orderDtos = await _orderClient.GetListRequest($"/orders?userId={user.Id}");

        Dictionary<int, ProductDto> fetchedProduct = [];

        foreach(var order in orderDtos)
        {
            foreach(int productId in order.ProductIds)
            {
                if (!fetchedProduct.ContainsKey(productId))
                {
                    ProductDto productDto = await _productClient.GetRequest($"/orders/{productId}");

                    fetchedProduct.Add(productId, productDto);
                }

                order.Products.Add(fetchedProduct[productId]);
            }
        }

        return Ok(UserDto.FromUser(user, orderDtos));
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Add([FromBody] UserRequest request)
    {
        var user = await userRepository.AddAsync(new User()
        {
            Name = request.Name,
            Email = request.Email,
            OrderIds = request.OrderIds,
        });

        return Ok(UserDto.FromUser(user));
    }

}
