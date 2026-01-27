using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_bank_account;

public abstract class BankAccount
{
    public int Id { get; set; }
    public int Sold { get; set; }
    public Client Client { get; set; }
    public List<Operation> Operations { get; set; }

    public void Depot(int amount)
    {
        Sold += amount;

        var operation = new Operation
        {
            Amount = amount,
            Id = 1,
            Status = Status.Deppot
        };

        Operations.Add(operation);
    }

    public void Withdrawal(int amount)
    {
        Sold -= amount;
        var operation = new Operation
        {
            Amount = amount,
            Id = 1,
            Status = Status.Withdrawal
        };

        Operations.Add(operation);
    }

    public void DisplayOperation()
    {
        foreach(var operation in Operations)
        {
            Console.WriteLine($"Operation {operation.Id} ({operation.Status}) : {operation.Amount}");
        }
    }

    public void DisplaySold()
    {
        Console.WriteLine($"Sold for account n° {Id} :{Sold}");
    }
}
