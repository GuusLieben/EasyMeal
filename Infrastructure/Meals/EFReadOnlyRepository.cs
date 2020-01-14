using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyMeal.Core.Domain;
using EasyMeal.Core.Domain.Services;

namespace EasyMeal.Infrastructure.Meals
{
    public class EFReadOnlyRepository : IReadOnlyRepository
    {

        private readonly IMealServiceRepository repository;

        public EFReadOnlyRepository(MealDbContext context)
        {
            this.repository = new EFMealServiceRepository(context);
        }

        public IEnumerable<Dish> GetAllDishes()
        {
            return repository.GetAllDishes();
        }

        public IEnumerable<Dish> GetAllDishesForMeal(Meal meal)
        {
            return repository.GetAllDishesForMeal(meal);
        }

        public IEnumerable<Dish> GetAllDishesForMeal(int mealId)
        {
            return repository.GetAllDishesForMeal(mealId);
        }

        public IEnumerable<Meal> GetAllMealOptions()
        {
            return repository.GetAllMealOptions();
        }

        public IEnumerable<Meal> GetAllMealOptionsForDay(DateTime day)
        {
            return repository.GetAllMealOptionsForDay(day);
        }

        public IEnumerable<Meal> GetAllMealOptionsForWeek(int week, int year)
        {
            return repository.GetAllMealOptionsForWeek(week, year);
        }

        public IEnumerable<Menu> GetAllMenus()
        {
            return repository.GetAllMenus();
        }

        public Dish GetDish(int Id)
        {
            return repository.GetDish(Id);
        }

        public Meal GetMeal(int Id)
        {
            return repository.GetMeal(Id);
        }

        public Menu GetMenu(int Id)
        {
            return repository.GetMenu(Id);
        }
    }
}
