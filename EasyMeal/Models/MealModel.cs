using EasyMeal.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMeal.API.Models
{
    public class MealModel
    {
        public int Id { get; set; }

        public IEnumerable<int> Dishes { get; set; } = new List<int>();

        public DateTime DateValid { get; set; }
    }
}
