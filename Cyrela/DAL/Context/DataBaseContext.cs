using System.Configuration;
using Cyrela.Models;
using Microsoft.EntityFrameworkCore;

namespace Cyrela.DAL.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Scheduling> Scheduling { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Home> Home { get; set; }
        public DbSet<HomeAddress> HomeAddress { get; set; }
        public DbSet<HomeStatus> HomeStatus { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<EmployeeDayOff> EmployeeDayOff { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleService> RoleService { get; set; }
        public DbSet<SchedulingType> SchedulingType { get; set; }
        public DbSet<SchedulingStatus> SchedulingStatus { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<State> State { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle(ConfigurationManager.ConnectionStrings["CyrelaConnection"].ConnectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}