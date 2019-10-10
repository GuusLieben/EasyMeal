using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public abstract class IActor
    {
        [Required]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required]
        [Column("LastName")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required]
        [Column("Email")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Column("PhoneNumber")]
        [Display(Name = "Phone number")]
        public string Phonenumber { get; set; }

        [Required]
        [Column("Hash")]
        [Display(Name = "Password Hash")]
        public string Password { get; set; }
    }
}
