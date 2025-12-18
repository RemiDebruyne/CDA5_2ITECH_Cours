
using Infrastructure;
using Infrastructure.Dto;
using Infrastructure.Entities;
using Infrastructure.Interface;
using Infrastructure.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OrderService.Controllers;
[Route("api/orders")]
[ApiController]
public class OrderController(IOrderRepository orderRepository) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<OrderDto>>> GetAll([FromQuery] int userId)
    {
        if(userId == 0)
        {
            return Ok(await orderRepository.GetAllAsync());
        }

        return Ok(await orderRepository.GetAllByUserIdAsync(userId));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<string>> GetById([FromRoute] int id)
    {
        var order = await orderRepository.GetByIdAsync(id);

        if(order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> Post([FromBody] OrderRequest request)
    {
        var order = await orderRepository.AddAsync(new Order
        {
            UserId = request.UserId,
            ProductIds = request.ProductIds,

        });

        if(order is null)
        {
            return BadRequest();
        }

        return Ok(order);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] OrderRequest request)
    {
        orderRepository.Update(id, new Order()
        {
            DeliveryDate = request.DeliveryDate,
            OrderDate = request.OrderDate,
            ProductIds = request.ProductIds,
            UserId = request.UserId
        });

        await orderRepository.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var order = await orderRepository.GetByIdAsync(id);

        if (order is null) return BadRequest();

        orderRepository.Delete(order);

        await orderRepository.SaveChangesAsync();
        return NoContent();
    }
}
