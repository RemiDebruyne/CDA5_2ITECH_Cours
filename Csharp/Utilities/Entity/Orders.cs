using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entity;

public class Orders : Entity
{
    public int ClientId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalPrice { get; set; }

    public override string ToString()
    {
        return $"Id : {Id} \n" +
            $"          Date : {OrderDate} \n" +
            $"          Total price : {TotalPrice}\n";
    }
}
