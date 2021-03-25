using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Entities.CarDetail;
using ReCapProject.Entities.concrete;


namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
   public class CarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarHire;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarColor> CarColors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<User>().ToTable("Users"); 
            modelBuilder.Entity<CarBrand>().ToTable("Brands");
            modelBuilder.Entity<CarColor>().ToTable("Colors");
           
          


        }
    }
}
