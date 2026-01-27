using exo_ado;
using Microsoft.Data.SqlClient;
using System.Data;

//string connectionString = "Data Source=(localdb)\\exo_db;Initial Catalog=exo_db;Integrated Security=True";

//var connection = new SqlConnection(connectionString);

//connection.Open();

//if(connection.State == ConnectionState.Open)
//{
//    Console.WriteLine("Connexion ouverte");
//} else
//{
//    Console.WriteLine("Un problème est survenu");
//}

//connection.Close();
var repository = new StudentRepository();

void addStudent(Student student)
{
    if (repository.Add(student))
    {
        Console.WriteLine($"Student : {student.FirstName} {student.LastName} was added");
    }
    else
    {
        Console.WriteLine($"An error occured while adding student {student.FirstName} {student.LastName}");
    };

}


var student1 = new Student
{
    FirstName = "Jean",
    LastName = "Bon",
    ClassNumber = 1,
    GraduationDate = DateTime.Now.AddYears(-4)
};

var student2 = new Student
{
    FirstName = "Sarah",
    LastName = "Croche",
    ClassNumber = 2,
    GraduationDate = DateTime.Now.AddYears(-10)
};

//addStudent(student1);
//addStudent(student2);

List<Student> students = repository.GetAll();

//foreach (var student in students)
//{
//    Console.WriteLine(student);
//}

Console.WriteLine(repository.GetById(9));

repository.Delete(9);

students = repository.GetAll();

foreach (var student in students)
{
    Console.WriteLine(student);
}