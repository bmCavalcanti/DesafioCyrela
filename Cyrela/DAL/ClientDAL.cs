using Cyrela.Models;
using Cyrela.DAL.Context;
using System.Collections.Generic;
using System.Linq;

namespace Cyrela.DAL
{
    public class ClientDAL
    {
        private readonly DataBaseContext context;

        public ClientDAL()
        {
            context = new DataBaseContext();
        }

        public IList<Client> List()
        {
            return context.Client.ToList<Client>();
        }

        public Client Get(int Id)
        {
            return context.Client.Find(Id);
        }

        public void Insert(Client client)
        {
            context.Client.Add(client);
            context.SaveChanges();
        }

        public void Update(Client client)
        {
            context.Client.Update(client);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var client = new Client() { Id = Id };

            context.Client.Remove(client);
            context.SaveChanges();
        }
    }
}