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

        public Meal(Dish starter, Dish main, Dish dessert, DateTime dateValid)
        {
            Starter = starter;
            Main = main;
            Dessert = dessert;
            DateValid = dateValid;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Starter")]
        
        public Dish Starter { get; set; }

        [Required]
        [Column("Main")]
        
        public Dish Main { get; set; }

        [Required]
        [Column("Dessert")]
        
        public Dish Dessert { get; set; }

        public DateTime DateValid { get; set; }
    }
}
