using Cyrela.DAL.Context;
using Cyrela.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cyrela.DAL
{
    public class HomeAddressDAL
    {
        private readonly DataBaseContext context;

        public HomeAddressDAL()
        {
            context = new DataBaseContext();
        }

        public void Update(HomeAddress homeAddress)
        {
            context.HomeAddress.Update(homeAddress);
            context.SaveChanges();
        }
    }
}