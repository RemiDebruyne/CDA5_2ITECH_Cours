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

    public Employee(int id, string service, string category, string name, int salary)
    {
        Id = id;
        Service = service;
        Category = category;
        Name = name;
        Salary = salary;
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

    public static void AddEmployee(Employee employee)
    {
        if(Employees.Any(e => e.Id == employee.Id))
        {
            Console.WriteLine("Employee with this id already exists");
        } else
        {
            Employees.Add(employee);
        }
    }

    public static void GetEmployee(int id)
    {
        var employee = Employees.Where(employee => employee.Id == id);
        Console.WriteLine(employee);
    }
}
