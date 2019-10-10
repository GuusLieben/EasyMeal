using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Infrastructure.Meals
{
    public  class MealDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetValue<string>("MealDbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cook>().HasIndex(c => c.Email);
            modelBuilder.Entity<Meal>()
                .HasIndex(m => m.DateValid);
            modelBuilder.Entity<Dish>().HasIndex(d => d.Name);

            // KMS
            modelBuilder.Entity<Meal>().HasOne("Domain.Dish", "Starter")
                        .WithMany()
                        .HasForeignKey("StarterId")
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Meal>().HasOne("Domain.Dish", "Main")
                        .WithMany()
                        .HasForeignKey("MainId")
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Meal>().HasOne("Domain.Dish", "Dessert")
                        .WithMany()
                        .HasForeignKey("DessertId")
                        .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Meal> MealOptionals { get; set; }
        public DbSet<Menu> WeekMenus { get; set; }
        

    }
}
