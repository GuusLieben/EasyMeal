using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Dish
    {
        public Dish()
        {
        }

        public Dish(string name, string description, string imageUri, DishSize dishSize, Double price, DishType dishType)
        {
            Name = name;
            Description = description;
            ImageUri = imageUri;
            DishSize = dishSize;
            Price = price;
            DishType = dishType;
            DietRestrictions = new List<string>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column("DishMeals")]
        public ICollection<MealDishes> Meals { get; set; } = new List<MealDishes>();

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Description")]
        public string Description { get; set; }

        [Required]
        [Column("ImageUri")]
        [Display(Name="Image Uri")]
        public string ImageUri { get; set; }

        [Column("DietRestrictions")]
        [Display(Name = "Diet Restrictions")]
        [ForeignKey("DietRestrictions")]
        public List<string> DietRestrictions { get; set; }

        public void AddRestriction(string restriction)
        {
            DietRestrictions.Add(restriction);
        }

        [Required]
        [Column("DishSize")]
        [Display(Name = "Dish Size")]
        public DishSize DishSize { get; set; }

        [Required(ErrorMessage = "The price field is required.")]
        [Column("Price")]
        public Double Price { get; set; }

        [Required]
        [Column("Type")]
        [Display(Name = "Dish Type")]
        public DishType DishType { get; set; }
    }
}
