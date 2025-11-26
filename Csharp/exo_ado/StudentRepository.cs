using Azure.Core;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace exo_ado;

public class StudentRepository
{
    private string _connectionString = "Data Source=(localdb)\\exo_db;Initial Catalog=exo_db;Integrated Security=True";
    private List<string> _queryParams = ["Id", "FirstName", "LastName", "ClassNumber", "GraduationDate"];

    public List<Student> GetAll()
    {
        List<Student> students = [];
        Console.Write($"");
        using SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        string request = "Select * FROM Student";

        using (SqlCommand cmd = new SqlCommand(request, connection))
        {
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    ClassNumber = reader.GetInt32(3),
                    GraduationDate = reader.GetDateTime(4)
                });
            }
        }

        return students;
    }

    public Student GetSutdent(int id, int? classNumber = null)
    {
        Student student = new();
        using SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        string request = "Select * FROM Student Where id=@id";

        if(classNumber is not null)
        {
            request += " AND ClassNumber=@ClassNumber";
        }

        SqlCommand cmd = new SqlCommand(request, connection);

        cmd.Parameters.AddWithValue("@id", id);

        if(classNumber is not null)
        {
            cmd.Parameters.AddWithValue("@ClassNumber", classNumber);
        }
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            student.Id = reader.GetInt32(0);
            student.FirstName = reader.GetString(1);
            student.LastName = reader.GetString(2);
            student.ClassNumber = reader.GetInt32(3);
            student.GraduationDate = reader.GetDateTime(4);
        }

        return student;
    }

    public Student GetById(int id)
    {
        Student student = new();
        using SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        string request = "Select * FROM Student Where id=@id";

        SqlCommand cmd = new SqlCommand(request, connection);

        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            student.Id = reader.GetInt32(0);
            student.FirstName = reader.GetString(1);
            student.LastName = reader.GetString(2);
            student.ClassNumber = reader.GetInt32(3);
            student.GraduationDate = reader.GetDateTime(4);
        }

        return student;
    }

    public bool Add(Student student)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "INSERT INTO Student (FirstName, LastName, ClassNumber, GraduationDate) VALUES (@FirstName, @LastName, @ClassNumber, @GraduationDate)";

        SqlTransaction transaction = connection.BeginTransaction();
        SqlCommand cmd = new SqlCommand(query, connection, transaction);

        //cmd.Parameters.AddWithValue($"@{queryParam}", type(Student).GetFie(queryParam).GetValue(student));
        cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
        cmd.Parameters.AddWithValue("@LastName", student.LastName);
        cmd.Parameters.AddWithValue("@ClassNumber", student.ClassNumber);
        cmd.Parameters.AddWithValue("@GraduationDate", student.GraduationDate);


        if (cmd.ExecuteNonQuery() == 1)
        {
            transaction.Commit();
        }
        else
        {
            transaction.Rollback();
            return false;
        }

        return true;

    }

    public bool Delete(int id)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string request = "DELETE FROM Student Where id=@id";

        SqlTransaction transaction = connection.BeginTransaction();
        SqlCommand cmd = new SqlCommand(request, connection, transaction);

        cmd.Parameters.AddWithValue("@id", id);

        if (cmd.ExecuteNonQuery() == 1)
        {
            transaction.Commit();
        }
        else
        {
            transaction.Rollback();
            return false;
        }

        return true;
    }

    public bool Update(int id, Student student)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        string request = $"Update Student SET FirstName = @FirstName, LastName=@LastName, ClassNumber=@ClassNumber, GraduationDate=@GraduationDate";

        SqlTransaction transaction = connection.BeginTransaction();
        SqlCommand command = new(request, connection, transaction);

        command.Parameters.AddWithValue("@FirstName", student.FirstName);
        command.Parameters.AddWithValue("@LastName", student.LastName);
        command.Parameters.AddWithValue("@ClassNumber", student.ClassNumber);
        command.Parameters.AddWithValue("@GraduationDate", student.GraduationDate);

        if (command.ExecuteNonQuery() == 1)
        {
            transaction.Commit();
        }
        else
        {
            transaction.Rollback();
            return false;
        }

        return true;

    }

}
