using Cyrela.Models;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Configuration;

// TESTING WITH MOCK
namespace Cyrela.DAL
{
    public class ClientDAL
    {
        public IList<Client> List()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CyrelaConnection"].ConnectionString;
         
            OracleConnection Connection = new OracleConnection(connectionString);
            Connection.Open();
         
            OracleCommand Command = new OracleCommand("SELECT * FROM T_USER", Connection);
            OracleDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                var name = Reader[1].ToString();
            }

            Reader.Close();

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