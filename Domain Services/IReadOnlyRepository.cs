using System;
using System.Collections.Generic;

namespace EasyMeal.Core.Domain.Services
{
    public interface IReadOnlyRepository
    {


        // DISHES
        Dish GetDish(int Id);
        IEnumerable<Dish> GetAllDishes();
        IEnumerable<Dish> GetAllDishesForMeal(Meal meal);

        IEnumerable<Dish> GetAllDishesForMeal(int mealId);


        // MEALS
        Meal GetMeal(int Id);
        IEnumerable<Meal> GetAllMealOptions();
        IEnumerable<Meal> GetAllMealOptionsForWeek(int week, int year);
        IEnumerable<Meal> GetAllMealOptionsForDay(DateTime day);


        // MENUS
        Menu GetMenu(int Id);
        IEnumerable<Menu> GetAllMenus();
    }
}
