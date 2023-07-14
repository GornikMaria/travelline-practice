using DatabaseProvider.Configurations;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace DatabaseProvider
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        { }
        public ApplicationContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingDataConfiguration());
            modelBuilder.ApplyConfiguration(new BookingDataConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration()); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString == null)
            {
                return;
            }
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}