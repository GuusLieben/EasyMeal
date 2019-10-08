using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain;
using Domain.Services;

namespace Infrastructure.Service
{
    class EFMealRepository : IMealRepository
    {

        private readonly MealDbContext context;

        public EFMealRepository(MealDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Meal> GetAllMealOptions()
        {
            return context.MealOptionals;
        }

        public IEnumerable<Meal> GetAllMealOptionsForDay(DateTime day)
        {
            return context.MealOptionals.Where(mo => mo.DateValid.CompareTo(day) == 0);
        }

        public IEnumerable<Meal> GetAllMealOptionsForWeek(int week, int year)
        {
            return context.MealOptionals.Where(mo => mo.DateValid.Week() == week && mo.DateValid.Year == year);
        }

    }
}
