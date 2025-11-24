using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_employee;

public class Employee
{
    public int Id { get; set; }
    public string Service {  get; set; }
    public string Category { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }

    public static List<Employee> Employees { get; set; } = [];

    public void DisplaySalary()
    {
        Console.WriteLine($"{Name} : {Salary} euros");
    }

    public Employee()
    {
        Employees.Add(this);
    }

    public static void DeleteAllEmployee()
    {
        Employees.Clear();
    }

    public static void TotalEmployeesSalary()
    {
        Console.WriteLine($"Total salary of all employees is {Employees.Select(e => e.Salary).Sum()} \n");
    }

    public override string ToString()
    {
        return $"{Name} salary is {Salary} euros";
    }

    public void countEmployee()
    {
        Console.WriteLine($"There is {Employees.Count} in the company");
    }
}
