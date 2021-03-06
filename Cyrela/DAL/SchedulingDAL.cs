using Cyrela.Models;
using Cyrela.DAL.Context;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Cyrela.DAL
{
    public class SchedulingDAL
    {
        private readonly DataBaseContext context;

        public SchedulingDAL()
        {
            context = new DataBaseContext();
        }

        public IList<Scheduling> ListByClient(int ClientId)
        {
            return context.Scheduling
                .Include(s => s.Home)
                .Include(s => s.Home.HomeAddress)
                .Include(s => s.Home.HomeAddress.City)
                .Include(s => s.Home.HomeAddress.City.State)
                .Include(s => s.Home.Client)
                .Include(s => s.SchedulingStatus)
                .Include(s => s.SchedulingType)
                .Include(s => s.Service)
                .Where(s => s.Home.ClientId == ClientId)
                .ToList<Scheduling>()
            ;
        }

        public Scheduling Get(int Id)
        {
            return context.Scheduling
                .Include(s => s.Home)
                .Include(s => s.Home.HomeAddress)
                .Include(s => s.Home.HomeAddress.City)
                .Include(s => s.Home.HomeAddress.City.State)
                .Include(s => s.Home.Client)
                .Include(s => s.SchedulingStatus)
                .Include(s => s.SchedulingType)
                .Include(s => s.Service)
                .FirstOrDefault(s => s.Id == Id)
            ;
        }

        public void Insert(Scheduling scheduling)
        {
            context.Scheduling.Add(scheduling);
            context.SaveChanges();
        }

        public void Update(Scheduling scheduling)
        {
             context.Scheduling.Update(scheduling);
             context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Scheduling.Remove(new Scheduling() { Id = Id });
            context.SaveChanges();
        }

        public Scheduling GetSimple(int Id)
        {
            return context.Scheduling.Find(Id);
        }
    }
}