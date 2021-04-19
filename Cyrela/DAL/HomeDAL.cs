using Cyrela.DAL.Context;
using Cyrela.Models;

namespace Cyrela.DAL
{
    public class HomeDAL
    {
        private readonly DataBaseContext context;

        public HomeDAL()
        {
            context = new DataBaseContext();
        }

        public Home Get(int Id)
        {
            return context.Home.Find(Id);
        }
    }
}