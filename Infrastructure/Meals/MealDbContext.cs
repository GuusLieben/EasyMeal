using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Meals
{
    public  class MealDbContext : DbContext
    {

        public MealDbContext(DbContextOptions<MealDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Store DietRestrictions as JSON text, as we cannot store collections of primitive types
            modelBuilder.Entity<Dish>().Property(d => d.DietRestrictions).HasConversion(r => JsonConvert.SerializeObject(r), r => JsonConvert.DeserializeObject<List<string>>(r));
            // Make it so we have a 'many-to-many' relation between Dish and Meal (aka double one-to-many relations)
            modelBuilder.Entity<MealDishes>().HasKey(md => new { md.MealId, md.DishId });

            // Seed data
            // Cooks
            var cook = new Cook("Henk", "Dekker", "h.d@gmail.com", "0612345678", "1234") { Id = -1 };

            // Dishes
            var dessert = new Dish("Salted Caramel Cake", "Moist, delicious layer cake with caramel icing", "google.com", DishSize.Medium, 3.95, DishType.Dessert) { Id = -2 };
            dessert.AddRestriction("No salt");

            Dish[] dishes = new Dish[]
            {
                new Dish("Carpaccio", "A dish of meat or fish, thinly sliced or pounded thin, and served raw","google.com", DishSize.Small, 5.80, DishType.Starter) { Id = -3 },
                new Dish("Filet Mignons", "A steak cut of beef taken from the smaller end of the tenderloin, or psoas major of the cow carcass", "google.com", DishSize.Medium, 28.30, DishType.Main) { Id = -4 },
                dessert
            };

            // Menu
            Meal meal = new Meal(DateTime.Parse("1/1/2019")) { Id = -5 };

            // Set data
            modelBuilder.Entity<Cook>().HasData(cook);
            modelBuilder.Entity<Dish>().HasData(dishes);
            modelBuilder.Entity<Meal>().HasData(meal);

        }



        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Menu> Menus { get; set; }

    }
}
