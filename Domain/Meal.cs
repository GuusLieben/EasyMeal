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

        public Meal(Dish[] dishes, DateTime dateValid)
        {
            if (dishes.Length == 3)
            {
                Dishes = new List<Dish>(dishes);
                DateValid = dateValid;
            }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("DishId")]
        public ICollection<Dish> Dishes { get; set; }

        [Required]
        [Column("DateValid")]
        public DateTime DateValid { get; set; }
    }
}
