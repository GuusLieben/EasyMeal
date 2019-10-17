namespace EasyMeal.Core.Domain
{
    public class MealDishes
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int MealId { get; set; }
        public Meal Meal { get; set; }

    }
}
