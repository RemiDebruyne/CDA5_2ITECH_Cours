using Infrastructure.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }

    public string Email { get; set; }

    public List<int> OrderIds { get; set; }
}
