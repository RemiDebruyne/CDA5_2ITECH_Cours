using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilities.Entities.AdoEntities;

namespace Utilities.Reppository.AdoRepository;

public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
{
    protected string _connectionString = "Data Source=(localdb)\\exo_db;Initial Catalog=exo_db;Integrated Security=True";

    protected List<string> _queryParameters = typeof(T).GetProperties()
        .Where(
            // Enlève la propriété Id car elle est définie automatiquement par la base de donnée
            p => p.Name != "Id" &&

            // Je n'ai pas réussi à faire un générique pour enlever tous les Enumerables/Listes.
            p.PropertyType != typeof(List<Orders>) && 
            p.PropertyType != typeof(List<Loan>))
        .Select(field => field.Name).ToList();

    public bool Add(T entity)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = $"INSERT INTO {typeof(T).Name} ({string.Join(", ", _queryParameters)}) VALUES ({string.Join(", ", _queryParameters.Select(queryParam => $"@{queryParam}"))})";

        SqlTransaction transaction = connection.BeginTransaction();
        SqlCommand cmd = new SqlCommand(query, connection, transaction);

        foreach (var queryParam in _queryParameters)
        {
            cmd.Parameters.AddWithValue($"@{queryParam}", typeof(T).GetProperty(queryParam).GetValue(entity));
        }

        //try
        //{
        //    if (cmd.ExecuteNonQuery() == 1)
        //    {
        //        transaction.Commit();
        //    }
        //}
        //catch
        //{
        //    transaction.Rollback();
        //    return false;
        //}

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

    public virtual bool Delete(int id, SqlConnection connection, SqlTransaction transaction)
    {
        //using SqlConnection connection = new SqlConnection(_connectionString);
        //connection.Open();
        string request = $"DELETE FROM {typeof(T).Name} Where Id=@id";

        //SqlTransaction transaction = connection.BeginTransaction();
        SqlCommand cmd = new SqlCommand(request, connection, transaction);

        cmd.Parameters.AddWithValue("@id", id);

        if (cmd.ExecuteNonQuery() != 1)
        {
            return false;
        }

        return true;
    }

    public List<T> GetAll(Dictionary<string, string>? queryParameters = null)
    {
        List<T> entities = [];
        using SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        string request = $"Select * FROM {nameof(T)}";

        if(queryParameters.Count != 0)
        {
            request = $"{request} WHERE ";
            foreach(var queryParameter in queryParameters)
            {
                request += $"{queryParameter.Key}=@{queryParameter.Key}";
            }
        }

        SqlCommand cmd = new SqlCommand(request, connection);

        foreach (var queryParameter in queryParameters)
        {
            cmd.Parameters.AddWithValue($"@{queryParameter.Key}", queryParameter.Value);
        }

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {


            entities.Add(CreateInstance(reader));
        }


        return entities;
    }

    public T? GetById(int id)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        string request = $"Select * FROM {typeof(T).Name} Where Id=@id";

        SqlCommand cmd = new SqlCommand(request, connection);

        cmd.Parameters.AddWithValue("@id", id);
        SqlDataReader reader = cmd.ExecuteReader();

        if (!reader.HasRows)
        {
            return null;
        }

        return CreateInstance(reader);
    }

    public bool Update(int id, T entity)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        string request = $"Update {typeof(T).Name} SET {string.Join(", ", _queryParameters.Select(q => $"{q} = @{q}"))} WHERE Id=@id";

        SqlTransaction transaction = connection.BeginTransaction();
        SqlCommand command = new(request, connection, transaction);

        foreach (var queryParam in _queryParameters)
        {
            command.Parameters.AddWithValue($"@{queryParam}", typeof(T).GetProperty(queryParam).GetValue(entity));
        }

        command.Parameters.AddWithValue("@Id", id);

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

    protected static T CreateInstance(SqlDataReader reader)
    {
        T instance = new();

        var props = typeof(T).GetProperties();

        while (reader.Read())
        {
            Dictionary<string, object?> values = GetPropertiesWithValues(reader);

            foreach (var kvp in values)
            {
                var prop = props.FirstOrDefault(p => p.Name == kvp.Key);
                if (prop != null && prop.CanWrite)
                {
                    prop.SetValue(instance, kvp.Value);
                }
            }
        }
        return instance;
    }

    protected static List<T> CreateEntities(SqlDataReader reader)
    {
        List<T> entities = new();

        var props = typeof(T).GetProperties();

        while (reader.Read())
        {
            Dictionary<string, object?> values = GetPropertiesWithValues(reader);

            T entity = new();

            foreach (var kvp in values)
            {
                var prop = props.FirstOrDefault(p => p.Name == kvp.Key);
                if (prop != null && prop.CanWrite)
                {
                    prop.SetValue(entity, kvp.Value);
                }
            }

            entities.Add(entity);
        }

        return entities;
    }

    private static Dictionary<string, object?> GetPropertiesWithValues(SqlDataReader reader)
    {
        var properties = typeof(T).GetProperties().ToList().Where(p => p.PropertyType != typeof(List<Orders>) && p.PropertyType != typeof(List<Loan>));

        Dictionary<string, object?> namedProperties = [];

        foreach (var property in properties)
        {
            namedProperties.Add(property.Name, reader[property.Name]);
        }

        return namedProperties;
    }

}

