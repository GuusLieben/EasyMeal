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

        public static DateTime StartOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            return result.AddDays(-3);
        }
    }

}
