using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entities;

public class Contact : Entity
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime Birthdate { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
