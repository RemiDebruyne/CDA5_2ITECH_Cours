using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_ado_2.Entity;

public class Client : Entity
{
    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Address { get; set; }
    
    public string PostCode { get; set; }
    
    public string City { get; set; }

    public string PhoneNumber { get; set; }

    public List<Orders> Orders { get; set; }

    public override string ToString()
    {
        var ordersInfo = Orders != null && Orders.Any()
            ? string.Join(", ", Orders.Select(o => o.ToString()))
            : "No orders";

        return $"Firstname: {Firstname}, " +
               $"Lastname: {Lastname}, " +
               $"Address: {Address}, " +
               $"PostCode: {PostCode}, " +
               $"City: {City}, " +
               $"PhoneNumber: {PhoneNumber}, " +
               $"Orders: {ordersInfo}";
    }
}
