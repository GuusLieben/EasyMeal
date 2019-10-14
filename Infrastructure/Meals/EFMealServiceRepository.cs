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
        public bool CreateDish(Dish dish)
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
        public Dish GetDish(int Id)
        {
            return context.Dishes.SingleOrDefault(d => d.Id == Id);
        }
        public IEnumerable<Dish> GetAllDishes()
        {
            return context.Dishes;
        }
        public IEnumerable<Dish> GetAllDishesForMeal(Meal meal)
        {
            var mealDishes = context.MealDishes.Where(md => md.MealId == meal.Id);
            Dish[] dishes = new Dish[3];
            foreach (var md in mealDishes)
            {
                var dish = GetDish(md.DishId);
                if (dish != null)
                {
                    if (dish.DishType.Equals(DishType.Starter)) dishes[0] = dish;
                    if (dish.DishType.Equals(DishType.Main)) dishes[1] = dish;
                    if (dish.DishType.Equals(DishType.Dessert)) dishes[2] = dish;
                }
            }

            return dishes;
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
        public bool EditDish(Dish model)
        {
            try
            {
                context.Dishes.Attach(model);
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
        public bool DeleteDish(int Id)
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
        public Meal GetMeal(int Id)
        {
            return context.Meals.SingleOrDefault(m => m.Id == Id);
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
            try
            {
                context.Meals.Attach(meal);
                context.Update(meal);
                context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        // DELETE
        public bool DeleteMeal(int Id)
        {
            try
            {
                Meal meal = context.Meals.Where(m => m.Id == Id).SingleOrDefault();
                if (meal == null) return false;
                else
                {
                    context.Remove(meal);
                    context.SaveChanges();
                    return true;
                }
            } catch (Exception)
            {
                return false;
            }
        }


        // MENUS
        // CREATE
        public bool CreateMenu(Menu menu)
        {
            try
            {
                context.Add(menu);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // READ
        public Menu GetMenu(int Id)
        {
            return context.Menus.SingleOrDefault(m => m.Id == Id);
        }
        public IEnumerable<Menu> GetAllMenus()
        {
            return context.Menus;
        }

        // UPDATE
        public bool EditMenu(Menu menu)
        {
            try
            {
                context.Menus.Attach(menu);
                context.Update(menu);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE
        public bool DeleteMenu(int Id)
        {
            try
            {
                Menu menu = context.Menus.Where(m => m.Id == Id).SingleOrDefault();
                if (menu == null) return false;
                else
                {
                    context.Remove(menu);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
