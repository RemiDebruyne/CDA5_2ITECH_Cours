using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto;
public class UserDto
{
    public int Id { get;set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public List<int> OrderIds {  get; set; }

    public List<OrderDto> Orders { get; set; }

    public static UserDto FromUser(User user, List<OrderDto> orders = null)
    {
        return new UserDto()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            OrderIds = orders is null ? user.OrderIds : null,
            Orders = orders
        };
    }
}
