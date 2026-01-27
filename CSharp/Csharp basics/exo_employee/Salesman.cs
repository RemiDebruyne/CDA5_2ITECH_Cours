using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_employee;

public class Salesman : Employee
{
    public int Revenue { get; set; }
    public int PercentComission { get; set; }

    public Salesman() : base()
    {

    }

    public Salesman(int id, string service, string category, string name, int salary) : base(id, service, category, name, salary)
    {

    }

    public override string ToString()
    {
        return $"{Name} \n" +
            $"fix salary : {Salary} euros \n " +
            $"comission : {Revenue * PercentComission / 100} ";
    }
}
