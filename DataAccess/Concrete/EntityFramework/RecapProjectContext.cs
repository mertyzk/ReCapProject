using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class RecapProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;port=5432;Database=RecapProject;Username=postgres;Password=123Qwe321");
            
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
