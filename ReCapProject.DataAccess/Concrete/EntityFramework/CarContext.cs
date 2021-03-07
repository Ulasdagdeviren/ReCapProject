using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Entities.concrete;


namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
   public class CarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // projemiz hangi veri tabanı ile ilişkili onu belirledik
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

        // Mapping artık ovverride ile yapılıyor Core da
        // mapping class da farklı veritabanınada columnname ler farklıysa yazarız
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  // Fluent mapping kodlama denir buna
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<User>().ToTable("Users"); // ya da cars ın yanına dbo yazılır
            modelBuilder.Entity<User>().Property(p => p.Email).HasColumnName("Email"); // vs.
            modelBuilder.Entity<User>().Property(p => p.FirstName).HasColumnName("FirstName");
            modelBuilder.Entity<User>().Property(p => p.LastName).HasColumnName("LastName");
          


        }
    }
}
