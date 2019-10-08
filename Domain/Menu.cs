using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Domain
{
    public class Menu
    {
        private List<Meal> _meals;
        private DateTime _week;

        private DateTime GetWeek()
        {
            return _week;
        }

        private void SetWeek(DateTime value)
        {
            _week = value;
        }

        public Menu(List<Meal> meals, DateTime Week)
        {
            if (meals.IsValid())
            {
                this._meals = meals;
                this.SetWeek(Week);
            }
            else throw new ArgumentException("Menu should be for one whole week (7 days), start on a Monday, and end on a Sunday");
        }

        public List<Meal> Meals
        {
            get { return this._meals; }
            set { if (value.IsValid()) this._meals = value; }
        }

    }

    public static class WeekMenuEM
    {
        public static int Week(this DateTime date)
        {
            GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
            return cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        public static Boolean IsValid(this List<Meal> meals)
        {
            if (meals.Count >= 4 && meals.Count <= 7)
            {
                DateTime firstDate = DateTime.Today.AddYears(10);
                DateTime lastDate = DateTime.Today.AddYears(10);
                meals.ForEach(meal =>
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
