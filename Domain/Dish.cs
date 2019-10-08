using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Dish
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }
        public DietRestrictions[] DietRestrictions { get; set; }
        public DishSize DishSize { get; set; }
        public double Price { get; set; }
        public DishType[] DishTypes { get; set; }
    }
}
