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

        public Dish(int id, string name, string description, string imageUri, DishSize dishSize, double price, DishType dishType)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUri = imageUri;
            DishSize = dishSize;
            Price = price;
            DishType = dishType;
        }

        [Key]
        [Required]
        [Column("DishId")]
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Description")]
        public string Description { get; set; }

        [Required]
        [Column("ImageUri")]
        public string ImageUri { get; set; }

        [Required]
        [Column("DietRestrictions")]
        [Display(Name = "Diet Restrictions")]
        public ICollection<DietRestrictions> DietRestrictions { get; set; }

        [Required]
        [Column("DishSize")]
        [Display(Name = "Dish Size")]
        public DishSize DishSize { get; set; }

        [Required]
        [Column("Price")]
        public double Price { get; set; }

        [Required]
        [Column("Type")]
        public DishType DishType { get; set; }
    }
}
