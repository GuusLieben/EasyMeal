using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Domain
{
    public class Meal
    {
        public Dish[] Starter { get; set; }
        public Dish[] Main { get; set; }
        public Dish[] Dessert { get; set; }
        public DateTime DateValid { get; set; }
    }
}
