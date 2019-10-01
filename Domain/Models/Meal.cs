using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface Meal
    {
        Dish Starter { get; set; }
        Dish Main { get; set; }
        Dish Dessert { get; set; }
    }
}
