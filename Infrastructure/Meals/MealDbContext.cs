using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Infrastructure.Meals
{
    public  class MealDbContext : DbContext
    {

        public MealDbContext(DbContextOptions<MealDbContext> options) :base(options)
        {

        }
        


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // optionsBuilder.UseSqlServer(configuration.GetValue<string>("MealDbConnection"));
        //    optionsBuilder.UseSqlServer("Server=192.168.2.21;User Id=SSWF5;Password=3A)AD9a#x]zgf+($;Database=SSWFMeals;MultipleActiveResultSets=true");
        //}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Cook>().HasData(new Cook("Henk", "Dekker", "h.d@gmail.com", "0612345678", "1234")
            {
                Id = 5
            });
            modelBuilder.Entity<Meal>().HasMany<Dish>(m => m.Dishes).WithOne().OnDelete(DeleteBehavior.Restrict);
        }



        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Meal> MealOptionals { get; set; }
        public DbSet<Menu> WeekMenus { get; set; }
        

    }
}
