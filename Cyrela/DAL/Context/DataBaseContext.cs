using System.Configuration;
using Cyrela.Models;
using Microsoft.EntityFrameworkCore;

namespace Cyrela.DAL.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Client> Client { get; set; }

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