using EasyMeal.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EasyMeal.Infrastructure.Meals
{
    public  class MealDbContext : IdentityDbContext
    {

        public MealDbContext(DbContextOptions<MealDbContext> options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Store DietRestrictions as JSON text, as we cannot store collections of primitive types
            modelBuilder.Entity<Dish>().Property(d => d.DietRestrictions).HasConversion(r => JsonConvert.SerializeObject(r), r => JsonConvert.DeserializeObject<List<string>>(r));
            modelBuilder.Entity<Menu>().Property(m => m.Meals).HasConversion(m => JsonConvert.SerializeObject(m), m => JsonConvert.DeserializeObject<List<Int32>>(m));
            // Make it so we have a 'many-to-many' relation between Dish and Meal (aka double one-to-many relations)
            modelBuilder.Entity<MealDishes>().HasKey(md => new { md.MealId, md.DishId, md.Id });

            // Seed data
            // Cooks
            var cook = new Cook("Henk", "Dekker", "h.d@avans.nl" ,"0612345678");

            // Dishes
            var dessert = new Dish("Salted Caramel Cake", "Moist, delicious layer cake with caramel icing", DishSize.Medium, 3.95, DishType.Dessert) { Id = -2 };
            dessert.AddRestriction("No salt");

            var starter = new Dish("Carpaccio", "A dish of meat or fish, thinly sliced or pounded thin, and served raw", DishSize.Small, 5.80, DishType.Starter) { Id = -3 };
            var main = new Dish("Filet Mignons", "A steak cut of beef taken from the smaller end of the tenderloin, or psoas major of the cow carcass", DishSize.Medium, 28.30, DishType.Main) { Id = -4 };


            Dish[] dishes = new Dish[]
            {
                starter,
                main,
                dessert
            };

            // Menu
            Meal meal = new Meal(DateTime.Parse("1/1/2019")) { Id = -5 };

            Menu menu = new Menu(new List<Int32>() { meal.Id }, DateTime.Today) { Id = -6 };

            // Set data
            modelBuilder.Entity<Cook>().HasData(cook);
            modelBuilder.Entity<Dish>().HasData(dishes);
            modelBuilder.Entity<Meal>().HasData(meal);
            modelBuilder.Entity<Menu>().HasData(menu);
        }



        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MealDishes> MealDishes { get; set; }
    }
}
