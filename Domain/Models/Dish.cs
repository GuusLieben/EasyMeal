using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface Dish
    {
        string Name { get; set; }
        string Description { get; set; }
        string ImageUri { get; set; }
        DietRestrictions[] DietRestrictions { get; set; }
        DishSize DishSize { get; set; }
        double Price { get; set; }
    }
}
