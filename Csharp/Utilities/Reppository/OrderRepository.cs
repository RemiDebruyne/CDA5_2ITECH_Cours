using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entity;

namespace Utilities.Reppository;

public class OrderRepository : BaseRepository<Orders>
{

    public List<Orders> GetByClientId(int id)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string request = "Select * FROM Orders WHERE ClientId = @clientId";
        SqlCommand cmd = new SqlCommand(request, connection);

        cmd.Parameters.AddWithValue("@clientId", id);

        SqlDataReader reader = cmd.ExecuteReader();

        if (!reader.HasRows)
        {
            return [];
        }

        return CreateEntities(reader);
    }
}
