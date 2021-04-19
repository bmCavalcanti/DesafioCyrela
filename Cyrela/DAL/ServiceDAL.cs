using Cyrela.DAL.Context;
using Cyrela.Models;

namespace Cyrela.DAL
{
    public class ServiceDAL
    {
        private readonly DataBaseContext context;

        public ServiceDAL()
        {
            context = new DataBaseContext();
        }

        public Service Get(int? Id)
        {
            return context.Service.Find(Id);
        }
    }
}