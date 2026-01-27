using exo_employee;

var jean = new Employee()
{
    Name = "Jean",
    Salary = 2000
};
var pierre = new Employee()
{
    Name = "Pierre",
    Salary = 1000
};

foreach( var employee in Employee.Employees)
{
    employee.DisplaySalary();
}

Employee.TotalEmployeesSalary();
