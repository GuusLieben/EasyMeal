using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EasyMeal.Core.Domain
{
    public class Menu
    {


        [Key]
        public int Id { get; set; }

        [Column("Meals")]
        [ForeignKey("MealId")]
        public ICollection<Int32> Meals { get; set; }

        [Column("Week")]
        [DataType(DataType.DateTime)]
        public DateTime Week { get; set; }


        public Menu(List<Int32> meals, DateTime Week)
        {
            //if (meals.IsValid())
            //{
                this.Meals = meals;
                this.Week = Week;
            //}
            //else throw new ArgumentException("Menu should be for one whole week (7 days), start on a Monday, and end on a Sunday");
        }

        public Menu(int id, ICollection<Int32> meals, DateTime week)
        {
            Id = id;
            Meals = meals;
            Week = week;
        }

        public Menu()
        {
        }

    }

    public static class Extensions
    {
        public static int Week(this DateTime date)
        {
            GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
            return cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static Boolean IsValid(this ICollection<Meal> meals)
        {
            if (meals.Count >= 4 && meals.Count <= 7)
            {
                DateTime firstDate = DateTime.Today.AddYears(10);
                DateTime lastDate = DateTime.Today.AddYears(10);
                meals.ToList().ForEach(meal =>
                {
                    if (meal.DateValid.CompareTo(firstDate) < 0) firstDate = meal.DateValid;
                    if (meal.DateValid.CompareTo(lastDate) > 0) lastDate = meal.DateValid;
                });

                if (firstDate.DayOfWeek == DayOfWeek.Monday && lastDate.DayOfWeek == DayOfWeek.Sunday)
                    if (firstDate.CompareTo(lastDate) == 7) return true;

            }
            return false;
        }

        public static DateTime StartOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        public static bool OrderDishesRules(int amountOfDishes, bool weekMatched)
        {
            return amountOfDishes >= 4 && weekMatched;
        }

        public static double CalculateTotalDiscount(double price, double shipment, double dishDiscount, double birthdayDiscount)
        {
            return price + shipment - dishDiscount - birthdayDiscount;
        }

        public static double TotalPrice(IEnumerable<ClientOrder> orders, Dictionary<int, Dish> dishes)
        {
            var price = 0.00;
            foreach (var clientOrder in orders)
            {
                dishes.TryGetValue(clientOrder.DishId, out var dish);
                switch (clientOrder.Size)
                {
                    case EasyMeal.Core.Domain.DishSize.Large:
                        price += 1.2 * dish.Price;
                        break;
                    case EasyMeal.Core.Domain.DishSize.Small:
                        price += 0.8 * dish.Price;
                        break;
                    default:
                        price += dish.Price;
                        break;
                }
            }

            return price;
        }
    }

}
