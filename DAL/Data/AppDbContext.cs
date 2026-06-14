using DAL.DomainModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DAL.Data
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "1", 
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "1"
            });


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<AboutSection> About { get; set; }

        public DbSet<ContactMessage> Contact { get; set; }

        public DbSet<HeroSection> Hero { get; set; }

        public DbSet<Service> service { get; set; }



    }
}
