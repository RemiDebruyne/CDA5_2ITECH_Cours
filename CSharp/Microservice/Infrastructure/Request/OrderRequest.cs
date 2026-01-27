using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Request;
public class OrderRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public List<int> ProductIds { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime DeliveryDate { get; set; }
}
