using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Services;

namespace Domain.Services
{
    public interface IMealRepository
    {
        IEnumerable<Meal> GetAllMealOptions();

        IEnumerable<Meal> GetAllMealOptionsForWeek(int week, int year);

        IEnumerable<Meal> GetAllMealOptionsForDay(DateTime day);
    }
}
