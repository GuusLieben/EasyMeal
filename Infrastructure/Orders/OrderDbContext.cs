using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Orders
{
    class OrderDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Client>().HasIndex(c => c.Email);
        }

        DbSet<Client> Clients { get; set; }
        DbSet<Meal> MealsChosen { get; set; }
        DbSet<Menu> MenusChosen { get; set; }
    }
}
