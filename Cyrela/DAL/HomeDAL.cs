using Cyrela.DAL.Context;
using Cyrela.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            return context.Home
                .Include(e => e.HomeStatus)
                .Include(e => e.HomeAddress)
                .Include(e => e.HomeAddress.City)
                .Include(e => e.HomeAddress.City.State)
                .Include(e => e.Client)
                .FirstOrDefault(e => e.Id == Id)
            ;
        }

        public void Update(Home home)
        {
            context.Home.Update(home);
            context.SaveChanges();
        }
    }
}