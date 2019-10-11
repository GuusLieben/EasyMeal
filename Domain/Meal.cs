using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace Domain
{
    public class Meal
    {
        public Meal()
        {
        }

        public Meal(DateTime dateValid)
        {
            
                DateValid = dateValid;
            
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column("MealDishes")]
        public ICollection<MealDishes> Dishes { get; set; } = new List<MealDishes>();

        [Required]
        [Column("DateValid")]
        public DateTime DateValid { get; set; }
    }
}
