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
        bool CreateDish(Dish dish);

        // READ
        Dish GetDish(int Id);
        IEnumerable<Dish> GetAllDishes();
        IEnumerable<Dish> GetAllDishesForMeal(Meal meal);

        IEnumerable<Dish> GetAllDishesForMeal(int mealId);

        
        // UPDATE
        bool EditDish(Dish model);

        // DELETE
        bool DeleteDish(int Id);


        // MEALS
        // CREATE
        bool CreateMeal(Meal meal, Dish[] dishes);

        // READ
        Meal GetMeal(int Id);
        IEnumerable<Meal> GetAllMealOptions();
        IEnumerable<Meal> GetAllMealOptionsForWeek(int week, int year);
        IEnumerable<Meal> GetAllMealOptionsForDay(DateTime day);
        

        // UPDATE
        bool EditMeal(Meal meal, Dish[] dishes);

        // DELETE
        bool DeleteMeal(int Id);


        // MENUS
        // CREATE
        bool CreateMenu(Menu menu);

        // READ
        Menu GetMenu(int Id);
        IEnumerable<Menu> GetAllMenus();


        // UPDATE
        bool EditMenu(Menu menu);

        // DELETE
        bool DeleteMenu(int Id);
        
        
    }
}
