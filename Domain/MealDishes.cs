using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Domain
{
    public class MealDishes
    {

        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int MealId { get; set; }
        public Meal Meal { get; set; }

    }
}
