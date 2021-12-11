using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarProjectContext : DbContext
    {
        public CarProjectContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Cars;User Id=sa;Password=Mb123456,");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable(nameof(Car)).HasNoKey();
            modelBuilder.Entity<Color>().ToTable(nameof(Color)).HasNoKey();
            modelBuilder.Entity<Brand>().ToTable(nameof(Brand)).HasNoKey();
            modelBuilder.Entity<Rental>().ToTable(nameof(Rental)).HasNoKey();
            modelBuilder.Entity<User>().ToTable(nameof(User)).HasNoKey();
            modelBuilder.Entity<Customer>().ToTable(nameof(Customer)).HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}