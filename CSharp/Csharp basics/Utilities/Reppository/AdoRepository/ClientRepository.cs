using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Entities.AdoEntities;

namespace Utilities.Reppository.AdoRepository;

public class ClientRepository : BaseRepository<Client>
{
    private OrderRepository _orderRepository = new();

    public bool DeleteUser(int id)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();


        string request = $"DELETE FROM Orders WHERE ClientId=@id";

        SqlCommand cmd = new SqlCommand(request, connection, transaction);

        cmd.Parameters.AddWithValue("@Id", id);

        cmd.ExecuteNonQuery();

        bool isUserDelete = Delete(id, connection, transaction);

        if (isUserDelete)
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

    public Client? GetClientByIdWithOrders(int id)
    {
        Client client = GetById(id);

        if (client is null)
        {
            return null;
        }

        client.Orders = _orderRepository.GetByClientId(id);

        return client;
    }
}
