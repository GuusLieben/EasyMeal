using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Service
{
    class MealDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cook>().HasIndex(c => c.Email);
            modelBuilder.Entity<Meal>().HasIndex(m => m.DateValid);
            modelBuilder.Entity<Menu>().HasIndex(m => m.Meals[0].DateValid);
            modelBuilder.Entity<Dish>().HasIndex(d => d.Name);
        }

        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Meal> MealOptionals { get; set; }
        public DbSet<Menu> WeekMenus { get; set; }
        public DbSet<Dish> Dishes { get; set; }

    }
}
