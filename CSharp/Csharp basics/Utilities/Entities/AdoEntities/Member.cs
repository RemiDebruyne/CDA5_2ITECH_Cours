using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entities.AdoEntities;

public class Member
{
    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime Registration { get; set; }

    public List<Loan> Loans { get; set; }
}
