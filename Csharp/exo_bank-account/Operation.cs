using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_bank_account;

public class Operation
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public Status Status { get; set; }
}

public enum Status
{
    Deppot,
    Withdrawal
}
