using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Services;

namespace Domain.Services
{
    public interface IMealServiceRepository
    {


        // DISHES
        // CREATE
        Boolean CreateDish(Dish dish);

        // READ
        Dish GetDish(int Id);
        IEnumerable<Dish> GetAllDishes();
        IEnumerable<Dish> GetAllDishesForMeal(Meal meal);
        IEnumerable<Dish> GetAllDishesForMeal(int mealId);

        
        // UPDATE
        Boolean EditDish(Dish model);

        // DELETE
        Boolean DeleteDish(int Id);


        // MEALS
        // CREATE
        Boolean CreateMeal(Meal meal, Dish[] dishes);

        // READ
        Meal GetMeal(int Id);
        IEnumerable<Meal> GetAllMealOptions();
        IEnumerable<Meal> GetAllMealOptionsForWeek(int week, int year);
        IEnumerable<Meal> GetAllMealOptionsForDay(DateTime day);

        // UPDATE
        Boolean EditMeal(Meal meal);

        // DELETE
        Boolean DeleteMeal(int Id);


        // MENUS
        // CREATE
        Boolean CreateMenu(Menu menu);

        // READ
        Menu GetMenu(int Id);
        IEnumerable<Menu> GetAllMenus();


        // UPDATE
        Boolean EditMenu(Menu menu);

        // DELETE
        Boolean DeleteMenu(int Id);
        
        
    }
}
