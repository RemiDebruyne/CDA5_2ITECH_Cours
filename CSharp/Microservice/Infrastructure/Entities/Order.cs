using Infrastructure.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities;
public class Order : BaseEntity
{
    public int UserId { get; set; }

    public List<int> ProductIds { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime DeliveryDate { get; set; }
}
