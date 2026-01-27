using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Request;
public class UserRequest
{
    public string Name { get; set; }

    public string Email { get; set; }

    public List<int> OrderIds { get; set; } = [];
}
