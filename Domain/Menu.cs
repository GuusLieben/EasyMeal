using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain
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

    public static class WeekMenuEM
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
    }

}
