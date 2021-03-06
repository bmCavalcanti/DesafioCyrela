using Cyrela.DAL.Context;
using Cyrela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cyrela.DAL
{
    public class HomeStatusDAL
    {
        private readonly DataBaseContext context;

        public HomeStatusDAL()
        {
            context = new DataBaseContext();
        }

        public IList<HomeStatus> List()
        {
            return context.HomeStatus.ToList<HomeStatus>();
        }
    }
}