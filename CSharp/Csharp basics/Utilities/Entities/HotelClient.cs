using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entities;

public class HotelClient : Entity
{
    public string Name { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public List<Reservartion> Reservartions { get; set; }
}
