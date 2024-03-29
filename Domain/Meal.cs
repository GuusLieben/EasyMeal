﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyMeal.Core.Domain
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
        [Display(Name ="Date Valid")]
        public DateTime DateValid { get; set; }
    }

}
