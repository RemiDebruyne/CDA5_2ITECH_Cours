using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto;
public class OrderDto
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public List<int> ProductIds { get; set; } = [];

    public List<ProductDto> Products { get; set; } = [];

    public DateTime OrderDate { get; set; }

    public DateTime DeliveryDate { get; set; }

    public static OrderDto FromOrder(Order order, List<ProductDto> products = null)
    {
        return new OrderDto()
        {
            Id = order.Id,
            UserId = order.Id,
            ProductIds = products is null ? order.ProductIds : null,
            Products = products,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
        };

    }
}
