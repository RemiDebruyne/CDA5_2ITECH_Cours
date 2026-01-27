using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto;
public class UserWithOrderDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public List<OrderDto> Orders { get; set; }

    public static UserWithOrderDto FromUser(User user, List<OrderDto> orders)
    {
        return new UserWithOrderDto()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Orders = orders,
        };
    }
}
