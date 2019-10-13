using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Client : IActor
    {
        public Client()
        {
        }

        public Client(string city, string street, int houseNumber, string addition, DateTime birthDate, ICollection<string> dietRestrictions, ICollection<Menu> orderHistory)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            Addition = addition;
            BirthDate = birthDate;
            DietRestrictions = dietRestrictions;
            OrderHistory = orderHistory;
        }

        [Required]
        [Column("City")]
        [StringLength(64, ErrorMessage = "City name cannot be longer than 64 characters")]
        public string City { get; set; }

        [Required]
        [Column("Street")]
        [StringLength(64, ErrorMessage = "Street name cannot be longer than 64 characters")]
        public string Street { get; set; }

        [Required]
        [Column("HouseNumber")]
        [Display(Name = "House Number")]
        public int HouseNumber { get; set; }

        [Column("HNAddition")]
        [Display(Name = "House Number Addition")]
        public string Addition { get; set; }

        [Required]
        [Column("Birthdate")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column("DietRestrictions")]
        [Display(Name = "Diet Restrictions")]
        public ICollection<string> DietRestrictions { get; set; }

        [Column("Orders")]
        public ICollection<Menu> OrderHistory { get; set; }
    }
}
