using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8.DATA.Models
{
    public class AppAPIDbContext : DbContext
    {
        public AppAPIDbContext()
        {
        }
        public AppAPIDbContext(DbContextOptions options) : base(options)
        {
        }



        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LEVANHUNG\\LEVANHUNG;Initial Catalog=NET5_LAB78;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car_People>()
                .HasKey(cp=> new { cp.CarId,cp.PeopleId });
            //////////////////////////////////
            modelBuilder.Entity<Laptop_People>()
                .HasKey(cp=> new { cp.LaptopId,cp.PeopleId });
            ///////////////////////////////////
            //Car - People (N N)
            modelBuilder.Entity<Car_People>()
                .HasOne(cp => cp.Car)
                .WithMany(c => c.Car_Peoples)
                .HasForeignKey(cp => cp.CarId);
            modelBuilder.Entity<Car_People>()
                .HasOne(cp => cp.People)
                .WithMany(p => p.Car_Peoples)
                .HasForeignKey(cp => cp.CarId);

            ////////////////////////////////////
            //Laptop - People (N N)
            modelBuilder.Entity<Laptop_People>()
                .HasOne(cp => cp.Laptop)
                .WithMany(c => c.Laptop_Peoples)
                .HasForeignKey(cp => cp.LaptopId);
            modelBuilder.Entity<Laptop_People>()
                .HasOne(cp => cp.People)
                .WithMany(p => p.Laptop_Peoples)
                .HasForeignKey(cp => cp.PeopleId);


        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Laptop_People> Laptop_Peoples { get; set; }
        public DbSet<Car_People> Car_Peoples { get; set; }

    }
}
