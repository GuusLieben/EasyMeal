using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Meals
{
    public class EFMealServiceRepository : IMealServiceRepository
    {

        private readonly MealDbContext context;

        public EFMealServiceRepository(MealDbContext context)
        {
            this.context = context;
        }

        // DISHES
        // CREATE
        public Boolean CreateDish(Dish dish)
        {
            try
            {
                context.Add(dish);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // READ
        public Dish GetDish(int id)
        {
            return context.Dishes.SingleOrDefault(d => d.Id == id);
        }
        public IEnumerable<Dish> GetAllDishes()
        {
            return context.Dishes;
        }
        public IEnumerable<Dish> GetAllDishesForMeal(Meal meal)
        {
            IEnumerable<MealDishes> mealDishes = meal.Dishes;
            if (mealDishes == null) return new List<Dish>();
            else
            {
                List<Dish> dishes = new List<Dish>();
                foreach (MealDishes mealDish in mealDishes)
                {
                    dishes.Add(mealDish.Dish);
                }
                return dishes;
            }
        }
        public IEnumerable<Dish> GetAllDishesForMeal(int mealId)
        {
            DbSet<Meal> meals = context.Meals;
            Meal meal = meals
                .SingleOrDefault(m =>
                m.Id ==
                mealId);
            return meal == null ? new List<Dish>() : GetAllDishesForMeal(meal);
        }

        // UPDATE
        public Boolean EditDish(Dish model)
        {
            try
            {
                context.Dishes.Attach(model);
                //context.Entry(model).Property(m => m).IsModified = true;
                context.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE
        public Boolean DeleteDish(int Id)
        {
            try
            {
                Dish dish = context.Dishes.Where(d => d.Id == Id).SingleOrDefault();
                if (dish == null) return false;
                else
                {
                    context.Remove(dish);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        // MEALS
        // CREATE
        public bool CreateMeal(Meal meal, Dish[] dishes)
        {
            if (dishes.Length == 3)
            {
                try
                {
                    context.Add(meal);
                    foreach (Dish dish in dishes)
                    {
                        context.Add(new MealDishes { Dish = dish, Meal = meal });
                    }

                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        // READ
        public Meal GetMeal(int id)
        {
            return context.Meals.SingleOrDefault(m => m.Id == id);
        }
        public IEnumerable<Meal> GetAllMealOptions()
        {
            return context.Meals;
        }
        public IEnumerable<Meal> GetAllMealOptionsForDay(DateTime day)
        {
            return context.Meals.Where(mo => mo.DateValid.CompareTo(day) == 0);
        }
        public IEnumerable<Meal> GetAllMealOptionsForWeek(int week, int year)
        {
            return context.Meals.Where(mo => mo.DateValid.Week() == week && mo.DateValid.Year == year);
        }

        // UPDATE
        public bool EditMeal(Meal meal)
        {
            throw new NotImplementedException();
        }

        // DELETE
        public bool DeleteMeal(int Id)
        {
            throw new NotImplementedException();
        }


        // MENUS
        // CREATE
        public bool CreateMenu(Menu menu)
        {
            throw new NotImplementedException();
        }

        // READ
        public Menu GetMenu(int Id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Menu> GetAllMenus()
        {
            return context.Menus;
        }

        // UPDATE
        public bool EditMenu(Menu menu)
        {
            throw new NotImplementedException();
        }

        // DELETE
        public bool DeleteMenu(int Id)
        {
            throw new NotImplementedException();
        }



















    }
}
