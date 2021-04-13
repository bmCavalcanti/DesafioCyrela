using Cyrela.Models;
using System.Collections.Generic;

// TESTING WITH MOCK
namespace Cyrela.DAL
{
    public class ClientDAL
    {
        public IList<Client> List()
        {
            List<Client> Clients = new List<Client>();
            
            for (var i = 1; i < 5; i++)
            {
                Client Client = new Client();
                Client.Id = i;
                Client.FirstName = "Bianca " + i;
                Client.LastName = "Cavalcanti " + i;
                Clients.Add(Client);
            }

            return Clients;
        }

        public Client Get(int Id)
        {
            Client client = new Client();

            client.Id = Id;
            client.FirstName = "Bianca " + Id;
            client.LastName = "Cavalcanti " + Id;

            return client;
        }

        public void Insert(Client client)
        {
            
        }

        public void Update(Client client)
        {
            
        }

        public void Delete(int Id)
        {

        }
    }
}