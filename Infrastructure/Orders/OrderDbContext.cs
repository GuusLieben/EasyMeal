using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Orders
{
    public class OrderDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Client>().HasIndex(c => c.Email);
        }

        public DbSet<Domain.Client> Clients { get; set; }
        public DbSet<Domain.Meal> MealsChosen { get; set; }
        public DbSet<Domain.Menu> MenusChosen { get; set; }
    }
}
