using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Services;

namespace Domain.Services
{
    public interface IMealServiceRepository
    {
        Boolean CreateDish(Dish dish);

        Meal GetMeal(int id);

        IEnumerable<Meal> GetAllMealOptions();

        IEnumerable<Meal> GetAllMealOptionsForWeek(int week, int year);

        IEnumerable<Meal> GetAllMealOptionsForDay(DateTime day);

        Dish GetDish(int id);

        IEnumerable<Dish> GetAllDishes();

        IEnumerable<Dish> GetAllDishesForMeal(Meal meal);
        IEnumerable<Menu> GetAllMenus();
        IEnumerable<Dish> GetAllDishesForMeal(int mealId);
        Boolean DeleteDish(int id);
        Boolean EditDish(Dish model);
    }
}
