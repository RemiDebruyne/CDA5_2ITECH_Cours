using Utilities.Entities.AdoEntities;
using Utilities.Reppository.AdoRepository;

ClientRepository clientRepository = new();
OrderRepository orderRepository = new();

int clientId = 4;

Client client = new()
{
    Firstname = "Jean",
    Lastname = "Bon",
    City = "Lille",
    Address = "3 rue des berlingots",
    PhoneNumber = "00 01 02 03 04",
    PostCode = "59800"
};

clientRepository.Add(client);

List<Orders> clientOrders = [
    new(){
        ClientId = clientId,
        OrderDate = DateTime.Now,
        TotalPrice = 2
    },
    new(){
        ClientId = clientId,
        OrderDate = DateTime.Now,
        TotalPrice = 10
    }];

foreach (var order in clientOrders)
{
    orderRepository.Add(order);
}


var testClient2 = clientRepository.GetClientByIdWithOrders(clientId);

Console.WriteLine($"Info du client {clientId} :");
Console.WriteLine(testClient2 + "\n");

client.Firstname = "Paul";

clientRepository.Update(clientId, client);

Console.WriteLine("Info après update");
testClient2 = clientRepository.GetClientByIdWithOrders(clientId);
Console.WriteLine(testClient2 + "\n");


clientRepository.DeleteUser(clientId);

client = clientRepository.GetById(clientId);

if(client is null)
{
    Console.WriteLine($"Le client {clientId} à été supprimé");
}

 clientOrders = orderRepository.GetByClientId(clientId);

if(clientOrders.Count == 0)
{
    Console.WriteLine($"Les commandes du client {clientId} ont été supprimées");
}