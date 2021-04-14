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

        public IList<Scheduling> List()
        {
            return context.Scheduling
                .Include(e => e.Employee)
                .Include(s => s.Home)
                .Include(s => s.SchedulingStatus)
                .Include(s => s.SchedulingType)
                .Include(s => s.Service)
                .ToList<Scheduling>()
            ;
        }

        public Scheduling Get(int Id)
        {
            return context.Scheduling
                .Include(s => s.Employee)
                .Include(s => s.Home)
                .Include(s => s.SchedulingStatus)
                .Include(s => s.SchedulingType)
                .Include(s => s.Service)
                .FirstOrDefault(s => s.EmployeeId == Id)
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
            var scheduling = new Scheduling() { Id = Id };

            context.Scheduling.Remove(scheduling);
            context.SaveChanges();
        }
    }
}